using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadioLib.MultiplexInformation
{
    public enum AudioType : byte
    {
        ForegroundAudio = 0,
        BackgroundAudio = 1,
        MultichannelAudio = 2,
        AacAudio = 63,
        Unknown = 255
    }

    public enum DataType : byte
    {
        Unspecified = 0,
        TrafficMessageChannel = 1,
        EmergencyWarning = 2,
        InteractiveTextTransmission = 3,
        Paging = 4,
        TransparentDataChannel = 5,
        MpegTransportStream = 24,
        EmbeddedIpPacket = 59,
        MultimediaObjectTransfer = 60,
        ProprietaryService = 61,
        Unknown = 255
    }
}
