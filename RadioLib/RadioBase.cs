using System;
using System.Linq;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace RadioLib
{
    public abstract class RadioBase
    {
        protected bool disposed;

        protected IFilterGraph2 filterGraph;
        protected IBaseFilter source;
        protected IBaseFilter renderer;
        protected IPin sourceOutputPin;
        protected IPin renderInputPin;
        protected bool graphBuilt;
        protected bool graphRunning;
        protected bool pinsConnected;

        protected abstract string SourceFilterName { get; }
        protected abstract void DisconnectPins();
        protected abstract void ConnectPins();
        protected abstract bool BuildGraph();

        protected RadioBase()
        {
            filterGraph = (IFilterGraph2)new FilterGraph();
            AddSourceFilter();
        }

        protected IMediaControl MediaControl
        {
            get { return filterGraph as IMediaControl; }
        }

        protected bool AddSourceFilter()
        {
            if (filterGraph == null)
                return false;

            var device = FindDeviceByName(SourceFilterName);
            if (device == null)
                throw new NullReferenceException("Unable to find source filter");

            source = CreateFilterInstance(device);
            var hr = filterGraph.AddFilter(source, SourceFilterName);
            Marshal.ThrowExceptionForHR(hr);

            return true;
        }

        protected DsDevice FindDeviceByName(string name)
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.LegacyAmFilterCategory);
            return devices.FirstOrDefault(device => device.GetPropBagValue("FriendlyName") == name);
        }

        protected IBaseFilter CreateFilterInstance(DsDevice device)
        {
            var guid = typeof(IBaseFilter).GUID;
            object objFilter;
            device.Mon.BindToObject(null, null, ref guid, out objFilter);
            if (objFilter == null)
                throw new NullReferenceException("Cannot bind to filter");
            return (IBaseFilter)objFilter;
        }

        protected IPin GetUnconnectedPin(IBaseFilter filter, PinDirection direction)
        {
            IPin destPin = null;
            IEnumPins iEnum;
            var pins = new IPin[1];

            var hr = filter.EnumPins(out iEnum);
            Marshal.ThrowExceptionForHR(hr);

            var fetched = Marshal.AllocCoTaskMem(4);
            hr = iEnum.Next(1, pins, fetched);
            Marshal.ThrowExceptionForHR(hr);

            while (Marshal.ReadInt32(fetched) == 1)
            {
                PinDirection pinDir;
                IPin pPin;
                destPin = pins[0];

                hr = destPin.QueryDirection(out pinDir);
                Marshal.ThrowExceptionForHR(hr);

                PinInfo info;
                destPin.QueryPinInfo(out info);
                //var name = info.name;
                destPin.ConnectedTo(out pPin);

                if (pPin == null && pinDir == direction)
                    break;

                hr = iEnum.Next(1, pins, fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.FreeCoTaskMem(fetched);
            return destPin;
        }

        public bool Play()
        {
            if (!graphBuilt)
            {
                var result = BuildGraph();
                if (!result)
                    return false;
            }

            if (!pinsConnected)
            {
                ConnectPins();
                pinsConnected = true;
            }

            var hr = MediaControl.Run();
            Marshal.ThrowExceptionForHR(hr);
            graphRunning = true;
            return true;
        }

        private bool Pause()
        {
            if (!graphBuilt)
                return false;

            if (!graphRunning)
                return true;

            var hr = MediaControl.Pause();
            Marshal.ThrowExceptionForHR(hr);
            return true;
        }

        public bool Stop()
        {
            if (!graphBuilt)
                return false;

            if (!graphRunning)
                return true;

            var hr = MediaControl.Stop();
            Marshal.ThrowExceptionForHR(hr);
            graphRunning = false;

            if (pinsConnected)
                DisconnectPins();

            pinsConnected = false;
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Dispose managed resources.
            }

            if (filterGraph != null)
            {
                MediaControl.Stop();
                Marshal.ReleaseComObject(filterGraph);
                filterGraph = null;
            }

            if (sourceOutputPin != null)
            {
                Marshal.ReleaseComObject(sourceOutputPin);
                sourceOutputPin = null;
            }

            if (renderInputPin != null)
            {
                Marshal.ReleaseComObject(renderInputPin);
                renderInputPin = null;
            }

            if (source != null)
            {
                Marshal.ReleaseComObject(source);
                source = null;
            }

            if (renderer != null)
            {
                Marshal.ReleaseComObject(renderer);
                renderer = null;
            }

            disposed = true;
        }
    }
}