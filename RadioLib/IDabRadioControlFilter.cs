using System;
using System.Runtime.InteropServices;

namespace RadioLib
{
    [Guid("526d677f-490c-4980-96fd-5ec8a3f126da"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IDabRadioControlFilter
    {
        [PreserveSig] FmResult SetRingBuffer(); //  Reserved for debug  
        [PreserveSig] FmResult GetFrameNumber([Out] out uint frameNumber); //  Reserved for debug  
        [PreserveSig] FmResult SetFrameNumber([In] uint frameNumber); //  Reserved for debug  
        [PreserveSig] FmResult SetFileEndCallback(); //  Reserved for debug  
        [PreserveSig] FmResult SetMediaMode([In] byte mediaMode); //  Reserved for debug  
        [PreserveSig] FmResult SetFicParseCounter([In] ref short counter);    
        [PreserveSig] FmResult SetFicParseTimeout([In] ref short timeout);  
        [PreserveSig] FmResult StopFicParse();
        [PreserveSig] FmResult StartFicParse();
        [PreserveSig] FmResult GetMultiplexInformation([Out] out IntPtr ensembleData);
        [PreserveSig] FmResult SetFrequencyAndBandwidth([In] int nFrequency, [In] int nBandwidth);
        [PreserveSig] FmResult GetSignalLock([Out] out int pnLock);
        [PreserveSig] FmResult AddService(char mode, char SubChId, short StartCU, char UEP_EEP, char UEPTabldx, char EEPIdx, short CUNum, short PacketAddr, char FECScheme);
        [PreserveSig] FmResult DeleteService(char mode, char SubChId, short PacketAddr);
        [PreserveSig] FmResult StartSaveStream(); // Reserved for debug   
        [PreserveSig] FmResult StopSaveStream(); // Reserved for debug   
        [PreserveSig] FmResult GetSignalQuality([Out] out int pnQuality);
        [PreserveSig] FmResult GetFrequencyAndBandwidth([Out] out int nFrequency, [Out] out int nBandwidth);
        [PreserveSig] FmResult SetMedia(); // Reserved for debug   
        [PreserveSig] FmResult SetFirecode(byte bFirecodeMux);
        [PreserveSig] FmResult GetCaptureResult(); // Reserved for debug   
        [PreserveSig] FmResult StartCaptureHeader(); // Reserved for debug   
        [PreserveSig] FmResult QueryConnect();
    }
}