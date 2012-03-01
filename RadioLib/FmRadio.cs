using System.Runtime.InteropServices;

namespace RadioLib
{
    public class FmRadio
    {
        [DllImport("RTKFM.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RTFM_GetTunerRange")]
        public static extern int GetTunerRange(out int pnLowRange, out int pnUpperRange);

        private readonly IFmRadioControlFilter filterInterface;
        private readonly RadioDataSystem rds; // Need to dispose of this

        public FmRadio(IFmRadioControlFilter filterInterface)
        {
            this.filterInterface = filterInterface;
            rds = new RadioDataSystem();
            this.filterInterface.SetRdsDisplay(rds.NativeBuffer);
        }

        public SampleRate AudioSampleRate
        {
            set { filterInterface.SetAudioSampleRate(value == SampleRate.Low ? (uint)32000 : 48000); }
        }

        public int Frequency
        {
            set { filterInterface.SetFrequency(value); }
        }

        public bool SignalLock
        {
            get
            {
                int outValue;
                filterInterface.GetSignalLock(out outValue);
                return outValue == 1;
            }
        }

        public int SignalQuality
        {
            get
            {
                int outValue;
                filterInterface.GetSignalQuality(out outValue);
                return outValue;
            }
        }

        public Deemphasis Deemphasis
        {
            set { filterInterface.SetDeemphasisTc(value == Deemphasis.Low ? (byte)50 : (byte)75); }
        }

        public QualityControl QualityControl
        {
            get
            {
                uint outValue;
                filterInterface.GetSignalQualityCtr(out outValue);
                return (QualityControl) outValue;
            }
            set
            {
                filterInterface.SetSignalQualityCtr((uint)value);
            }
        }

        public int RadioDataQuality
        {
            get
            {
                int outValue;
                filterInterface.GetRdsQuality(out outValue);
                return outValue;
            }
        }

        public bool IsStereo
        {
            get
            {
                byte outValue;
                filterInterface.GetMonoStereo(out outValue);
                return outValue == 1;
            }
        }

        public bool RadioDataSync
        {
            get
            {
                int outValue;
                filterInterface.GetRdsSync(out outValue);
                return outValue == 1;
            }
        }

        public AudioInformation AudioInformation
        {
            get
            {
                byte type;
                uint samples, bitsPerSample;
                filterInterface.GetPcmInfo(out type, out samples, out bitsPerSample);
                return new AudioInformation(type == 2, samples, bitsPerSample);
            }
        }

        public ScanResult? Scan(int startFrequency, Interval interval, Direction direction, uint quality, int maxSearch)
        {
            filterInterface.SetScanStopQuality(quality);
            int frequency, actualQuality;
            var bDirection = direction == Direction.Backwards ? ((byte) 0) : ((byte) 1);
            filterInterface.ScanNextProg(startFrequency, (int)interval, bDirection, maxSearch, out frequency, out actualQuality);
            if (frequency == 0 && actualQuality == 0)
                return null;
            return new ScanResult(frequency, actualQuality);
        }

        public TunerRange TunerRange
        {
            get
            {
                int lowRange, highRange;
                GetTunerRange(out lowRange, out highRange);
                return new TunerRange(lowRange, highRange);
            }
        }

        public RadioDataControl RadioDataControl
        {
            get
            {
                uint outValue;
                filterInterface.GetRdsCtr(out outValue);
                return new RadioDataControl(outValue);
            }
            set
            {
                filterInterface.SetRdsCtr(value.ToUint());
            }
        }

        public RadioDataSystem RadioData
        {
            get { return rds; }
        }

        public bool EnableRadioData
        {
            set
            {
                if (value)
                {
                    filterInterface.EnableRdsDecoder();
                    filterInterface.StartRds();
                }
                else
                {
                    filterInterface.StopRds();
                    filterInterface.DisableRdsDecoder();
                }
            }
        }
    }
}