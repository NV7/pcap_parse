using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PcapdotNET.Protocols.UDP
{
    /// <summary>UDP Parser
    /// Class UDP Parser
    /// </summary>
    public class UdpParser : IUDPParser,IProtocolChecker<UDPFrame>
    {
        private readonly ArrayList _udpFrameArray = new ArrayList();
        private uint _frameLength;

        /// <summary>Set frame length
        /// Set frame Length for frame
        /// </summary>
        /// <param name="frameLength"></param>
        public void SetFrameLenght(uint frameLength)
        {
            _frameLength = frameLength;
        }

        /// <summary>Get UDP protocols
        /// Get information about ICMP protocol from byte[]
        /// </summary>
        /// <param name="bytes">byte[] bytes to read</param>
        /// <returns>UDPFrame formed udpframe</returns>
        public UDPFrame GetPacket(byte[] bytes)
        {
            // Fill Source & Destination IP
            var sourceIp = ReadSourceIP(bytes);

            var destinationIp = ReadDestinationIP(bytes);

            // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
            var draftPort = new uint[PacketFields.AmountOfBytesInPortNumber];

            int j = PacketFields.OffsetForPorts;
            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint sourcePort = draftPort[PacketFields.FirstBit] * PacketFields.Offset + draftPort[PacketFields.SecondBit];

            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint destinationPort = draftPort[0] * PacketFields.Offset + draftPort[1];

            var NewUDPFrame = new UDPFrame(destinationIp, destinationPort, _frameLength, sourceIp, sourcePort,
                            17);

            return NewUDPFrame;
        }

        /// <summary>Read destination Ip
        /// Read Destination Ip From byte[]
        /// </summary>
        /// <param name="bytes">IList"byte" bytes to read</param>
        /// <returns>int[] Dest ip</returns>
        private static int[] ReadDestinationIP(IList<byte> bytes)
        {
            var destinationIp = new int[PacketFields.AmountOfIpParts];
            var j = PacketFields.ReadDestinationIPBitsOffset;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                destinationIp[i] = bytes[j];

            return destinationIp;
        }

        /// <summary>Read source Ip
        /// Read Source Ip from byte[]
        /// </summary>
        /// <param name="bytes">IList"byte" bytes to read</param>
        /// <returns>int[] Source IP</returns>
        private static int[] ReadSourceIP(IList<byte> bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = PacketFields.ReadSourceIPBitsOffset;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }

        /// <summary>Use in LightInject
        /// This method refers to IoC Container
        /// </summary>
        public void IUDPParser(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
