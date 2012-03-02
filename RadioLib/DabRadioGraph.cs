using System;
using System.Runtime.InteropServices;
using DirectShowLib;
using DirectShowLib.Utils;

namespace RadioLib
{
    public enum MpegDecoderType
    {
        Microsoft = 0,
        FfdShow = 1
    }

    public enum AacDecoderType : uint
    {
        Debug = 1,
        ArcSoft = 2,
        CyberLink = 3,
        NewSoft = 4,
        BlazeVideo = 5,
        Honestech = 6,
        Leadtek = 7
    }

    [ComImport, Guid("0F40E1E5-4F79-4988-B1A9-CC98794E6B55")]
    public class FfdShowAudioDecoder
    {
    }

    [ComImport, Guid("06d96276-112c-49b6-bdc7-8668a3001fef")]
    public class DabSplitter
    {
    }

    public class DabRadioGraph : RadioBase, IDisposable
    {
        private IBaseFilter decoder;
        private IBaseFilter splitter;
        private IPin decoderInputPin;
        private IPin decoderOutputPin;
        private readonly MpegDecoderType mpegDecoderType;
        private readonly AacDecoderType aacDecoderType;

        public DabRadioGraph()
            : this(MpegDecoderType.Microsoft, AacDecoderType.Debug)
        {
        }

        public DabRadioGraph(MpegDecoderType mpegDecoderType, AacDecoderType aacDecoderType)
        {
            this.mpegDecoderType = mpegDecoderType;
            this.aacDecoderType = aacDecoderType;
        }

        public DabRadio RadioControl
        {
            get { return new DabRadio((IDabRadioControlFilter)source); }
        }

        public Splitter SplitterControl
        {
            get
            {
                if (graphBuilt)
                    return new Splitter((ISplitterInterface)splitter);
                return null;
            }
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
            switch (mpegDecoderType)
            {
                case MpegDecoderType.Microsoft:
                    decoder = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(CMpegAudioCodec).GUID, "AudioDecoder");
                    break;
                case MpegDecoderType.FfdShow:
                    decoder = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(FfdShowAudioDecoder).GUID, "AudioDecoder");
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

            AddSplitter();

            graphBuilt = true;
            return true;
        }

        private void AddSplitter()
        {
            //splitter = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(DabSplitter).GUID, "Splitter");
            //var control = new Splitter((ISplitterInterface)splitter);
            //control.OutputEnabled = true;
            //control.DecoderType = aacDecoderType;
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