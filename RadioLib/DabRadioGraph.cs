using System;
using System.Runtime.InteropServices;
using DirectShowLib;
using DirectShowLib.Utils;

namespace RadioLib
{
    public enum DecoderType
    {
        Microsoft = 0,
        FFDShow = 1
    }

    public class DabRadioGraph : RadioBase, IDisposable
    {
        private IBaseFilter decoder;
        private IBaseFilter splitter;
        private IPin decoderInputPin;
        private IPin decoderOutputPin;

        public DabRadio RadioControl
        {
            get { return new DabRadio((IDabRadioControlFilter)source); }
        }

        protected override void ConnectPins()
        {
            FilterGraphTools.ConnectFilters(filterGraph, sourceOutputPin, decoderInputPin, true);
            FilterGraphTools.ConnectFilters(filterGraph, decoderOutputPin, renderInputPin, true);
        }

        protected override string SourceFilterName
        {
            get { return "RTKDABSourceFilter"; }
        }

        protected override void DisconnectPins()
        {
            var hr = filterGraph.Disconnect(sourceOutputPin);
            Marshal.ThrowExceptionForHR(hr);

            // Disconnet spliiter?

            hr = filterGraph.Disconnect(decoderInputPin);
            Marshal.ThrowExceptionForHR(hr);

            hr = filterGraph.Disconnect(decoderOutputPin);
            Marshal.ThrowExceptionForHR(hr);

            hr = filterGraph.Disconnect(renderInputPin);
            Marshal.ThrowExceptionForHR(hr);
        }

        protected override bool BuildGraph()
        {
            const DecoderType type = DecoderType.Microsoft;

            switch (type)
            {
                case DecoderType.Microsoft:
                    decoder = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(CMpegAudioCodec).GUID, "AudioDecoder");
                    break;
                case DecoderType.FFDShow:
                    // Insert FFD guid here
                    decoder = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(CMpegAudioCodec).GUID, "AudioDecoder");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            renderer = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(DSoundRender).GUID, "Renderer");

            sourceOutputPin = GetUnconnectedPin(source, PinDirection.Output);
            if (sourceOutputPin == null)
                throw new NullReferenceException("Cannot find unconnected output pin");

            decoderInputPin = GetUnconnectedPin(decoder, PinDirection.Input);
            if (decoderInputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");

            decoderOutputPin = GetUnconnectedPin(decoder, PinDirection.Output);
            if (decoderOutputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");

            renderInputPin = GetUnconnectedPin(renderer, PinDirection.Input);
            if (renderInputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");
            
            graphBuilt = true;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Dispose managed resources.
            }

            if (decoderInputPin != null)
            {
                Marshal.ReleaseComObject(decoderInputPin);
                decoderInputPin = null;
            }

            if (decoderOutputPin != null)
            {
                Marshal.ReleaseComObject(decoderOutputPin);
                decoderOutputPin = null;
            }

            if (decoder != null)
            {
                Marshal.ReleaseComObject(decoder);
                decoder = null;
            }

            if (splitter != null)
            {
                Marshal.ReleaseComObject(splitter);
                splitter = null;
            }

            base.Dispose(disposing);
            disposed = true;
        }
    }
}