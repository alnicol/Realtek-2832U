using System;

namespace RadioLib
{
    public enum FmResult
    {
        Fail = 0,
        Ok = 1,
        NotInitialised = 2
    }

    public enum SampleRate
    {
        Low,
        High
    }

    public enum Deemphasis
    {
        Low,
        High
    }

    public enum Direction
    {
        Backwards,
        Forwards
    }

    public enum Interval
    {
        Fifty = 50,
        Hundred = 100,
        TwoHundred = 200
    }

    [Flags]
    public enum QualityControl : uint
    {
        None = 0,
        SoftMute = 1,
        StereoBlend = 2,
        StereoSwitch = 4,
        HighCutControl = 8
    }

    public struct ScanResult
    {
        private readonly int frequency;
        private readonly int quality;

        public ScanResult(int frequency, int quality)
        {
            this.frequency = frequency;
            this.quality = quality;
        }

        public int Quality
        {
            get { return quality; }
        }

        public int Frequency
        {
            get { return frequency; }
        }
    }

    public class TunerRange
    {
        private readonly int lowRange;
        private readonly int highRange;

        public TunerRange(int lowRange, int highRange)
        {
            this.lowRange = lowRange;
            this.highRange = highRange;
        }

        public int HighRange
        {
            get { return highRange; }
        }

        public int LowRange
        {
            get { return lowRange; }
        }
    }

    public class AudioInformation
    {
        private readonly bool isStereo;
        private readonly uint sampleRate;
        private readonly uint bitsPerSample;

        public AudioInformation(bool isStereo, uint sampleRate, uint bitsPerSample)
        {
            this.isStereo = isStereo;
            this.sampleRate = sampleRate;
            this.bitsPerSample = bitsPerSample;
        }

        public uint BitsPerSample
        {
            get { return bitsPerSample; }
        }

        public uint SampleRate
        {
            get { return sampleRate; }
        }

        public bool IsStereo
        {
            get { return isStereo; }
        }
    }

    public class RadioDataControl
    {
        public bool ErrorCorrection { get; private set; }
        public uint Threshold { get; private set; }

        public RadioDataControl(bool errorCorrection, uint threshold)
        {
            ErrorCorrection = errorCorrection;
            Threshold = threshold;
        }

        public RadioDataControl(uint controlValue)
        {
            ErrorCorrection = (controlValue & 1) != 0;
            Threshold = (byte) (controlValue >> 1);
        }

        public uint ToUint()
        {
            uint controlValue = Threshold << 1;
            controlValue += ErrorCorrection ? (uint) 1 : 0;
            return controlValue;
        }
    }

    public class FrequencyBandwidth
    {
        public int Frequency { get; private set; }
        public int Bandwidth { get; private set; }

        public FrequencyBandwidth(int frequency, int bandwidth)
        {
            Frequency = frequency;
            Bandwidth = bandwidth;
        }
    }
}
