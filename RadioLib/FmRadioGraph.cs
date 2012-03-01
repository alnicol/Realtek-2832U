using System;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace RadioLib
{
    public class FmRadioGraph : RadioBase, IDisposable
    {
        public FmRadioGraph()
        {
            CreateFilterGraph();
        }

        private void CreateFilterGraph()
        {
            var filterGraph = (IFilterGraph2) new FilterGraph();
            var device = FindDeviceByName("RTKFMSourceFilter");

            capFilter = CreateFilterInstance(device);
            var hr = filterGraph.AddFilter(capFilter, "RTKFMSourceFilter");
            Marshal.ThrowExceptionForHR(hr);

            outputPin = GetUnconnectedPin(capFilter, PinDirection.Output);
            if (outputPin == null)
                throw new NullReferenceException("Cannot find unconnected output pin");

            hr = filterGraph.Render(outputPin);
            Marshal.ThrowExceptionForHR(hr);

            mediaControl = filterGraph as IMediaControl;
        }

        public FmRadio RadioControl
        {
            get { return new FmRadio((IFmRadioControlFilter)capFilter); }
        }
    }
}