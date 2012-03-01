using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [Flags]
    public enum AnnouncementType
    {
        None = 0x0,
        Alarm = 0x1,
        RoadTraffic = 0x2,
        Transport = 0x4,
        Warning = 0x8,
        News = 0x10,
        Weather = 0x20,
        Event = 0x40,
        Special = 0x80,
        ProgrammeInformation = 0x100,
        FinanancialReport = 0x200,
        Reserved1 = 0x400,
        Reserved2 = 0x800,
        Reserved3 = 0x1000,
        Reserved4 = 0x2000,
        Reserved5 = 0x4000
    }

    [StructLayout(LayoutKind.Sequential)]
    public class AnnouncementSupport : BaseData
    {
        ushort serviceId;
        ushort announcementType;
        byte clusterIdCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        byte[] clusterId;
        byte type0Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        byte[] data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        AnnouncementSwitch[] announcementSwitch;

        public ushort ServiceId
        {
            get { return serviceId; }
        }

        public AnnouncementType AnnouncementType
        {
            get { return (AnnouncementType)announcementType; }
        }
        
        public IEnumerable<AnnouncementSwitch> AnnouncementSwitches
        {
            get
            {
                for (var i = 0; i < 23; i++)
                    yield return announcementSwitch[i];
            }
        }

        public IEnumerable<byte> ClusterIds
        {
            get
            {
                for (var i = 0; i < clusterIdCount; i++)
                    yield return clusterId[i];
            }
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