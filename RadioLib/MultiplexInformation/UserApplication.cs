using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    public enum UserApplicationType : ushort
    {
        Reserved = 0x0,
        NotUsed = 0x1,
        Slideshow = 0x2,
        BroadcastWebsite = 0x3,
        Tpeg = 0x4,
        Dgps = 0x5,
        Tmc = 0x6,
        Epg = 0x7,
        Java = 0x8,
        Dmb = 0x9,
        Ipdc = 0xa,
        Voice = 0xb,
        Middleware = 0xc,
        Journaline = 0x44a,
        Unknown = 0x8000
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UserApplication
    {
        ushort userAppType;
        byte userAppDataLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        byte[] data;

        public UserApplicationType Type
        {
            get
            {
                if (!Enum.IsDefined(typeof(UserApplicationType), userAppType))
                    return UserApplicationType.Unknown;
                return (UserApplicationType)userAppType;
            }
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