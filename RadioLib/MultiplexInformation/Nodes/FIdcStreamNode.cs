using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation.Nodes
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class FIdcStreamNode : BaseNode
    {
        byte serviceComponentId;
        byte subchannelId;
        byte serviceType;
        [MarshalAs(UnmanagedType.U1)]
        bool isPrimary;
        [MarshalAs(UnmanagedType.U1)]
        bool usesAccessControl;
        byte conditionalAccessId;
        [MarshalAs(UnmanagedType.U1)]
        bool localFlag;
        byte userApplicationCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] userApplications;

        public DataType ServiceType
        {
            get
            {
                if (!Enum.IsDefined(typeof(DataType), serviceType))
                    return DataType.Unknown;
                return (DataType)serviceType;
            }
        }

        public override byte SubchannelId
        {
            get { return subchannelId; }
        }

        public override byte ServiceComponentId
        {
            get { return serviceComponentId; }
        }

        public override bool ConditionalAccess
        {
            get { return usesAccessControl; }
        }

        public override byte ConditionalAccessId
        {
            get { return conditionalAccessId; }
        }

        public override bool IsLocal
        {
            get { return localFlag; }
        }

        public override bool IsPrimary
        {
            get { return isPrimary; }
        }

        public override BaseNode GetNext()
        {
            if (nextNode != IntPtr.Zero)
                return (PacketStreamNode)Marshal.PtrToStructure(nextNode, typeof(FIdcStreamNode));
            return null;
        }

        public override IEnumerable<UserApplication> UserApplications()
        {
            for (var i = 0; i < userApplicationCount; i++)
                yield return userApplications[i];
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}