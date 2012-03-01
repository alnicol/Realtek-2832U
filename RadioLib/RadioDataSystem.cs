using System;
using System.Runtime.InteropServices;

namespace RadioLib
{
    public class RadioDataSystem
    {
        private readonly IntPtr nativeMemoryBuffer;
        private RdsDataStruct latestData;

        public RadioDataSystem()
        {
            nativeMemoryBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RdsDataStruct)));
            latestData = new RdsDataStruct();
        }

        public char Type
        {
            get { return (char) ('A' - 1 + latestData.Type0A_0B); }
        }

        public string ProgrammeService
        {
            get
            {
                var result = ByteArrayToString(latestData.PSName);
                if (result.Length >= 8)
                    return result.Substring(0, 8);
                return string.Empty;
            }
        }

        public bool IsMusic
        {
            get { return ByteArrayToString(latestData.MsName) == "Music"; }
        }

        public bool IsStereo
        {
            get { return ByteArrayToString(latestData.B0Name) == "Stereo"; }
        }

        public bool ArtificalHead
        {
            get { return ByteArrayToString(latestData.B1Name) != "Not Artificial Head"; }
        }

        public bool Compressed
        {
            get { return ByteArrayToString(latestData.B2Name) != "Not Compressed"; }
        }

        public bool DynamicProgrammeType
        {
            get { return ByteArrayToString(latestData.B3Name) == "Dynamic PTY"; }
        }

        public string TrafficIndicator
        {
            get { return ByteArrayToString(latestData.TATPName); }
        }

        public string AlternateFrequency1
        {
            get { return Convert.ToString(latestData.afreq); }
        }

        public string AlternateFrequency2
        {
            get { return Convert.ToString(latestData.afreq2); }
        }

        public void Update()
        {
            latestData = (RdsDataStruct)Marshal.PtrToStructure(nativeMemoryBuffer, typeof(RdsDataStruct));
        }

        private static string ByteArrayToString(byte[] data)
        {
            var enc = new System.Text.ASCIIEncoding();
            var text =  enc.GetString(data).Trim('\0');
            return text;
        }

        public IntPtr NativeBuffer
        {
            get { return nativeMemoryBuffer; }
        }

        [StructLayout(LayoutKind.Sequential)]
        private class RdsDataStruct
        {
            public byte Type0A_0B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] PSName = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] B3Name = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] B2Name = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] B1Name = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] B0Name = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)] public readonly byte[] MsName = new byte[25];
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)] public readonly byte[] TATPName = new byte[40];
            public float afreq;
            public float afreq2;
        }
    }
}