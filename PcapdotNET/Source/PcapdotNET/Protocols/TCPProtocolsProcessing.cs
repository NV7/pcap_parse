using System.IO;
using System.Net;

namespace PcapdotNET.Protocols
{
    public class TCPProtocolsProcessing
    {
        private BinaryReader BinaryReader;

        public bool ProcessTCPPacket(ulong PacketNumber, double PacketTimestamp, byte IPPacketPayloadLength)
        {
            bool Result = true;
            byte TCPPacketPayloadLength = 0;
            byte TCPPacketSourcePort = 0;
            byte TCPPacketDestinationPort = 0;

            Result = ProcessTCPPacketHeader(IPPacketPayloadLength, out TCPPacketPayloadLength, out TCPPacketSourcePort,
                out TCPPacketDestinationPort);

            if (Result)
            {
                Result = ProcessTCPPacketPayload(PacketNumber, PacketTimestamp, TCPPacketPayloadLength,
                    TCPPacketSourcePort, TCPPacketDestinationPort);
            }

            return Result;
        }

        private bool ProcessTCPPacketHeader(byte theIPPacketPayloadLength, out byte theTCPPacketPayloadLength,
            out byte theTCPPacketSourcePort, out byte theTCPPacketDestinationPort)
        {
            bool Result = true;

            theTCPPacketPayloadLength = 0;
            theTCPPacketSourcePort = 0;
            theTCPPacketDestinationPort = 0;

            theTCPPacketSourcePort = (byte) IPAddress.NetworkToHostOrder(BinaryReader.ReadInt16());
            theTCPPacketDestinationPort = (byte) IPAddress.NetworkToHostOrder(BinaryReader.ReadInt16());

            BinaryReader.ReadUInt32();
            BinaryReader.ReadUInt32();

            byte theDataOffsetAndReservedAndNSFlag = BinaryReader.ReadByte();


            BinaryReader.ReadByte();
            BinaryReader.ReadUInt16();
            BinaryReader.ReadUInt16();
            BinaryReader.ReadUInt16();

            var theTCPPacketHeaderLength = (byte) (((theDataOffsetAndReservedAndNSFlag & 0xF0) >> 4)*4);

            // Validate the TCP packet header
            Result = ValidateTCPPacketHeader(
                theTCPPacketHeaderLength);

            if (Result)
            {
                // Set up the output parameter for the length of the payload of the TCP packet, which is the total length of the TCP packet minus the length of the TCP packet header just calculated
                theTCPPacketPayloadLength =
                    (byte) (theIPPacketPayloadLength - theTCPPacketHeaderLength);

                if (theTCPPacketHeaderLength > TCPProtocolsConstants.MinHeaderLength)
                {
                    // The TCP packet contains a header length which is greater than the minimum and so contains extra Options bytes at the end (e.g. timestamps from the capture application)

                    // Just read off these remaining Options bytes of the TCP packet header from the packet capture so we can move on
                    BinaryReader.ReadBytes(theTCPPacketHeaderLength - TCPProtocolsConstants.MinHeaderLength);
                }
            }
            else
            {
                theTCPPacketPayloadLength = 0;
            }

            return Result;
        }

        private bool ProcessTCPPacketPayload(ulong PacketNumber, double PacketTimestamp,
            ushort TCPPacketPayloadLength, ushort TCPPacketSourcePort, ushort TCPPacketDestinationPort)
        {
            bool Result = true;

            // Only process this TCP packet if the payload has a non-zero payload length i.e. it actually includes data so is not part of the three-way handshake or a plain acknowledgement
            if (TCPPacketPayloadLength > 0)
            {
                // Change this logic statement to allow identification and processing of specific messages within the TCP packet
                if (false)
                {
                    // TODO Put code here to identify and process specific messages within the TCP packet
                }
                // Just read off the remaining bytes of the TCP packet from the packet capture so we can move on
                // The remaining length is the supplied length of the TCP packet payload
                BinaryReader.ReadBytes(TCPPacketPayloadLength);
            }

            return Result;
        }

        private bool ValidateTCPPacketHeader(byte TCPPacketHeaderLength)
        {
            bool Result = (TCPPacketHeaderLength > TCPProtocolsConstants.MaxHeaderLength ||
                           TCPPacketHeaderLength < TCPProtocolsConstants.MinHeaderLength)
                ? false
                : true;

            return Result;
        }
    }
}