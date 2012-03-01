using System;
using System.Windows.Forms;
using RadioLib;

namespace RadioExample
{
    public partial class Form1 : Form
    {
        private FmRadioGraph fmRadioGraph;
        private FmRadio controller;

        private Interval currentInterval;
        private bool rdsEnabled = false;

        public Form1()
        {
            InitializeComponent();
            fmRadioGraph = new FmRadioGraph();
            controller = fmRadioGraph.RadioControl;
            SetCheckboxState();

            searchIntervalComboBox.SelectedIndex = 1;
            bandwidthDropdown.SelectedIndex = 0;
            controller.AudioSampleRate = SampleRate.High;
        }

        private void SetCheckboxState()
        {
            var quality = controller.QualityControl;
            if (quality.HasFlag(QualityControl.SoftMute))
                softMuteCheckBox.Checked = true;
            if (quality.HasFlag(QualityControl.HighCutControl))
                highCutCheckBox.Checked = true;
            if (quality.HasFlag(QualityControl.StereoBlend))
                blendCheckBox.Checked = true;
            if (quality.HasFlag(QualityControl.StereoSwitch))
                switchCheckBox.Checked = true;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            controller.Frequency = controller.Frequency;
            fmRadioGraph.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            fmRadioGraph.Stop();
        }

        private void deemphasisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.Deemphasis = deemphasisCheckBox.Checked ? Deemphasis.High : Deemphasis.Low;
        }

        private void softMuteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFlag(QualityControl.SoftMute, softMuteCheckBox.Checked);
        }

        private void blendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFlag(QualityControl.StereoBlend, blendCheckBox.Checked);
        }

        private void switchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFlag(QualityControl.StereoSwitch, switchCheckBox.Checked);
        }

        private void highCutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetFlag(QualityControl.HighCutControl, highCutCheckBox.Checked);
        }

        private void SetFlag(QualityControl flag, bool isChecked)
        {
            if (isChecked)
                controller.QualityControl = controller.QualityControl | flag;
            else
                controller.QualityControl = controller.QualityControl & ~flag;
        }

        private void scanForwards_Click(object sender, EventArgs e)
        {
            var currentFrequency = 87500; //controller.TunerRange.LowRange;
            if (frequencyTextBox.Text != string.Empty)
                currentFrequency = int.Parse(frequencyTextBox.Text) + (int) currentInterval;
            var result = controller.Scan(currentFrequency, currentInterval, Direction.Forwards, (uint)scanStopQuality.Value, (int)numberSearches.Value);
            if (result.HasValue)
            {
                frequencyTextBox.Text = result.Value.Frequency.ToString();
                signalQualityTextBox.Text = result.Value.Quality.ToString();
                controller.Frequency = result.Value.Frequency;
            }
            else
            {
                MessageBox.Show("Scan found no results.\r\nAdjust scan quality or number of searches.", "Scan Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scanBackwards_Click(object sender, EventArgs e)
        {
            var currentFrequency = 108000; //controller.TunerRange.HighRange;
            if (frequencyTextBox.Text != string.Empty)
                currentFrequency = int.Parse(frequencyTextBox.Text) + (int)currentInterval;
            var result = controller.Scan(currentFrequency, currentInterval, Direction.Backwards, (uint)scanStopQuality.Value, (int)numberSearches.Value);
            if (result.HasValue)
            {
                frequencyTextBox.Text = result.Value.Frequency.ToString();
                signalQualityTextBox.Text = result.Value.Quality.ToString();
                controller.Frequency = result.Value.Frequency;
            }
            else
            {
                MessageBox.Show("Scan found no results.\r\nAdjust scan quality or number of searches.", "Scan Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bandwidthDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandwidthDropdown.SelectedIndex == 0)
                controller.AudioSampleRate = SampleRate.High;
            else
                controller.AudioSampleRate = SampleRate.Low;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var information = controller.AudioInformation;
            sampleRateTextBox.Text = information.SampleRate.ToString();
            bitRateTextBox.Text = information.BitsPerSample.ToString();
            audioStereoCheckBox.Checked = information.IsStereo;

            isStereoCheckBox.Checked = controller.IsStereo;
            rdsSyncCheckBox.Checked = controller.RadioDataSync;
            signalLockCheckBox.Checked = controller.SignalLock;

            signalQualityTextBox.Text = controller.SignalQuality.ToString();
            rdsQualityTextBox.Text = controller.RadioDataQuality.ToString();

            UpdateRadioData();
            UpdateRange();
        }

        private void UpdateRange()
        {
            var range = controller.TunerRange;
            lowestFrequencyTextBox.Text = range.LowRange.ToString();
            highestFrequencyTextBox.Text = range.HighRange.ToString();
        }

        private void UpdateRadioData()
        {
            if (!rdsEnabled)
                return;

            controller.RadioData.Update();
            var radioData = controller.RadioData;
            firstAlternateFrequencyTextBox.Text = radioData.AlternateFrequency1;
            secondAlternateFrequencyTextBox.Text = radioData.AlternateFrequency2;
            artificalHeadCheckBox.Checked = radioData.ArtificalHead;
            compressedCheckBox.Checked = radioData.Compressed;
            musicCheckBox.Checked = radioData.IsMusic;
            rdsStereoCheckBox.Checked = radioData.IsStereo;
            programmeTextBox.Text = radioData.ProgrammeService;
            trafficInformationTextBox.Text = radioData.TrafficIndicator;
            typeTextBox.Text = radioData.Type.ToString();
            dynamicCheckBox.Checked = radioData.DynamicProgrammeType;

            var sync = controller.RadioDataControl;
            errorCorrectionCheckBox.Checked = sync.ErrorCorrection;
            errorThreshold.Text = sync.Threshold.ToString();
        }

        private void searchIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (searchIntervalComboBox.SelectedIndex)
            {
                case 0:
                    currentInterval = Interval.Fifty;
                    break;
                case 1:
                    currentInterval = Interval.Hundred;
                    break;
                case 2:
                    currentInterval = Interval.TwoHundred;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void setFrequencyButton_Click(object sender, EventArgs e)
        {
            int setFrequency;
            if (!int.TryParse(setFrequencyTextBox.Text, out setFrequency))
            {
                MessageBox.Show("Enter frequency in numerical form", "Unable to set frequency", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            controller.Frequency = setFrequency;
        }

        private void rdsButton_Click(object sender, EventArgs e)
        {
            rdsEnabled = true;
            controller.EnableRadioData = true;
        }

        private void updateRdsControl_Click(object sender, EventArgs e)
        {
            if (!rdsEnabled)
                return;
            var control = new RadioDataControl(errorCorrectionCheckBox.Checked, (uint) errorThreshold.Value);
            controller.RadioDataControl = control;
        }
    }
}
