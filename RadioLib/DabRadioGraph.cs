using System;
using System.Runtime.InteropServices;
using DirectShowLib;
using DirectShowLib.Utils;

namespace RadioLib
{
    public class DabRadioGraph : RadioBase
    {
        private IBaseFilter audioDecoder;

        public DabRadioGraph()
        {
            CreateFilterGraph();
        }

        private void CreateFilterGraph()
        {
            var filterGraph = (IFilterGraph2)new FilterGraph();
            var device = FindDeviceByName("RTKDABSourceFilter");
            
            capFilter = CreateFilterInstance(device);
            var hr = filterGraph.AddFilter(capFilter, "RTKDABSourceFilter");
            Marshal.ThrowExceptionForHR(hr);

            audioDecoder = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(CMpegAudioCodec).GUID, "AudioDecoder");
            Marshal.ThrowExceptionForHR(hr);

            mediaControl = filterGraph as IMediaControl;
        }

        public DabRadio RadioControl
        {
            get { return new DabRadio((IDabRadioControlFilter)capFilter); }
        }

        public void ConnectFilters()
        {
            var filterGraph = mediaControl as IFilterGraph2;

            outputPin = GetUnconnectedPin(capFilter, PinDirection.Output);
            if (outputPin == null)
                throw new NullReferenceException("Cannot find unconnected output pin");

            var inputPin = GetUnconnectedPin(audioDecoder, PinDirection.Input);
            if (inputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");

            var audioOutputPin = GetUnconnectedPin(audioDecoder, PinDirection.Output);
            if (audioOutputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");

            var hr = filterGraph.Connect(outputPin, inputPin);

            hr = filterGraph.Render(audioOutputPin);
            Marshal.ThrowExceptionForHR(hr);

            Marshal.ReleaseComObject(audioOutputPin);
            Marshal.ReleaseComObject(inputPin);
            Marshal.ThrowExceptionForHR(hr);
        }

        public void ReConnectFilters()
        {
        }
    }
}