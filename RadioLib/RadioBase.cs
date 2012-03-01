using System;
using System.Linq;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace RadioLib
{
    public class RadioBase
    {
        protected IMediaControl mediaControl;
        private bool disposed;
        protected IBaseFilter capFilter;
        protected IPin outputPin;

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
                var name = info.name;
                destPin.ConnectedTo(out pPin);

                if (pPin == null && pinDir == direction)
                    break;

                hr = iEnum.Next(1, pins, fetched);
                Marshal.ThrowExceptionForHR(hr);
            }
            Marshal.FreeCoTaskMem(fetched);
            return destPin;
        }

        public void Start()
        {
            var hr = mediaControl.Run();
            Marshal.ThrowExceptionForHR(hr);
        }

        public void Stop()
        {
            var hr = mediaControl.Stop();
            Marshal.ThrowExceptionForHR(hr);
        }

        public void Pause()
        {
            var hr = mediaControl.Pause();
            Marshal.ThrowExceptionForHR(hr);
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

            if (mediaControl != null)
            {
                mediaControl.Stop();
                Marshal.ReleaseComObject(mediaControl);
                mediaControl = null;
            }

            if (capFilter != null)
            {
                Marshal.ReleaseComObject(capFilter);
                capFilter = null;
            }

            if (outputPin != null)
            {
                Marshal.ReleaseComObject(outputPin);
                capFilter = null;
            }

            disposed = true;
        }
    }
}