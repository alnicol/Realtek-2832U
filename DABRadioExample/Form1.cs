using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using RadioLib;

namespace DABRadioExample
{
    public partial class Form1 : Form
    {
        private readonly ChannelData channelData;
        private readonly DabRadio controller;
        private readonly DabRadioGraph dabRadioGraph;
        private ServiceDetails currentService;

        public Form1()
        {
            InitializeComponent();
            dabRadioGraph = new DabRadioGraph();
            controller = dabRadioGraph.RadioControl;
            
            channelData = LoadChannelData();
            foreach (var plan in channelData.FrequencyPlans)
                areaDropDown.Items.Add(plan.Name);

            areaDropDown.SelectedIndexChanged += areaDropDown_SelectedIndexChanged;
            bandDropDown.SelectedIndexChanged += bandDropDown_SelectedIndexChanged;
            serviceList.SelectedValueChanged += serviceList_SelectedValueChanged;
        }

        void serviceList_SelectedValueChanged(object sender, EventArgs e)
        {
            var service = serviceList.SelectedItem as ServiceDetails;
            if (service == null)
                return;

            dabRadioGraph.Stop();

            if (currentService != null)
            {
                controller.Delete(currentService);
                currentService = null;
            }

            controller.Add(service);
            currentService = service;
            Thread.Sleep(800);
            
            var result = controller.QueryConnect();
            if (result != FmResult.Ok)
                return;
            dabRadioGraph.Play();
        }

        void bandDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            serviceList.Items.Clear();
            var selectedChannel = channelData.FrequencyPlans[areaDropDown.SelectedIndex].Channels[bandDropDown.SelectedIndex];
            controller.FrequencyBandwidth = new FrequencyBandwidth(selectedChannel.Frequency, selectedChannel.Bandwidth);
            controller.FicCounter = Convert.ToInt16(counterTextBox.Text);
            controller.FicTimeout = Convert.ToInt16(timeoutTextBox.Text);
            ParseFic();
        }

        private void ParseFic()
        {
            controller.StartFicParse();
            var serviceDetails = controller.GetMultiplexInformation();
            controller.StopFicParse();
            foreach (var item in serviceDetails)
                serviceList.Items.Add(item);
        }

        void areaDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandDropDown.Items.Clear();
            foreach (var channel in channelData.FrequencyPlans[areaDropDown.SelectedIndex].Channels)
            {
                bandDropDown.Items.Add(channel.Name);
            }
        }

        public ChannelData LoadChannelData()
        {
            ChannelData channelData;
            var serializer = new XmlSerializer(typeof(ChannelData));
            using (var stream = File.OpenRead("Channels.xml"))
            {
                channelData = (ChannelData) serializer.Deserialize(stream);
            }
            return channelData;
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            var frequency = Convert.ToInt32(frequencyTextBox.Text);
            var bandWidth = Convert.ToInt32(bandwidthTextBox.Text);
            controller.FrequencyBandwidth = new FrequencyBandwidth(frequency, bandWidth);
            ParseFic();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            var result = controller.QueryConnect();
            if (result != FmResult.Ok)
                return;

            dabRadioGraph.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            dabRadioGraph.Stop();
        }
    }
}
