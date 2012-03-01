using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation.Nodes
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public abstract class BaseNode
    {
        protected IntPtr nextNode;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        char[] label;
        byte language;
        ushort abbreviatedLabelFlag;
        byte characterSet;

        public abstract BaseNode GetNext();
        public abstract bool IsLocal { get; }
        public abstract bool IsPrimary { get; }
        public abstract bool ConditionalAccess { get; }
        public abstract byte ConditionalAccessId { get; }
        public abstract byte ServiceComponentId { get; }
        public abstract byte SubchannelId { get; }
        public abstract IEnumerable<UserApplication> UserApplications();

        public byte Language
        {
            get { return language; }
        }

        public byte CharacterSet
        {
            get { return characterSet; }
        }

        public ushort CharacterFlag
        {
            get { return abbreviatedLabelFlag; }
        }

        public override string ToString()
        {
            return Label;
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
    }


    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}
