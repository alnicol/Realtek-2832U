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
    public struct Ensemble
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

        public string ShortLabel
        {
            get
            {
                if (!isLabelValid)
                    return string.Empty;

                return Helpers.GetAbbreviatedLabel(Label, abbreviatedLabelFlag);
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

        public static Ensemble FromIntPtr(IntPtr data)
        {
            return (Ensemble)Marshal.PtrToStructure(data, typeof(Ensemble));
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}