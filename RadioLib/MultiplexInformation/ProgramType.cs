using System;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public struct ProgramType
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        ushort serviceId;
        [MarshalAs(UnmanagedType.U1)]
        bool isStaticContent;
        [MarshalAs(UnmanagedType.U1)]
        bool isSecondary;
        [MarshalAs(UnmanagedType.U1)]
        bool languageFlagPresent;
        [MarshalAs(UnmanagedType.U1)]
        bool complementaryFlagPresent;
        byte language;
        byte intCode;
        byte compCode;
        byte type0Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        byte[] data; // no type0 header

        public bool IsValid
        {
            get { return isValid; }
        }

        public ushort ServiceId
        {
            get { return serviceId; }
        }

        public bool IsStaticContent
        {
            get { return isStaticContent; }
        }

        public bool Primary
        {
            get { return !isSecondary; }
        }

        public bool ComplementaryFlagPresent
        {
            get { return complementaryFlagPresent; }
        }

        public Language Language
        {
            get
            {
                if (!languageFlagPresent || !Enum.IsDefined(typeof(Language), language))
                    return Language.Unknown;
                return (Language) language;
            }
        }

        public byte BasicProgramType
        {
            get { return intCode; }
        }

        public byte ComplementaryProgramType
        {
            get { return compCode; }
        }

        public byte Type0Header
        {
            get { return type0Header; }
        }

        public byte[] RawData
        {
            get { return data; }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}