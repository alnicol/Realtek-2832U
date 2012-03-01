using System;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // Does not apply to North America. Would be better coming from an XML file
    public enum BasicProgramType : byte
    {
        None = 0,
        News = 1,
        CurrentAffairs = 2,
        Information = 3,
        Sport = 4,
        Education = 5,
        Drama = 6,
        Culture = 7,
        Science = 8,
        Varied = 9,
        PopMusic = 10,
        RockMusic = 11,
        EasyListeningMusic = 12,
        LightClassical = 13,
        SeriousClassical = 14,
        OtherMusic = 15,
        Weather = 16,
        FinanceBusiness = 17,
        Childrens = 18,
        SocialAffairs = 19,
        Religion = 20,
        PhoneIn = 21,
        Travel = 22,
        Leisure = 23,
        JazzMusic = 24,
        CountryMusic = 25,
        NationalMusic = 26,
        OldiesMusic = 27,
        FolkMusic = 28,
        Documentary = 29
    }

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

        public BasicProgramType BasicProgramType
        {
            get
            {
                if (!Enum.IsDefined(typeof(BasicProgramType), intCode))
                    return BasicProgramType.None;
                return (BasicProgramType)intCode;
            }
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