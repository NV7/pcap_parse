using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.TCP
{
    // Processing pcap file
    public class FileParser
    {
        // Put here all info, collected from file
        private readonly ArrayList EthernetFrameArray = new ArrayList();
        private readonly ArrayList TCPFrameArray = new ArrayList();
        //private string FileName; // Checked file name

        public FileParser(string _FileName)
        {
            if (File.Exists(_FileName))
            {
                var reader = new BinaryReader(File.Open(_FileName, FileMode.Open));

                try
                {
                    // Missed header of file
                    reader.ReadBytes(PacketFields.PcapHeaderLength);

                    while (reader.ReadByte() > 0)
                    {
                        // Variables for TCPandUDPFrame filling
                        var DestinationIP = new int[PacketFields.AmountOfIPParts];

                        uint DestinationPort;

                        uint FrameLength;

                        var SourceIP = new int[PacketFields.AmountOfIPParts];

                        uint SourcePort;

                        uint ProtocolNumber;

                        var EthernetDestinationIP = new int[PacketFields.AmountOfEthernetParts];

                        var EthernetSourceIP = new int[PacketFields.AmountOfEthernetParts];


                        // Missed frame header
                        reader.ReadBytes(PacketFields.FrameHeaderLength);

                        // Read amount of bytes in this frame
                        FrameLength = reader.ReadUInt32();

                        reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress);

                        // Get Ethernet info
                        for (int i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                            EthernetDestinationIP[i] = reader.ReadByte();

                        for (int i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                            EthernetSourceIP[i] = reader.ReadByte();

                        // Missed
                        reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolID);

                        // Read Protocol Identificator
                        ProtocolNumber = reader.ReadByte();

                        // Missed
                        reader.ReadByte();
                        reader.ReadByte();

                        // Fill Source & Destination IP
                        for (int i = 0; i < PacketFields.AmountOfIPParts; ++i)
                            SourceIP[i] = reader.ReadByte();

                        for (int j = 0; j < PacketFields.AmountOfIPParts; ++j)
                            DestinationIP[j] = reader.ReadByte();


                        // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
                        var DraftPort = new uint[PacketFields.AmountOfBytesInPortNumber];

                        for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i)
                            DraftPort[i] = reader.ReadByte();

                        SourcePort = DraftPort[0]*256 + DraftPort[1];


                        for (int i = 0; i < PacketFields.AmountOfBytesInPortNumber; ++i)
                            DraftPort[i] = reader.ReadByte();

                        DestinationPort = DraftPort[0]*PacketFields.Offset + DraftPort[1];

                        var E = new EthernetFrame(EthernetDestinationIP, EthernetSourceIP);

                        // Fill current TCPandUDPFrame
                        var T = new TCPandUDPFrame(DestinationIP, DestinationPort, FrameLength, SourceIP, SourcePort,
                            ProtocolNumber);

                        // Pull current TCPandUDPFrame to dump
                        TCPFrameArray.Add(T);

                        // Pull current Ethernet frame to dump
                        EthernetFrameArray.Add(E);

                        // Miss ending of pcap-file, witch depends on FrameLength
                        reader.ReadBytes((int) (FrameLength - PacketFields.EndingBytes));
                    }
                }

                    // TODO fix this bug with reading after file ending
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                reader.Close();
            }
            else throw new FileNotFoundException();
        }

        // Get this dump of processed frames
        public ArrayList GetTCPFrameList()
        {
            return TCPFrameArray;
        }

        public ArrayList GetEthernetFrameList()
        {
            return EthernetFrameArray;
        }
    }
}