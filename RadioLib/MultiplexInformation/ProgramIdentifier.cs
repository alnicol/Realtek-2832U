using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public class ProgramIdentifier : BaseData
    {
        ushort serviceId;
        ushort programNumber;
        [MarshalAs(UnmanagedType.U1)]
        bool continueFlag;
        [MarshalAs(UnmanagedType.U1)]
        bool updateFlag;
        ushort redirectedServiceId;
        ushort redirectedProgramTime;
        byte type0Header;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        byte[] data;

        public ushort ServiceId
        {
            get { return serviceId; }
        }

        public ushort ProgramStartTime
        {
            get { return programNumber; }
        }

        public bool HasPlannedInterruption
        {
            get { return continueFlag; }
        }

        public bool HasRedirection
        {
            get { return updateFlag; }
        }

        public ushort RedirectedServiceIdentifier
        {
            get { return redirectedServiceId; }
        }

        public ushort RedirectedProgramStartTime
        {
            get { return redirectedProgramTime; }
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