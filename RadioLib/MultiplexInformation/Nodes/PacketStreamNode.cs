using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation.Nodes
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class PacketStreamNode : BaseNode
    {
        ushort ensembleComponentId;
        byte serviceComponentId;
        byte subchannelId;
        byte serviceType;
        [MarshalAs(UnmanagedType.U1)]
        bool isPrimary;
        [MarshalAs(UnmanagedType.U1)]
        bool usesAccessControl;
        ushort packetAddress;
        ushort startCapacityUnit;
        [MarshalAs(UnmanagedType.U1)]
        bool equalErrorProtection;
        public byte equalErrorIndex;
        public byte unequalErrorIndex;
        ushort capacityUnitCount;
        byte errorCorrectionScheme;
        [MarshalAs(UnmanagedType.U1)]
        bool hasAccessOrganisation;
        [MarshalAs(UnmanagedType.U1)]
        bool noDataGroups;
        ushort accessOrganisation;
        byte conditionalAccessId;
        [MarshalAs(UnmanagedType.U1)]
        bool localFlag;
        byte userApplicationCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        UserApplication[] userApplications;

        public ushort EnsembleComponentId
        {
            get { return ensembleComponentId; }
        }

        public ushort PacketAddress
        {
            get { return packetAddress; }
        }

        public bool UsesDataGroups
        {
            get { return !noDataGroups; }
        }

        public bool HasAccessOrganisation
        {
            get { return hasAccessOrganisation; }
        }

        public ushort AccessOrganisation
        {
            get { return accessOrganisation; }
        }

        public byte ErrorCorrectionScheme
        {
            get { return errorCorrectionScheme; }
        }

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
                return (DataType)serviceType;
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
                return (PacketStreamNode)Marshal.PtrToStructure(nextNode, typeof(PacketStreamNode));
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