using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public class UserApplication
    {
        ushort userAppType;
        byte userAppDataLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        byte[] data;

        public ushort Type
        {
            get { return userAppType; }
        }

        public IEnumerable<byte> Data
        {
            get
            {
                for (var i = 0; i < userAppDataLength; i++)
                    yield return data[i];
            }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}