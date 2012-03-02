using System;

namespace RadioLib
{
    public class Splitter
    {
        private readonly ISplitterInterface splitter;

        public Splitter(ISplitterInterface splitter)
        {
            this.splitter = splitter;
        }

        public bool OutputEnabled
        {
            set { splitter.SetMode(value ? (uint) 1 : 0); }
        }

        public bool EnableTypeDetection
        {
            set { splitter.EnableTypeDetect(value ? (uint)1 : 0); }
        }

        public bool IsReady
        {
            get 
            { 
                uint result;
                splitter.GetDetectReady(out result);
                return result == 1;
            }
        }

        public AacDecoderType DecoderType
        {
            set { splitter.SetDecoder(value); }
        }
    }
}