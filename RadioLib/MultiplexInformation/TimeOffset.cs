using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public class TimeOffset : BaseData
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isProgram;
        [MarshalAs(UnmanagedType.U1)]
        bool extendedFieldPresent;
        [MarshalAs(UnmanagedType.U1)]
        bool localTimeUnique;
        byte ensembleOffset;
        byte ensembleCountryCode;
        byte internationalTableId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private ExtendedField[] extendedField;

        public byte InternationalTableId
        {
            get { return internationalTableId; }
        }

        public byte CountryCode
        {
            get { return ensembleCountryCode; }
        }

        public byte LocalTimeOffset
        {
            get { return ensembleOffset; }
        }

        public bool IsProgram
        {
            get { return isProgram; }
        }

        public bool SingleTimezone
        {
            get { return localTimeUnique; }
        }

        public IEnumerable<ExtendedField> ExtendedFields()
        {
            if (!extendedFieldPresent)
                yield break;

            for (var i = 0; i < 6; i++)
                yield return extendedField[i];
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}