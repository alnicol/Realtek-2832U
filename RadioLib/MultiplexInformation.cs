using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RadioLib
{
    [StructLayout(LayoutKind.Sequential)]
    struct ExtendedField
    {
        byte flag;
        byte service;
        byte localTimeOffset;
        byte ensembleCountryCode;
        int serviceId;
    }

    [StructLayout(LayoutKind.Sequential)]
    class RadioDateTime
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
                if (!isValid)
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

    [StructLayout(LayoutKind.Sequential)]
    struct TimeOffset
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
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
    }

    [StructLayout(LayoutKind.Sequential)]
    struct ProgramIdentifier
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        ushort serviceId;
        ushort programNumber;
        [MarshalAs(UnmanagedType.U1)]
        bool continueFlag;
        [MarshalAs(UnmanagedType.U1)]
        bool updateFlag;
        ushort redirectedServiceId;
        ushort redirectedProgramTime;
        byte Type_0_Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        byte[] Data;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    class Service
    {
        [MarshalAs(UnmanagedType.U1)]
        bool programOrData;
        uint serviceId;
        byte serviceComponents;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] label;
        ushort charFlag;
        byte charset;
        ProgramIdentifier programNumber;
        ProgramType programType;
        AnnouncementSupport announcementSupport;
        public IntPtr pNextServiceNode;
        public IntPtr pNextStmAudNode;
        public IntPtr pNextStmDatNode;
        public IntPtr pNextFIDCNode;
        public IntPtr pNextSCNode;

        public string Label
        {
            get
            {
                if (!isLabelValid)
                    return string.Empty;

                return new string(label).Trim();
            }
        }

        public IEnumerable<ServiceComponent> ScNodes
        {
            get
            {
                if (this.pNextFIDCNode == IntPtr.Zero)
                    yield break;

                var component = (ServiceComponent)Marshal.PtrToStructure(this.pNextSCNode, typeof(ServiceComponent));
                yield return component;

                while (component.pNextSCNode != IntPtr.Zero)
                {
                    component = (ServiceComponent)Marshal.PtrToStructure(component.pNextSCNode, typeof(ServiceComponent));
                    yield return component;
                }
            }
        }

        public IEnumerable<FIdc> FIdcNodes
        {
            get
            {
                if (this.pNextFIDCNode == IntPtr.Zero)
                    yield break;

                var fIdc = (FIdc)Marshal.PtrToStructure(this.pNextFIDCNode, typeof(FIdc));
                yield return fIdc;

                while (fIdc.pNextFIDCNode != IntPtr.Zero)
                {
                    fIdc = (FIdc)Marshal.PtrToStructure(fIdc.pNextFIDCNode, typeof(FIdc));
                    yield return fIdc;
                }
            }
        }

        public IEnumerable<StreamModeAudio> AudioNodes
        {
            get
            {
                if (this.pNextStmAudNode == IntPtr.Zero)
                    yield break;

                var streamAudioMode = (StreamModeAudio)Marshal.PtrToStructure(this.pNextStmAudNode, typeof(StreamModeAudio));
                yield return streamAudioMode;

                while (streamAudioMode.pNextStmAudNode != IntPtr.Zero)
                {
                    streamAudioMode = (StreamModeAudio)Marshal.PtrToStructure(streamAudioMode.pNextStmAudNode, typeof(StreamModeAudio));
                    yield return streamAudioMode;
                }
            }
        }

        public IEnumerable<StreamModeData> DataNodes
        {
            get
            {
                if (this.pNextStmDatNode == IntPtr.Zero)
                    yield break;

                var streamDataNode = (StreamModeData)Marshal.PtrToStructure(this.pNextStmDatNode, typeof(StreamModeData));
                yield return streamDataNode;

                while (streamDataNode.pNextStmDatNode != IntPtr.Zero)
                {
                    streamDataNode = (StreamModeData)Marshal.PtrToStructure(streamDataNode.pNextStmDatNode, typeof(StreamModeData));
                    yield return streamDataNode;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct ProgramType
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
        byte Type_0_Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        byte[] Data; // no type0 header
    }

    [StructLayout(LayoutKind.Sequential)]
    struct AnnouncementSupport
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        ushort id;
        ushort asuFlags;
        byte clusterNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        byte[] clusterId;
        byte Type_0_Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        byte[] Data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        AnnouncementSwitch[] AnnSwitch;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct AnnouncementSwitch
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        byte clusterId;
        ushort aswFlags;
        [MarshalAs(UnmanagedType.U1)]
        bool isNew;
        byte regionFlag;
        byte subChId;
        byte regionIdLow;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    class Ensemble
    {
        ushort id;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private char[] label;
        ushort abbreviatedLabelFlag;
        byte characterSet;
        public IntPtr pEnsembleServiceHeader;
        RadioDateTime dateTime;
        TimeOffset countryLocalTimeOffset;

        public byte CharacterSet
        {
            get { return characterSet; }
        }

        public RadioDateTime DateTime
        {
            get { return dateTime; }
        }

        public TimeOffset TimeOffset
        {
            get { return countryLocalTimeOffset; }
        }

        public string Label
        {
            get
            {
                if (!isLabelValid)
                    return string.Empty;

                return new string(label).Trim();
            }
        }

        public string AbbreviatedLabel
        {
            get
            {
                if (!isLabelValid)
                    return string.Empty;

                var bits = new BitArray(BitConverter.GetBytes(abbreviatedLabelFlag));
                var builder = new StringBuilder();
                for (var i = bits.Length - 1; i >= 0; i--)
                {
                    if (bits[i])
                        builder.Append(label[bits.Length - i]);
                }
                return builder.ToString().Trim();
            }
        }

        public IEnumerable<Service> Services
        {
            get
            {
                var serviceHeader = (Service)Marshal.PtrToStructure(this.pEnsembleServiceHeader, typeof(Service));
                while (serviceHeader.pNextServiceNode != IntPtr.Zero)
                {
                    serviceHeader = (Service)Marshal.PtrToStructure(serviceHeader.pNextServiceNode, typeof(Service));
                    yield return serviceHeader;
                }
            }
        }
    }

    public enum AudioType : byte
    {
        ForegroundAudio = 0,
        BackgroundAudio = 1,
        MultichannelAudio = 2,
        AacAudio = 63
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct StreamModeAudio
    {
        public IntPtr pNextStmAudNode;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        string label;
        byte Language;
        ushort CharFlag;
        byte Charset;
        byte SCIdS;
        [MarshalAs(UnmanagedType.U1)]
        public AudioType ServiceType;
        public byte SubchannelId;
        [MarshalAs(UnmanagedType.U1)]
        bool isPrimary;
        byte CAFlag;
        public ushort FirstCapacityUnit;
        [MarshalAs(UnmanagedType.U1)]
        public bool EepEnabled;
        public byte EepIndex;
        public byte UepIndex;
        public ushort CapacityUnits;
        byte CAId;
        byte LocalFlag;
        byte UserAppNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] UserApp;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct UserApplication
    {
        ushort UserAppType;
        byte UserAppDataLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        byte[] data;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct StreamModeData
    {
        //StreamModeData* pNextStmDatNode;
        public IntPtr pNextStmDatNode;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        string label;
        byte Language;
        ushort CharFlag;
        byte Charset;
        byte SCIdS;
        byte DSCTy;
        byte SubChId;
        byte PS;
        byte CAFlag;
        ushort StartCU;
        byte UEPorEEP;
        byte EEPTabIdx;
        byte UEPTabIdx;
        ushort CUNum;
        byte CAId;
        byte LocalFlag;
        byte UserAppNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] UserApp;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct FIdc
    {
        //FIdc* pNextFIDCNode;
        public IntPtr pNextFIDCNode;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        string label;
        byte Language;
        ushort CharFlag;
        byte Charset;
        byte SCIdS;
        byte FIDCId;
        byte DSCTy;
        byte PS;
        byte CAFlag;
        byte CAId;
        byte LocalFlag;
        byte UserAppNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] UserApp;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct ServiceComponent
    {
        //ServiceComponent* pNextSCNode;
        public IntPtr pNextSCNode;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte[] ServiceComLabel;
        byte Language;
        short CharFlag;
        byte Charset;
        ushort SCId;
        byte SCIdS;
        byte SubChId;
        byte DSCTy;
        byte PS;
        byte CAFlag;
        ushort PacketAddr;
        ushort StartCU;
        byte UEPorEEP;
        byte EEPTabIdx;
        byte UEPTabIdx;
        ushort CUNum;
        byte FECScheme;
        byte FCAOrg;
        byte DG;
        ushort CAOrg;
        byte CAId;
        byte LocalFlag;
        byte UserAppNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] UserApp;
    } 
}
