using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RadioLib
{
    [Guid("604733ae-848c-49cc-a27f-d5b558828eec"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface ISplitterInterface
    {
        [PreserveSig] FmResult SetMode(uint mode);
        [PreserveSig] FmResult EnableTypeDetect(uint flush);
        [PreserveSig] FmResult GetDetectReady([Out] out uint ready);
        [PreserveSig] FmResult SetDecoder([MarshalAs(UnmanagedType.U4)] AacDecoderType decoder);
    }
}
