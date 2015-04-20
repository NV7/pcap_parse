using System.IO;
using System.Net;

namespace PcapdotNET.Protocols
{
    public class UDPProtocolsProcessing
    {
        private BinaryReader BinaryReader;

        public bool ProcessUDPDatagram(ulong PacketNumber, double PacketTimestamp, byte IPPacketPayloadLength)
        {
            bool Result = true;
            byte UDPDatagramPayloadLength = 0;

            byte UDPDatagramSourcePort = 0;
            byte UDPDatagramDestinationPort = 0;

            Result = ProcessUDPDatagramHeader(IPPacketPayloadLength, out UDPDatagramPayloadLength,
                out UDPDatagramSourcePort, out UDPDatagramDestinationPort);

            if (Result)
            {
                Result = ProcessUDPDatagramPayload(PacketNumber, PacketTimestamp, UDPDatagramPayloadLength,
                    UDPDatagramSourcePort, UDPDatagramDestinationPort);
            }

            return Result;
        }

        private bool ProcessUDPDatagramHeader(byte IPPacketPayloadLength, out byte UDPDatagramPayloadLength,
            out byte UDPDatagramSourcePort, out byte UDPDatagramDestinationPort)
        {
            bool Result = true;

            UDPDatagramPayloadLength = 0;
            UDPDatagramSourcePort = 0;
            UDPDatagramDestinationPort = 0;

            UDPDatagramSourcePort = (byte) IPAddress.NetworkToHostOrder(BinaryReader.ReadInt16());

            UDPDatagramDestinationPort = (byte) IPAddress.NetworkToHostOrder(BinaryReader.ReadInt16());

            var UDPDatagramHeaderLength = (byte) IPAddress.NetworkToHostOrder(BinaryReader.ReadInt16());

            BinaryReader.ReadInt16();


            Result = ValidateUDPDatagramHeader(IPPacketPayloadLength, UDPDatagramHeaderLength);

            if (Result)
            {
                UDPDatagramPayloadLength = (byte) (IPPacketPayloadLength - UDPProtocolsConstants.HeaderLength);
            }

            return Result;
        }

        private bool ProcessUDPDatagramPayload(ulong PacketNumber, double PacketTimestamp, byte UDPDatagramPayloadLength,
            byte UDPDatagramSourcePort, byte UDPDatagramDestinationPort)
        {
            bool Result = true;

            if (UDPDatagramPayloadLength > 0)
            {
                switch (UDPDatagramSourcePort)
                {
                    default:
                    {
                        BinaryReader.ReadBytes(UDPDatagramPayloadLength);

                        break;
                    }
                }
            }

            return Result;
        }

        private bool ValidateUDPDatagramHeader(byte IPPacketPayloadLength, byte UDPDatagramHeaderLength)
        {
            bool Result = true;

            if (UDPDatagramHeaderLength != IPPacketPayloadLength)
            {
                Result = false;
            }

            if (UDPDatagramHeaderLength < UDPProtocolsConstants.HeaderLength)
            {
                Result = false;
            }

            return Result;
        }
    }
}