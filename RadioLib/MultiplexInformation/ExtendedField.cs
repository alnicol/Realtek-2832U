using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public struct ExtendedField
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        byte serviceNumber;
        byte localTimeOffset;
        byte ensembleCountryCode;
        int serviceId;

        public bool IsValid
        {
            get { return isValid; }
        }

        public int ServiceId
        {
            get { return serviceId; }
        }

        public byte ServiceNumber
        {
            get { return serviceNumber; }
        }

        public byte LocalTimeOffset
        {
            get { return localTimeOffset; }
        }

        public byte CountryCode
        {
            get { return ensembleCountryCode; }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}