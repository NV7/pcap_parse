using System.Collections;
using System.Net.NetworkInformation;

namespace PcapdotNET.Protocols
{
    /// <summary>Class consist from information about const in our project
    /// Here we describe all constants, that we use in parsing pcap file
    /// </summary>
    public struct PacketFields
    {
        // Pcap file header length
        public readonly static int PcapHeaderLength = 24;

        // Amount of parts in IP-Adress
        public readonly static int AmountOfIpParts = 4;

        // Amount of parts in Ethernet Adress 
        public readonly static int AmountOfEthernetParts = 6;

        // Amount of bytes, that we miss in the begining of current frame
        public readonly static int FrameHeaderLength = 8;

        // Amount of bytes, that we miss between header of current frame and information about Ethernet adresses
        public readonly static int BytesBetweenHeaderOfFrameAndEthernetAdress = 4;

        // Amount of bytes, that we miss before gathering information about protocol number
        public static readonly int AmountOfBytesBeforeProtocolId = 11;

        // Amount of bytes, that form destination and source ports.
        // We need this because of ReadUInt16  reads bytes in little-endian, and we need in big.
        public static readonly int AmountOfBytesInPortNumber = 2;

        // Offset, that we use to create port number
        public static readonly uint Offset = 256;

        // Amount of bytes, that we miss in the end of current frame
        public static readonly int EndingBytes = 38;

        // Offset in filling Ports
        public static readonly int OffsetForPorts = 10;

        // Use this constants only because of the way ReadUInt16 written
        public static readonly int FirstBit = 0;
        public static readonly int SecondBit = 1;

        // Offset in reading destination IP bits offset
        public static readonly int ReadDestinationIPBitsOffset = 6;

        // Offset in reading source IP bits offset
        public static readonly int ReadSourceIPBitsOffset = 2;

        // Lenth of DataArray
        public static readonly int DataArrayBytes = 14;
    }
}