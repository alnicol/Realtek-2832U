using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using RadioLib.MultiplexInformation;
using RadioLib.MultiplexInformation.Nodes;

namespace RadioLib
{
    public class DabRadio
    {
        private readonly IDabRadioControlFilter filterInterface;

        public DabRadio(IDabRadioControlFilter filterInterface)
        {
            this.filterInterface = filterInterface;
        }

        public FrequencyBandwidth FrequencyBandwidth
        {
            get 
            {
                int frequency;
                int bandwidth;
                filterInterface.GetFrequencyAndBandwidth(out frequency, out bandwidth);
                return new FrequencyBandwidth(frequency, bandwidth);
            }
            set 
            { 
                filterInterface.SetFrequencyAndBandwidth(value.Frequency, value.Bandwidth);
            }
        }

        public bool SignalLock
        {
            get
            {
                int result;
                filterInterface.GetSignalLock(out result);
                return result == 1;
            }
        }

        public int SignalQuality
        {
            get 
            { 
                int result;
                filterInterface.GetSignalQuality(out result);
                return result;
            }
        }

        public short FicCounter
        {
            set { filterInterface.SetFicParseCounter(ref value); }
        }

        public short FicTimeout
        {
            set { filterInterface.SetFicParseTimeout(ref value); }
        }

        public FmResult QueryConnect()
        {
            return filterInterface.QueryConnect();
        }

        public void Add(ServiceDetails service)
        {
            //filterInterface.AddService((char)0, (char)5, 0, (char)0, (char)35, (char)0, 0, 0, (char)0);
            filterInterface.AddService(service.Mode, service.SubChannelId, service.FirstCapacityUnit, service.EqualErrorProtection,
                                  service.UepIndex, service.EepIndex, service.NumberCapacityUnits, service.PacketAddr,
                                  service.FecScheme);
        }

        public void Delete(ServiceDetails service)
        {
            filterInterface.DeleteService(service.Mode, service.SubChannelId, service.PacketAddr);
        }

        public void StartFicParse()
        {
            var counter = 0;
            while (true)
            {
                if (!SignalLock)
                    Thread.Sleep(300);
                else
                    break;
                counter++;
                if (counter == 30)
                    throw new Exception();
            }
            filterInterface.StartFicParse();
        }

        public void StopFicParse()
        {
            filterInterface.StopFicParse();
        }

        public List<ServiceDetails> GetMultiplexInformation()
        {
            IntPtr data;
            while (true)
            {
                var result = filterInterface.GetMultiplexInformation(out data);
                if ((int)result == 2)
                    Thread.Sleep(50);
                else
                    break;
            }

            var ensemble = Ensemble.FromIntPtr(data);
            var abbreviatedLabel = ensemble.ShortLabel;
            var date = ensemble.DateTime.Time;
            var serviceDetails = new List<ServiceDetails>();
            foreach (var service in ensemble.Services)
            {
                foreach (var audioNode in service.AudioNodes)
                {
                    if (audioNode.ServiceType == AudioType.AacAudio)
                        continue;
                    serviceDetails.Add(new ServiceDetails(service.Label, audioNode));
                }
            }
            return serviceDetails;
        }
    }

    public class ServiceDetails
    {
        public string Name { get; private set; }
        public char Mode { get; set; }
        public char SubChannelId { get; set; }
        public short FirstCapacityUnit { get; set; }
        public char EqualErrorProtection { get; set; }
        public char UepIndex { get; set; }
        public char EepIndex { get; set; }
        public short NumberCapacityUnits { get; set; }
        public short PacketAddr { get; set; }
        public char FecScheme { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public ServiceDetails(string name, AudioStreamNode audioNode)
        {
            Name = name;
            Mode = (char) audioNode.ServiceType;
            SubChannelId = (char) audioNode.SubchannelId;
            FirstCapacityUnit = (short) audioNode.StartCapacityUnit;
            EqualErrorProtection = audioNode.EqualErrorProtection ? (char) 1 : (char) 0;
            if (EqualErrorProtection == 1)
            {
                EepIndex = (char) audioNode.ErrorProtectionIndex;
                NumberCapacityUnits = (short) audioNode.CapacityUnitCount;
            }
            else
            {
                UepIndex = (char)audioNode.ErrorProtectionIndex;
            }
        }
    }
}