using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.Ethernet
{
    /// <summary>Parser Ethernet protocol
    /// This class read from .pcap file information about Ethernet protocol.
    /// </summary>
    public class EthernetParser : IEthernetParser
    {
        // Put here all info, collected from file
        private readonly ArrayList _ethernetFrameArray = new ArrayList();

        /// <summary>Read need information about Ethernet Protocol
        /// Get byte[] with data 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public EthernetFrame GetEthernetPacket(byte[] bytes)
        {
        
                        // Get Ethernet info
                        var ethernetDestinationIp = ReadDestinationIp(bytes);

                        var ethernetSourceIp = ReadSourceIp(bytes);

                        var ethernetFrame = new EthernetFrame(ethernetDestinationIp, ethernetSourceIp);

                        // Pull current Ethernet frame to dump
                        _ethernetFrameArray.Add(ethernetFrame);

            return ethernetFrame;
        }

        /// <summary>Read destination Ip
        /// Read Destination Ip From byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static int[] ReadDestinationIp(byte[] bytes)
        {
            var destinationIp = new int[PacketFields.AmountOfIpParts];
            var j = 6;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                destinationIp[i] = bytes[j];

            return destinationIp;
        }

        /// <summary>Read source Ip
        /// Read Source Ip from byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static int[] ReadSourceIp(byte[] bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = 2;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }

        /// <summary>Get Ethernet Frame List
        /// Get Array list 
        /// </summary>
        /// <returns>ArrayList -ethernetFrameArray</returns>
        public ArrayList GetEthernetFrameList()
        {
            return _ethernetFrameArray;
        }

        /// <summary>Use in LightInject
        /// This method refers to IoC Container
        /// </summary>
        public void IEthernetParser()
        {
            throw new NotImplementedException();
        }
    }
}
