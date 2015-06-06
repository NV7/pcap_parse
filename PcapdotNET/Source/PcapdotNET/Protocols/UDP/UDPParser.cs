using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.UDP
{
    /// <summary>UDP Parser
    /// Class UDP Parser
    /// </summary>
    public class UdpParser : IUDPParser
    {
        private readonly ArrayList _udpFrameArray = new ArrayList();
        private uint _frameLength;

        public void SetFrameLenght(uint frameLength)
        {
            _frameLength = frameLength;
        }

        public UDPFrame GetUdpPacket(byte[] bytes)
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

            var T = new UDPFrame(destinationIp, destinationPort, _frameLength, sourceIp, sourcePort,
                            17);

            return T;
        }

        private int[] ReadDestination(byte[] bytes)
        {
            var destinationIp = new int[PacketFields.AmountOfIpParts];
            var j = 6;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                destinationIp[i] = bytes[j];

            return destinationIp;
        }

        private int[] ReadSource(byte[] bytes)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];
            var j = 2;

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i, ++j)
                sourceIp[i] = bytes[j];

            return sourceIp;
        }



        /// <summary>Return UPD Frame 
        ///  Get this dump of processed frames
        /// </summary>
        /// <returns></returns>
        public UDPFrame GetUdpFrame()
        {
            return (UDPFrame)_udpFrameArray[0];
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
