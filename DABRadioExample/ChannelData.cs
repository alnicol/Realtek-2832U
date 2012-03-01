using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DABRadioExample
{
    [Serializable]
    public class ChannelData
    {
        public ChannelData()
        {
            FrequencyPlans = new List<FrequencyPlan>();
        }

        public List<FrequencyPlan> FrequencyPlans;
    }

    [Serializable]
    public class FrequencyPlan
    {
        public FrequencyPlan()
        {
            Channels = new List<Channel>();
        }

        public FrequencyPlan(string name)
            : this()
        {
            this.Name = name;
        }

        [XmlAttribute()]
        public string Name;
        [XmlArray]
        public List<Channel> Channels;
    }

    [Serializable]
    public class Channel
    {
        public Channel()
        {
        }

        public Channel(string name, int frequency, int bandwidth)
        {
            this.Name = name;
            this.Frequency = frequency;
            this.Bandwidth = bandwidth;
        }

        public string Name;
        public int Frequency;
        public int Bandwidth;
    }
}
