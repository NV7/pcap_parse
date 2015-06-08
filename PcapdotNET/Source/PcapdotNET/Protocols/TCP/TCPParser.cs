using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PcapdotNET.Protocols.TCP
{
    /// <summary>class TCP
    /// This class parse .pcap file and read TCP packets 
    /// </summary>
    public class TCPParser : ITCPParser, IProtocolChecker<TCPFrame>
    {
        private readonly ArrayList _tcpFrameArray = new ArrayList();

        private uint _frameLength;

        /// <summary>Set frame length
        /// Set frame Length for frame
        /// </summary>
        /// <param name="frameLength">uint length of frame</param>
        public void SetFrameLenght(uint frameLength)
        {
            _frameLength = frameLength;
        }

        /// <summary>Get TCP protocols
        /// Get information about TCP protocol from byte[]
        /// </summary>
        /// <param name="bytes">byte[] bytes to operate</param>
        /// <returns>TCPFrame formed TCP frame</returns>
        public TCPFrame GetPacket(byte[] bytes)
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

            var NewTCPFrame = new TCPFrame(destinationIp, destinationPort, _frameLength, sourceIp, sourcePort,
                            17);

            return NewTCPFrame;
        }

        /// <summary>Read destination Ip
        /// Read Destination Ip From byte[]
        /// </summary>
        /// <param name="bytes">IList"byte" byte - bytes to read</param>
        /// <returns>int[] byte of DestinationIp</returns>
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
        /// <param name="bytes">IList"byte" byte - bytes to read</param>
        /// <returns>int[] Source IP</returns>
        private static int[] ReadSourceIP(IList<byte> bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = PacketFields.ReadSourceIPBitsOffset;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }

        /// <summary>Return TCP Frame List
        /// This method return object TCPFarme
        /// </summary>
        /// <returns>ArrayList _tcpFrameArray</returns>
        public ArrayList GetTCPFrameList()
        {
            return _tcpFrameArray;
        }

        /// <summary>Use in LightInject
        /// This method refers to IoC Container
        /// </summary>
        public void ITCPParser(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
