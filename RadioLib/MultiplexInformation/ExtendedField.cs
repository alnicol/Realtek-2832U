using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public class ExtendedField : BaseData
    {
        byte serviceNumber;
        byte localTimeOffset;
        byte ensembleCountryCode;
        int serviceId;

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