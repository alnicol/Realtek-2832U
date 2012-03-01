using System;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public struct ExtendedDateTime
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        int modifiedJulianDate;
        [MarshalAs(UnmanagedType.U1)]
        bool currentDateHasLeapSecond;
        [MarshalAs(UnmanagedType.U1)]
        bool isAccurate;
        [MarshalAs(UnmanagedType.U1)]
        bool hasSeconds;
        byte hours;
        byte minutes;
        byte seconds;
        int milliseconds;

        public bool IsValid
        {
            get { return isValid; }
        }

        public bool DayHasLeapSecond
        {
            get { return currentDateHasLeapSecond; }
        }

        public bool IsAccurate
        {
            get { return isAccurate; }
        }

        public DateTime Time
        {
            get
            {
                if (!IsValid)
                    return DateTime.MinValue;

                var date = new DateTime(1858, 11, 17, hours, minutes, 0, 0, DateTimeKind.Utc).AddDays(modifiedJulianDate);
                if (hasSeconds)
                {
                    date = date.AddSeconds(seconds);
                    date = date.AddMilliseconds(milliseconds);
                }
                return date;
            }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}