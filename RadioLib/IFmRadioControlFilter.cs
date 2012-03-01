using System;
using System.Runtime.InteropServices;

namespace RadioLib
{
    [Guid("6c433cea-7f9c-40cc-a670-bacae16097b8"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IFmRadioControlFilter
    {
        [PreserveSig] FmResult NotImplemented(); //  Reserved for debug  
        [PreserveSig] FmResult SetAudioSampleRate([In] uint nSampleFreqHz);
        [PreserveSig] FmResult SetFrequency([In] int nFrequencyKHz);
        [PreserveSig] FmResult ScanNextProg([In] int nFrequencyKHz, [In] int nGridKHz, [In] byte cDirection, [In] int nSearchMaxNum, [Out] out int pnFreq, [Out] out int pnQuality);
        [PreserveSig] FmResult GetTunerRange([Out] out int pnLowRange, [Out] out int pnUpperRange); // This doesn't work, never sets out parameters
        [PreserveSig] FmResult GetSignalLock([Out] out int pnLock);
        [PreserveSig] FmResult GetSignalQuality([Out] out int pnQuality);
        [PreserveSig] FmResult GetPcmInfo([Out] out byte pnType, [Out] out uint pnSamplePerSec, [Out] out uint pnBitPerSample);
        [PreserveSig] FmResult SetDeemphasisTc([In] byte nType);
        [PreserveSig] FmResult GetSignalQualityCtr([Out] out uint pType);
        [PreserveSig] FmResult SetSignalQualityCtr([In] uint type);
        [PreserveSig] FmResult SetScanStopQuality([In] uint nQuality);
        [PreserveSig] FmResult GetRdsSync([Out] out int pnSync);
        [PreserveSig] FmResult SetRdsCtr([In] uint nControl);
        [PreserveSig] FmResult GetRdsCtr([Out] out uint pnControl);
        [PreserveSig] FmResult StartRds();
        [PreserveSig] FmResult StopRds();
        [PreserveSig] FmResult GetRdsQuality([Out] out int pnQuality);
        [PreserveSig] FmResult SetRdsDisplay(IntPtr buffer);
        [PreserveSig] FmResult EnableRdsDecoder();
        [PreserveSig] FmResult DisableRdsDecoder();
        [PreserveSig] FmResult GetMonoStereo([Out] out byte pnMonoStereo);
    }
}
