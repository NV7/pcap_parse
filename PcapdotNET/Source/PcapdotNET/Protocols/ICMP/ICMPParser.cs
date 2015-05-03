using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapdotNET.Protocols.TCP;

namespace PcapdotNET.Protocols.ICMP
{
    public class IcmpParser
    {
         // Put here all info, collected from file
        //private readonly ArrayList EthernetFrameArray = new ArrayList();
        private readonly ArrayList _tcpFrameArray = new ArrayList();

        public IcmpParser(string fileName)
        {
            if (File.Exists(fileName))
            {
                var reader = new BinaryReader(File.Open(fileName, FileMode.Open));

                try
                {
                    // Missed header of file
                    reader.ReadBytes(PacketFields.PcapHeaderLength);

                    while (reader.ReadByte() > 0)
                    {
                        // Missed frame header
                        reader.ReadBytes(PacketFields.FrameHeaderLength);

                        // Read amount of bytes in this frame
                        uint frameLength = reader.ReadUInt32();

                        reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress);

                        // skip Ethernet info
                        reader.ReadBytes(PacketFields.AmountOfEthernetParts);
                        reader.ReadBytes(PacketFields.AmountOfEthernetParts);

                        // Missed
                        reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolId);

                        // Read Protocol Identificator
                        uint protocolNumber = reader.ReadByte();

                        // Missed
                        reader.ReadByte();
                        reader.ReadByte();

                        // Fill Source & Destination IP
                        var SourceIP = ReadSourceIp(ref reader);
                        ;
                        var DestinationIP = ReadDestinationIp(ref reader);

                        // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
                        var draftPort = new uint[PacketFields.AmountOfBytesInPortNumber];

                        for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i)
                            draftPort[i] = reader.ReadByte();

                        uint sourcePort = draftPort[0]*PacketFields.Offset + draftPort[1];

                        for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i)
                            draftPort[i] = reader.ReadByte();

                        uint destinationPort = draftPort[0]*PacketFields.Offset + draftPort[1];

                        // Fill current TCPandUDPFrame
                        var T = new ICMPFrame(DestinationIP, destinationPort, frameLength, SourceIP, sourcePort,
                            protocolNumber);

                        // Pull current TCPandUDPFrame to dump
                        _tcpFrameArray.Add(T);

                        // Miss ending of pcap-file, witch depends on FrameLength
                        reader.ReadBytes((int) (frameLength - PacketFields.EndingBytes));
                    }
                }

                    // TODO fix this bug with reading after file ending
                catch (Exception)
                {
                    var someExeption = new Exeption();
                    Console.WriteLine(someExeption.GetExeptionFromEndOfFile());
                }

                reader.Close();
            }
            else
            {
                var someExeption = new Exeption();
                Console.WriteLine(someExeption.GetExeptionFileNotFound());
             }
        }

        //Read Source Ip
        public int[] ReadSourceIp(ref System.IO.BinaryReader reader)
        {
            var sourceIp = new int[PacketFields.AmountOfIpParts];

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i)
                sourceIp[i] = reader.ReadByte();

            return sourceIp;
        }

        private int[] ReadDestinationIp(ref System.IO.BinaryReader reader)
        {
            var DestinationIP = new int[PacketFields.AmountOfIpParts];

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i)
                DestinationIP[i] = reader.ReadByte();

            return DestinationIP;
        }

        // Get this dump of processed frames
        public ArrayList GetTCPFrameList()
        {
            return _tcpFrameArray;
        }
    }
}
