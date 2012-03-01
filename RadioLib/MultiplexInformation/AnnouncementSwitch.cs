using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public struct AnnouncementSwitch
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;
        byte clusterId;
        ushort aswFlags;
        [MarshalAs(UnmanagedType.U1)]
        bool isNew;
        byte regionFlag;
        byte subchannelId;
        byte regionIdLow;

        public bool IsValid
        {
            get { return isValid; }
        }

        public byte ClusterId
        {
            get { return clusterId; }
        }

        public ushort Flags
        {
            get { return aswFlags; }
        }

        public bool IsNew
        {
            get { return isNew; }
        }

        public byte SubchannelId
        {
            get { return subchannelId; }
        }

        public byte RegionFlag
        {
            get { return regionFlag; }
        }

        public byte RegionIdLower
        {
            get { return regionIdLow; }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}