using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation.Nodes
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class DataStreamNode : BaseNode
    {
        byte serviceComponentId;
        byte serviceType;
        byte subchannelId;
        [MarshalAs(UnmanagedType.U1)]
        bool isPrimary;
        [MarshalAs(UnmanagedType.U1)]
        bool usesAccessControl;
        ushort startCapacityUnit;
        [MarshalAs(UnmanagedType.U1)]
        bool equalErrorProtection;
        byte equalErrorIndex;
        byte unequalErrorIndex;
        ushort capacityUnitCount;
        byte conditionalAccessId;
        [MarshalAs(UnmanagedType.U1)]
        bool localFlag;
        byte userApplicationCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] userApplications;

        public override byte SubchannelId
        {
            get { return subchannelId; }
        }

        public ushort StartCapacityUnit
        {
            get { return startCapacityUnit; }
        }

        public ushort CapacityUnitCount
        {
            get { return capacityUnitCount; }
        }

        public DataType ServiceType
        {
            get
            {
                if (!Enum.IsDefined(typeof(DataType), serviceType))
                    return DataType.Unknown;
                return (DataType) serviceType;
            }
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

        public bool EqualErrorProtection
        {
            get { return equalErrorProtection; }
        }

        public byte ErrorProtectionIndex
        {
            get
            {
                if (EqualErrorProtection)
                    return equalErrorIndex;
                return unequalErrorIndex;
            }
        }

        public override BaseNode GetNext()
        {
            if (nextNode != IntPtr.Zero)
                return (DataStreamNode)Marshal.PtrToStructure(nextNode, typeof(DataStreamNode));
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