using System;
using System.Collections;
using System.Collections.Generic;

namespace PcapdotNET.Protocols.ICMP
{
    /// <summary> Class ICMP Parser
    /// Class which read and get helpful information from .pcap file.
    /// </summary>
    public class ICMPParser : iICMPParser
    {
        private readonly ArrayList _icmpFrameArray = new ArrayList();

        private uint _frameLength;

        /// <summary>Set frame length
        /// Set frame Length for frame
        /// </summary>
        /// <param name="frameLength"></param>
        public void SerFrameLenght(uint frameLength)
        {
            _frameLength = frameLength;
        }

        /// <summary>Get ICMP protocols
        /// Get information about ICMP protocol from byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public ICMPFrame GetICMPPackets(byte [] bytes)
        {
            // Fill Source & Destination IP
            var sourceIp = ReadSourceIp(bytes);

            var destinationIp = ReadDestinationIp(bytes);

            // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
            var draftPort = new uint[PacketFields.AmountOfBytesInPortNumber];

            var j = 10;
            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint sourcePort = draftPort[0] * PacketFields.Offset + draftPort[1];

            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint destinationPort = draftPort[0] * PacketFields.Offset + draftPort[1];

            var icmpFrame = new ICMPFrame(destinationIp, destinationPort, _frameLength, sourceIp, sourcePort,
                            17);

            return icmpFrame;
        }

        /// <summary>Read destination Ip
        /// Read Destination Ip From byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static int[] ReadDestinationIp(IList<byte> bytes)
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
        private static int[] ReadSourceIp(IList<byte> bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = 2;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }

        /// <summary>Return ICMP Frame
        /// Return array list where [0] - destination IP; [1] - source ip; [2] - ICMP frame;
        /// </summary>
        /// <returns></returns>
        public ICMPFrame GetIcmpFrame()
        {
            return (ICMPFrame)_icmpFrameArray[0];
        }

        /// <summary>Return ICMP Frame List
        /// Return array list
        /// </summary>
        /// <returns>ArrayList _icmpFrameArray</returns>
        public ArrayList GetIcmpFrameList()
        {
            return _icmpFrameArray;
        }

        /// <summary>Use in LightInject
        /// This method refers to IoC Container
        /// </summary>
        public void IIcmpParser()
        {
            throw new NotImplementedException();
        }
    }
}
