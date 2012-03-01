using System;
using System.Runtime.InteropServices;
using DirectShowLib;
using DirectShowLib.Utils;

namespace RadioLib
{
    public class FmRadioGraph : RadioBase, IDisposable
    {
        protected override bool BuildGraph()
        {
            renderer = FilterGraphTools.AddFilterFromClsid(filterGraph, typeof(DSoundRender).GUID, "Renderer");

            sourceOutputPin = GetUnconnectedPin(source, PinDirection.Output);
            if (sourceOutputPin == null)
                throw new NullReferenceException("Cannot find unconnected output pin");

            renderInputPin = GetUnconnectedPin(renderer, PinDirection.Input);
            if (renderInputPin == null)
                throw new NullReferenceException("Cannot find unconnected input pin");

            graphBuilt = true;
            return true;
        }

        public FmRadio RadioControl
        {
            get { return new FmRadio((IFmRadioControlFilter)source); }
        }

        protected override void ConnectPins()
        {
            FilterGraphTools.ConnectFilters(filterGraph, sourceOutputPin, renderInputPin, true);
        }

        protected override string SourceFilterName
        {
            get { return "RTKFMSourceFilter"; }
        }

        protected override void DisconnectPins()
        {
            var hr = filterGraph.Disconnect(sourceOutputPin);
            Marshal.ThrowExceptionForHR(hr);

            hr = filterGraph.Disconnect(renderInputPin);
            Marshal.ThrowExceptionForHR(hr);
        }

    }
}