﻿namespace PcapdotNET.Protocols
{
    public class EthernetFrame
    {
        private readonly int[] DestinationIP = new int[PacketFields.AmountOfEthernetParts];
        private readonly int[] SourceIP = new int[PacketFields.AmountOfEthernetParts];

        public EthernetFrame(int[] _DestinationIP, int[] _SourceIP)
        {
            DestinationIP = _DestinationIP;
            SourceIP = _SourceIP;
        }

        public string GetDestinationIP()
        {
            string result = DestinationIP[0].ToString("X") + "." + DestinationIP[1].ToString("X") + "." + DestinationIP[2].ToString("X") + "." + DestinationIP[3].ToString("X") +
                            "." + DestinationIP[4].ToString("X") + "." + DestinationIP[5].ToString("X");
            return result;
        }

        public string GetSourceIP()
        {
            string result = SourceIP[0].ToString("X") + "." + SourceIP[1].ToString("X") + "." + SourceIP[2].ToString("X") + "." + SourceIP[3].ToString("X") + "." + SourceIP[4].ToString("X") +
                            "." + SourceIP[5].ToString("X");
            return result;
        }

        public string GetInformation()
        {
            return DestinationIP[0].ToString("X") + "." + DestinationIP[1].ToString("X") + "." +
                   DestinationIP[2].ToString("X") + "." + DestinationIP[3].ToString("X") +
                   "." + DestinationIP[4].ToString("X") + "." + DestinationIP[5].ToString("X") + " <- " +
                   SourceIP[0].ToString("X") + "." + SourceIP[1].ToString("X") + "." + SourceIP[2].ToString("X") + "." +
                   SourceIP[3].ToString("X") + "." + SourceIP[4].ToString("X") +
                   "." + SourceIP[5].ToString("X");
        }
    }
}