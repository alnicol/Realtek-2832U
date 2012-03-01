using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RadioLib.MultiplexInformation.Nodes;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Service
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isData;
        uint serviceId;
        byte serviceComponentCount;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] label;
        ushort abbreviatedLabelFlag;
        byte charset;
        ProgramIdentifier programNumber;
        ProgramType programType;
        AnnouncementSupport announcementSupport;
        public IntPtr NextServiceNode;
        public IntPtr NextAudioStreamNode;
        public IntPtr NextDataStreamNode;
        public IntPtr NextFIDCNode;
        public IntPtr NextSCNode;

        public override string ToString()
        {
            return Label;
        }

        public bool IsData
        {
            get { return isData; }
        }

        public uint ServiceId
        {
            get { return serviceId; }
        }

        public byte ServiceComponentCount
        {
            get { return serviceComponentCount; }
        }

        public string ShortLabel
        {
            get
            {
                if (!isLabelValid)
                    return string.Empty;

                return Helpers.GetAbbreviatedLabel(Label, abbreviatedLabelFlag);
            }
        }

        public byte Charset
        {
            get { return charset; }
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

        public ProgramIdentifier ProgramIdentifier
        {
            get { return programNumber; }
        }

        public ProgramType ProgramType
        {
            get { return programType; }
        }

        public AnnouncementSupport AnnouncementSupport
        {
            get { return announcementSupport; }
        }

        public IEnumerable<PacketStreamNode> ScNodes
        {
            get
            {
                if (NextSCNode == IntPtr.Zero)
                    yield break;

                var component = (PacketStreamNode)Marshal.PtrToStructure(NextSCNode, typeof(PacketStreamNode));
                while (component.Next != IntPtr.Zero)
                {
                    yield return component;
                    component = (PacketStreamNode)Marshal.PtrToStructure(NextSCNode, typeof(PacketStreamNode));
                }
                yield return component;
            }
        }

        public IEnumerable<FIdcStreamNode> FIdcNodes
        {
            get
            {
                if (NextFIDCNode == IntPtr.Zero)
                    yield break;

                var component = (FIdcStreamNode)Marshal.PtrToStructure(NextFIDCNode, typeof(FIdcStreamNode));
                while (component.Next != IntPtr.Zero)
                {
                    yield return component;
                    component = (FIdcStreamNode)Marshal.PtrToStructure(NextFIDCNode, typeof(FIdcStreamNode));
                }
                yield return component;
            }
        }

        public IEnumerable<AudioStreamNode> AudioNodes
        {
            get
            {
                if (NextAudioStreamNode == IntPtr.Zero)
                    yield break;

                var component = (AudioStreamNode)Marshal.PtrToStructure(NextAudioStreamNode, typeof(AudioStreamNode));
                while (component.Next != IntPtr.Zero)
                {
                    yield return component;
                    component = (AudioStreamNode)Marshal.PtrToStructure(NextAudioStreamNode, typeof(AudioStreamNode));
                }
                yield return component;
            }
        }

        public IEnumerable<DataStreamNode> DataNodes
        {
            get
            {
                if (NextDataStreamNode == IntPtr.Zero)
                    yield break;

                var component = (DataStreamNode)Marshal.PtrToStructure(NextDataStreamNode, typeof(DataStreamNode));
                while (component.Next != IntPtr.Zero)
                {
                    yield return component;
                    component = (DataStreamNode)Marshal.PtrToStructure(NextDataStreamNode, typeof(DataStreamNode));
                }
                yield return component;
            }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}