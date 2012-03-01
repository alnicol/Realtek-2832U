namespace RadioExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scanStopQuality = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.bandwidthDropdown = new System.Windows.Forms.ComboBox();
            this.scanBackwards = new System.Windows.Forms.Button();
            this.scanForwards = new System.Windows.Forms.Button();
            this.softMuteCheckBox = new System.Windows.Forms.CheckBox();
            this.blendCheckBox = new System.Windows.Forms.CheckBox();
            this.switchCheckBox = new System.Windows.Forms.CheckBox();
            this.deemphasisCheckBox = new System.Windows.Forms.CheckBox();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.highCutCheckBox = new System.Windows.Forms.CheckBox();
            this.signalLockCheckBox = new System.Windows.Forms.CheckBox();
            this.signalQualityTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdsQualityTextBox = new System.Windows.Forms.TextBox();
            this.isStereoCheckBox = new System.Windows.Forms.CheckBox();
            this.rdsSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.audioStereoCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sampleRateTextBox = new System.Windows.Forms.TextBox();
            this.bitRateTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numberSearches = new System.Windows.Forms.NumericUpDown();
            this.searchIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.firstAlternateFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.secondAlternateFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.programmeTextBox = new System.Windows.Forms.TextBox();
            this.trafficInformationTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.artificalHeadCheckBox = new System.Windows.Forms.CheckBox();
            this.compressedCheckBox = new System.Windows.Forms.CheckBox();
            this.musicCheckBox = new System.Windows.Forms.CheckBox();
            this.rdsStereoCheckBox = new System.Windows.Forms.CheckBox();
            this.dynamicCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.setFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.setFrequencyButton = new System.Windows.Forms.Button();
            this.lowestFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.highestFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rdsButton = new System.Windows.Forms.Button();
            this.errorCorrectionCheckBox = new System.Windows.Forms.CheckBox();
            this.errorThreshold = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.updateRdsControl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scanStopQuality)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSearches)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Frequency";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(164, 6);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.ReadOnly = true;
            this.frequencyTextBox.Size = new System.Drawing.Size(141, 20);
            this.frequencyTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scan Stop Quality";
            // 
            // scanStopQuality
            // 
            this.scanStopQuality.Location = new System.Drawing.Point(164, 34);
            this.scanStopQuality.Name = "scanStopQuality";
            this.scanStopQuality.Size = new System.Drawing.Size(141, 20);
            this.scanStopQuality.TabIndex = 3;
            this.scanStopQuality.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bandwidth";
            // 
            // bandwidthDropdown
            // 
            this.bandwidthDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bandwidthDropdown.FormattingEnabled = true;
            this.bandwidthDropdown.Items.AddRange(new object[] {
            "High (48kHz)",
            "Low (37kHz)"});
            this.bandwidthDropdown.Location = new System.Drawing.Point(164, 113);
            this.bandwidthDropdown.Name = "bandwidthDropdown";
            this.bandwidthDropdown.Size = new System.Drawing.Size(141, 21);
            this.bandwidthDropdown.TabIndex = 5;
            this.bandwidthDropdown.SelectedIndexChanged += new System.EventHandler(this.bandwidthDropdown_SelectedIndexChanged);
            // 
            // scanBackwards
            // 
            this.scanBackwards.Location = new System.Drawing.Point(311, 31);
            this.scanBackwards.Name = "scanBackwards";
            this.scanBackwards.Size = new System.Drawing.Size(37, 23);
            this.scanBackwards.TabIndex = 6;
            this.scanBackwards.Text = "<";
            this.scanBackwards.UseVisualStyleBackColor = true;
            this.scanBackwards.Click += new System.EventHandler(this.scanBackwards_Click);
            // 
            // scanForwards
            // 
            this.scanForwards.Location = new System.Drawing.Point(354, 31);
            this.scanForwards.Name = "scanForwards";
            this.scanForwards.Size = new System.Drawing.Size(37, 23);
            this.scanForwards.TabIndex = 7;
            this.scanForwards.Text = ">";
            this.scanForwards.UseVisualStyleBackColor = true;
            this.scanForwards.Click += new System.EventHandler(this.scanForwards_Click);
            // 
            // softMuteCheckBox
            // 
            this.softMuteCheckBox.AutoSize = true;
            this.softMuteCheckBox.Location = new System.Drawing.Point(6, 19);
            this.softMuteCheckBox.Name = "softMuteCheckBox";
            this.softMuteCheckBox.Size = new System.Drawing.Size(71, 17);
            this.softMuteCheckBox.TabIndex = 8;
            this.softMuteCheckBox.Text = "Soft mute";
            this.softMuteCheckBox.UseVisualStyleBackColor = true;
            this.softMuteCheckBox.CheckedChanged += new System.EventHandler(this.softMuteCheckBox_CheckedChanged);
            // 
            // blendCheckBox
            // 
            this.blendCheckBox.AutoSize = true;
            this.blendCheckBox.Location = new System.Drawing.Point(6, 43);
            this.blendCheckBox.Name = "blendCheckBox";
            this.blendCheckBox.Size = new System.Drawing.Size(87, 17);
            this.blendCheckBox.TabIndex = 9;
            this.blendCheckBox.Text = "Stereo Blend";
            this.blendCheckBox.UseVisualStyleBackColor = true;
            this.blendCheckBox.CheckedChanged += new System.EventHandler(this.blendCheckBox_CheckedChanged);
            // 
            // switchCheckBox
            // 
            this.switchCheckBox.AutoSize = true;
            this.switchCheckBox.Location = new System.Drawing.Point(6, 67);
            this.switchCheckBox.Name = "switchCheckBox";
            this.switchCheckBox.Size = new System.Drawing.Size(92, 17);
            this.switchCheckBox.TabIndex = 10;
            this.switchCheckBox.Text = "Stereo Switch";
            this.switchCheckBox.UseVisualStyleBackColor = true;
            this.switchCheckBox.CheckedChanged += new System.EventHandler(this.switchCheckBox_CheckedChanged);
            // 
            // deemphasisCheckBox
            // 
            this.deemphasisCheckBox.AutoSize = true;
            this.deemphasisCheckBox.Location = new System.Drawing.Point(6, 91);
            this.deemphasisCheckBox.Name = "deemphasisCheckBox";
            this.deemphasisCheckBox.Size = new System.Drawing.Size(104, 17);
            this.deemphasisCheckBox.TabIndex = 11;
            this.deemphasisCheckBox.Text = "De-emphasis TC";
            this.deemphasisCheckBox.UseVisualStyleBackColor = true;
            this.deemphasisCheckBox.CheckedChanged += new System.EventHandler(this.deemphasisCheckBox_CheckedChanged);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(16, 486);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 12;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(97, 486);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 13;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // highCutCheckBox
            // 
            this.highCutCheckBox.AutoSize = true;
            this.highCutCheckBox.Location = new System.Drawing.Point(6, 115);
            this.highCutCheckBox.Name = "highCutCheckBox";
            this.highCutCheckBox.Size = new System.Drawing.Size(67, 17);
            this.highCutCheckBox.TabIndex = 14;
            this.highCutCheckBox.Text = "High Cut";
            this.highCutCheckBox.UseVisualStyleBackColor = true;
            this.highCutCheckBox.CheckedChanged += new System.EventHandler(this.highCutCheckBox_CheckedChanged);
            // 
            // signalLockCheckBox
            // 
            this.signalLockCheckBox.AutoCheck = false;
            this.signalLockCheckBox.AutoSize = true;
            this.signalLockCheckBox.Location = new System.Drawing.Point(6, 19);
            this.signalLockCheckBox.Name = "signalLockCheckBox";
            this.signalLockCheckBox.Size = new System.Drawing.Size(82, 17);
            this.signalLockCheckBox.TabIndex = 15;
            this.signalLockCheckBox.Text = "Signal Lock";
            this.signalLockCheckBox.UseVisualStyleBackColor = true;
            // 
            // signalQualityTextBox
            // 
            this.signalQualityTextBox.Location = new System.Drawing.Point(97, 94);
            this.signalQualityTextBox.Name = "signalQualityTextBox";
            this.signalQualityTextBox.ReadOnly = true;
            this.signalQualityTextBox.Size = new System.Drawing.Size(123, 20);
            this.signalQualityTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Signal Quality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "RDS Quality";
            // 
            // rdsQualityTextBox
            // 
            this.rdsQualityTextBox.Location = new System.Drawing.Point(263, 141);
            this.rdsQualityTextBox.Name = "rdsQualityTextBox";
            this.rdsQualityTextBox.ReadOnly = true;
            this.rdsQualityTextBox.Size = new System.Drawing.Size(120, 20);
            this.rdsQualityTextBox.TabIndex = 19;
            // 
            // isStereoCheckBox
            // 
            this.isStereoCheckBox.AutoCheck = false;
            this.isStereoCheckBox.AutoSize = true;
            this.isStereoCheckBox.Location = new System.Drawing.Point(6, 44);
            this.isStereoCheckBox.Name = "isStereoCheckBox";
            this.isStereoCheckBox.Size = new System.Drawing.Size(57, 17);
            this.isStereoCheckBox.TabIndex = 20;
            this.isStereoCheckBox.Text = "Stereo";
            this.isStereoCheckBox.UseVisualStyleBackColor = true;
            // 
            // rdsSyncCheckBox
            // 
            this.rdsSyncCheckBox.AutoCheck = false;
            this.rdsSyncCheckBox.AutoSize = true;
            this.rdsSyncCheckBox.Location = new System.Drawing.Point(6, 71);
            this.rdsSyncCheckBox.Name = "rdsSyncCheckBox";
            this.rdsSyncCheckBox.Size = new System.Drawing.Size(76, 17);
            this.rdsSyncCheckBox.TabIndex = 21;
            this.rdsSyncCheckBox.Text = "RDS Sync";
            this.rdsSyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // audioStereoCheckBox
            // 
            this.audioStereoCheckBox.AutoCheck = false;
            this.audioStereoCheckBox.AutoSize = true;
            this.audioStereoCheckBox.Location = new System.Drawing.Point(97, 73);
            this.audioStereoCheckBox.Name = "audioStereoCheckBox";
            this.audioStereoCheckBox.Size = new System.Drawing.Size(57, 17);
            this.audioStereoCheckBox.TabIndex = 22;
            this.audioStereoCheckBox.Text = "Stereo";
            this.audioStereoCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Sample Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Bits per Sample";
            // 
            // sampleRateTextBox
            // 
            this.sampleRateTextBox.Location = new System.Drawing.Point(97, 17);
            this.sampleRateTextBox.Name = "sampleRateTextBox";
            this.sampleRateTextBox.ReadOnly = true;
            this.sampleRateTextBox.Size = new System.Drawing.Size(123, 20);
            this.sampleRateTextBox.TabIndex = 25;
            // 
            // bitRateTextBox
            // 
            this.bitRateTextBox.Location = new System.Drawing.Point(97, 43);
            this.bitRateTextBox.Name = "bitRateTextBox";
            this.bitRateTextBox.ReadOnly = true;
            this.bitRateTextBox.Size = new System.Drawing.Size(123, 20);
            this.bitRateTextBox.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.signalLockCheckBox);
            this.groupBox1.Controls.Add(this.isStereoCheckBox);
            this.groupBox1.Controls.Add(this.rdsSyncCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.signalQualityTextBox);
            this.groupBox1.Location = new System.Drawing.Point(416, 363);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 125);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signal Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.audioStereoCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bitRateTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.sampleRateTextBox);
            this.groupBox2.Location = new System.Drawing.Point(416, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 103);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio Information";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(178, 486);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 29;
            this.updateButton.Text = "Update Information";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Search Interval";
            // 
            // numberSearches
            // 
            this.numberSearches.Location = new System.Drawing.Point(164, 87);
            this.numberSearches.Name = "numberSearches";
            this.numberSearches.Size = new System.Drawing.Size(141, 20);
            this.numberSearches.TabIndex = 31;
            this.numberSearches.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // searchIntervalComboBox
            // 
            this.searchIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchIntervalComboBox.FormattingEnabled = true;
            this.searchIntervalComboBox.Items.AddRange(new object[] {
            "50Hz",
            "100Hz",
            "200Hz"});
            this.searchIntervalComboBox.Location = new System.Drawing.Point(164, 60);
            this.searchIntervalComboBox.Name = "searchIntervalComboBox";
            this.searchIntervalComboBox.Size = new System.Drawing.Size(141, 21);
            this.searchIntervalComboBox.TabIndex = 33;
            this.searchIntervalComboBox.SelectedIndexChanged += new System.EventHandler(this.searchIntervalComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Maximum Searches";
            // 
            // firstAlternateFrequencyTextBox
            // 
            this.firstAlternateFrequencyTextBox.Location = new System.Drawing.Point(263, 13);
            this.firstAlternateFrequencyTextBox.Name = "firstAlternateFrequencyTextBox";
            this.firstAlternateFrequencyTextBox.ReadOnly = true;
            this.firstAlternateFrequencyTextBox.Size = new System.Drawing.Size(120, 20);
            this.firstAlternateFrequencyTextBox.TabIndex = 35;
            // 
            // secondAlternateFrequencyTextBox
            // 
            this.secondAlternateFrequencyTextBox.Location = new System.Drawing.Point(263, 39);
            this.secondAlternateFrequencyTextBox.Name = "secondAlternateFrequencyTextBox";
            this.secondAlternateFrequencyTextBox.ReadOnly = true;
            this.secondAlternateFrequencyTextBox.Size = new System.Drawing.Size(120, 20);
            this.secondAlternateFrequencyTextBox.TabIndex = 36;
            // 
            // programmeTextBox
            // 
            this.programmeTextBox.Location = new System.Drawing.Point(263, 65);
            this.programmeTextBox.Name = "programmeTextBox";
            this.programmeTextBox.ReadOnly = true;
            this.programmeTextBox.Size = new System.Drawing.Size(120, 20);
            this.programmeTextBox.TabIndex = 37;
            // 
            // trafficInformationTextBox
            // 
            this.trafficInformationTextBox.Location = new System.Drawing.Point(263, 91);
            this.trafficInformationTextBox.Name = "trafficInformationTextBox";
            this.trafficInformationTextBox.ReadOnly = true;
            this.trafficInformationTextBox.Size = new System.Drawing.Size(120, 20);
            this.trafficInformationTextBox.TabIndex = 38;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(263, 117);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(120, 20);
            this.typeTextBox.TabIndex = 39;
            // 
            // artificalHeadCheckBox
            // 
            this.artificalHeadCheckBox.AutoCheck = false;
            this.artificalHeadCheckBox.AutoSize = true;
            this.artificalHeadCheckBox.Location = new System.Drawing.Point(6, 41);
            this.artificalHeadCheckBox.Name = "artificalHeadCheckBox";
            this.artificalHeadCheckBox.Size = new System.Drawing.Size(89, 17);
            this.artificalHeadCheckBox.TabIndex = 40;
            this.artificalHeadCheckBox.Text = "Artifical Head";
            this.artificalHeadCheckBox.UseVisualStyleBackColor = true;
            // 
            // compressedCheckBox
            // 
            this.compressedCheckBox.AutoCheck = false;
            this.compressedCheckBox.AutoSize = true;
            this.compressedCheckBox.Location = new System.Drawing.Point(6, 67);
            this.compressedCheckBox.Name = "compressedCheckBox";
            this.compressedCheckBox.Size = new System.Drawing.Size(84, 17);
            this.compressedCheckBox.TabIndex = 41;
            this.compressedCheckBox.Text = "Compressed";
            this.compressedCheckBox.UseVisualStyleBackColor = true;
            // 
            // musicCheckBox
            // 
            this.musicCheckBox.AutoCheck = false;
            this.musicCheckBox.AutoSize = true;
            this.musicCheckBox.Location = new System.Drawing.Point(6, 93);
            this.musicCheckBox.Name = "musicCheckBox";
            this.musicCheckBox.Size = new System.Drawing.Size(54, 17);
            this.musicCheckBox.TabIndex = 42;
            this.musicCheckBox.Text = "Music";
            this.musicCheckBox.UseVisualStyleBackColor = true;
            // 
            // rdsStereoCheckBox
            // 
            this.rdsStereoCheckBox.AutoCheck = false;
            this.rdsStereoCheckBox.AutoSize = true;
            this.rdsStereoCheckBox.Location = new System.Drawing.Point(6, 15);
            this.rdsStereoCheckBox.Name = "rdsStereoCheckBox";
            this.rdsStereoCheckBox.Size = new System.Drawing.Size(57, 17);
            this.rdsStereoCheckBox.TabIndex = 43;
            this.rdsStereoCheckBox.Text = "Stereo";
            this.rdsStereoCheckBox.UseVisualStyleBackColor = true;
            // 
            // dynamicCheckBox
            // 
            this.dynamicCheckBox.AutoCheck = false;
            this.dynamicCheckBox.AutoSize = true;
            this.dynamicCheckBox.Location = new System.Drawing.Point(6, 119);
            this.dynamicCheckBox.Name = "dynamicCheckBox";
            this.dynamicCheckBox.Size = new System.Drawing.Size(91, 17);
            this.dynamicCheckBox.TabIndex = 44;
            this.dynamicCheckBox.Text = "Dynamic PTY";
            this.dynamicCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.rdsStereoCheckBox);
            this.groupBox3.Controls.Add(this.dynamicCheckBox);
            this.groupBox3.Controls.Add(this.artificalHeadCheckBox);
            this.groupBox3.Controls.Add(this.typeTextBox);
            this.groupBox3.Controls.Add(this.rdsQualityTextBox);
            this.groupBox3.Controls.Add(this.compressedCheckBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trafficInformationTextBox);
            this.groupBox3.Controls.Add(this.musicCheckBox);
            this.groupBox3.Controls.Add(this.programmeTextBox);
            this.groupBox3.Controls.Add(this.firstAlternateFrequencyTextBox);
            this.groupBox3.Controls.Add(this.secondAlternateFrequencyTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 174);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RDS Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Alternate Frequency 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Alternate Frequency 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(146, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Programme";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(146, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Programme Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(146, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Traffic Information";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.softMuteCheckBox);
            this.groupBox4.Controls.Add(this.blendCheckBox);
            this.groupBox4.Controls.Add(this.switchCheckBox);
            this.groupBox4.Controls.Add(this.deemphasisCheckBox);
            this.groupBox4.Controls.Add(this.highCutCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(430, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(142, 144);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio Quality";
            // 
            // setFrequencyTextBox
            // 
            this.setFrequencyTextBox.Location = new System.Drawing.Point(164, 141);
            this.setFrequencyTextBox.Name = "setFrequencyTextBox";
            this.setFrequencyTextBox.Size = new System.Drawing.Size(141, 20);
            this.setFrequencyTextBox.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Request Frequency";
            // 
            // setFrequencyButton
            // 
            this.setFrequencyButton.Location = new System.Drawing.Point(312, 139);
            this.setFrequencyButton.Name = "setFrequencyButton";
            this.setFrequencyButton.Size = new System.Drawing.Size(79, 23);
            this.setFrequencyButton.TabIndex = 49;
            this.setFrequencyButton.Text = "Set";
            this.setFrequencyButton.UseVisualStyleBackColor = true;
            this.setFrequencyButton.Click += new System.EventHandler(this.setFrequencyButton_Click);
            // 
            // lowestFrequencyTextBox
            // 
            this.lowestFrequencyTextBox.Location = new System.Drawing.Point(118, 434);
            this.lowestFrequencyTextBox.Name = "lowestFrequencyTextBox";
            this.lowestFrequencyTextBox.ReadOnly = true;
            this.lowestFrequencyTextBox.Size = new System.Drawing.Size(135, 20);
            this.lowestFrequencyTextBox.TabIndex = 50;
            // 
            // highestFrequencyTextBox
            // 
            this.highestFrequencyTextBox.Location = new System.Drawing.Point(118, 460);
            this.highestFrequencyTextBox.Name = "highestFrequencyTextBox";
            this.highestFrequencyTextBox.ReadOnly = true;
            this.highestFrequencyTextBox.Size = new System.Drawing.Size(135, 20);
            this.highestFrequencyTextBox.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 437);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Lowest Frequency";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 460);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Highest Frequency";
            // 
            // rdsButton
            // 
            this.rdsButton.Location = new System.Drawing.Point(259, 486);
            this.rdsButton.Name = "rdsButton";
            this.rdsButton.Size = new System.Drawing.Size(75, 23);
            this.rdsButton.TabIndex = 54;
            this.rdsButton.Text = "Enable RDS";
            this.rdsButton.UseVisualStyleBackColor = true;
            this.rdsButton.Click += new System.EventHandler(this.rdsButton_Click);
            // 
            // errorCorrectionCheckBox
            // 
            this.errorCorrectionCheckBox.AutoSize = true;
            this.errorCorrectionCheckBox.Location = new System.Drawing.Point(15, 195);
            this.errorCorrectionCheckBox.Name = "errorCorrectionCheckBox";
            this.errorCorrectionCheckBox.Size = new System.Drawing.Size(125, 17);
            this.errorCorrectionCheckBox.TabIndex = 55;
            this.errorCorrectionCheckBox.Text = "RDS Error Correction";
            this.errorCorrectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // errorThreshold
            // 
            this.errorThreshold.Location = new System.Drawing.Point(164, 167);
            this.errorThreshold.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.errorThreshold.Name = "errorThreshold";
            this.errorThreshold.Size = new System.Drawing.Size(120, 20);
            this.errorThreshold.TabIndex = 57;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 13);
            this.label18.TabIndex = 58;
            this.label18.Text = "RDS Error Threshold";
            // 
            // updateRdsControl
            // 
            this.updateRdsControl.Location = new System.Drawing.Point(312, 191);
            this.updateRdsControl.Name = "updateRdsControl";
            this.updateRdsControl.Size = new System.Drawing.Size(79, 23);
            this.updateRdsControl.TabIndex = 59;
            this.updateRdsControl.Text = "Set";
            this.updateRdsControl.UseVisualStyleBackColor = true;
            this.updateRdsControl.Click += new System.EventHandler(this.updateRdsControl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 521);
            this.Controls.Add(this.updateRdsControl);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.errorThreshold);
            this.Controls.Add(this.errorCorrectionCheckBox);
            this.Controls.Add(this.rdsButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.highestFrequencyTextBox);
            this.Controls.Add(this.lowestFrequencyTextBox);
            this.Controls.Add(this.setFrequencyButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.setFrequencyTextBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.searchIntervalComboBox);
            this.Controls.Add(this.numberSearches);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.scanForwards);
            this.Controls.Add(this.scanBackwards);
            this.Controls.Add(this.bandwidthDropdown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scanStopQuality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.frequencyTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Radio Test App";
            ((System.ComponentModel.ISupportInitialize)(this.scanStopQuality)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberSearches)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown scanStopQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox bandwidthDropdown;
        private System.Windows.Forms.Button scanBackwards;
        private System.Windows.Forms.Button scanForwards;
        private System.Windows.Forms.CheckBox softMuteCheckBox;
        private System.Windows.Forms.CheckBox blendCheckBox;
        private System.Windows.Forms.CheckBox switchCheckBox;
        private System.Windows.Forms.CheckBox deemphasisCheckBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox highCutCheckBox;
        private System.Windows.Forms.CheckBox signalLockCheckBox;
        private System.Windows.Forms.TextBox signalQualityTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rdsQualityTextBox;
        private System.Windows.Forms.CheckBox isStereoCheckBox;
        private System.Windows.Forms.CheckBox rdsSyncCheckBox;
        private System.Windows.Forms.CheckBox audioStereoCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sampleRateTextBox;
        private System.Windows.Forms.TextBox bitRateTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numberSearches;
        private System.Windows.Forms.ComboBox searchIntervalComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox firstAlternateFrequencyTextBox;
        private System.Windows.Forms.TextBox secondAlternateFrequencyTextBox;
        private System.Windows.Forms.TextBox programmeTextBox;
        private System.Windows.Forms.TextBox trafficInformationTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.CheckBox artificalHeadCheckBox;
        private System.Windows.Forms.CheckBox compressedCheckBox;
        private System.Windows.Forms.CheckBox musicCheckBox;
        private System.Windows.Forms.CheckBox rdsStereoCheckBox;
        private System.Windows.Forms.CheckBox dynamicCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox setFrequencyTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button setFrequencyButton;
        private System.Windows.Forms.TextBox lowestFrequencyTextBox;
        private System.Windows.Forms.TextBox highestFrequencyTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button rdsButton;
        private System.Windows.Forms.CheckBox errorCorrectionCheckBox;
        private System.Windows.Forms.NumericUpDown errorThreshold;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button updateRdsControl;
    }
}

