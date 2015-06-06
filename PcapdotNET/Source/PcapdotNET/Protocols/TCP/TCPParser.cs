using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PcapdotNET.Protocols.TCP
{
    /// <summary>class TCP
    /// This class parse .pcap file and read TCP packets 
    /// </summary>
    public class TCPParser : ITCPParser
    {
        private readonly ArrayList _tcpFrameArray = new ArrayList();

        private uint _frameLength;

        /// <summary>Set frame length
        /// Set frame Length for frame
        /// </summary>
        /// <param name="frameLength"></param>
        public void SetFrameLenght(uint frameLength)
        {
            _frameLength = frameLength;
        }

        /// <summary>Get TCP protocols
        /// Get information about TCP protocol from byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public TCPFrame GetTCPPacket(byte[] bytes)
        {
            // Fill Source & Destination IP
            var sourceIp = ReadSource(bytes);

            var destinationIp = ReadDestination(bytes);

            // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
            var draftPort = new uint[PacketFields.AmountOfBytesInPortNumber];

            int j = 10;
            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint sourcePort = draftPort[0] * PacketFields.Offset + draftPort[1];

            for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i, ++j)
                draftPort[i] = bytes[j];

            uint destinationPort = draftPort[0] * PacketFields.Offset + draftPort[1];

            var T = new TCPFrame(destinationIp, destinationPort, _frameLength, sourceIp, sourcePort,
                            17);

            return T;
        }

        /// <summary>Read destination Ip
        /// Read Destination Ip From byte[]
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static int[] ReadDestination(IList<byte> bytes)
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
        private static int[] ReadSource(IList<byte> bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = 2;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }


        /// <summary>Return TCP Frame
        /// This method return object TCPFarme
        /// </summary>
        /// <returns></returns>
        public TCPFrame GetTCPFrame()
        {
            return (TCPFrame)_tcpFrameArray[0];
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
