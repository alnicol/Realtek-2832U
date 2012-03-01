using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class Ensemble
    {
        ushort id;
        [MarshalAs(UnmanagedType.U1)]
        bool isLabelValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private char[] label;
        ushort abbreviatedLabelFlag;
        byte characterSet;
        public IntPtr pEnsembleServiceHeader;
        ExtendedDateTime dateTime;
        TimeOffset countryLocalTimeOffset;

        public ushort Identifier
        {
            get { return id; }
        }

        public byte CharacterSet
        {
            get { return characterSet; }
        }

        public ExtendedDateTime DateTime
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
                // The first Service node is always empty
                var serviceHeader = (Service)Marshal.PtrToStructure(pEnsembleServiceHeader, typeof(Service));
                while (serviceHeader.NextServiceNode != IntPtr.Zero)
                {
                    serviceHeader = (Service)Marshal.PtrToStructure(serviceHeader.NextServiceNode, typeof(Service));
                    yield return serviceHeader;
                }
            }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}