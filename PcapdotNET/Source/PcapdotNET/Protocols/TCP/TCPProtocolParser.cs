using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.TCP
{
    // Processing pcap file
    public class TCPProtocolParser
    {
        private readonly ArrayList TCPFrameArray = new ArrayList();
        private string FileName; // Checked file name

        public TCPProtocolParser(string _FileName)
        {
            if (File.Exists(_FileName))
            {
                var reader = new BinaryReader(File.Open(_FileName, FileMode.Open));

                try
                {
                    // Missed header of file
                    reader.ReadBytes(24);

                    while (reader.ReadByte() != -1)
                    {
                        // Variables for TCPFrame filling
                        var DestinationIP = new int[4];

                        uint DestinationPort;

                        uint FrameLength;

                        var SourceIP = new int[4];

                        uint SourcePort;

                        uint ProtocolNumber;


                        // Missed frame header
                        reader.ReadBytes(7);

                        // Read amount of bytes in this frame
                        FrameLength = reader.ReadUInt32();

                        // Missed
                        reader.ReadBytes(27);

                        // Read Protocol Identificator
                        ProtocolNumber = reader.ReadByte();

                        // Missed
                        reader.ReadByte();
                        reader.ReadByte();

                        // Fill Source & Destination IP
                        for (int i = 0; i < 4; ++i)
                            SourceIP[i] = reader.ReadByte();

                        for (int j = 0; j < 4; ++j)
                            DestinationIP[j] = reader.ReadByte();


                        // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
                        var DraftPort = new uint[2];

                        for (int i = 0; i < 2; ++i)
                            DraftPort[i] = reader.ReadByte();

                        SourcePort = DraftPort[0]*256 + DraftPort[1];


                        for (int i = 0; i < 2; ++i)
                            DraftPort[i] = reader.ReadByte();

                        DestinationPort = DraftPort[0]*256 + DraftPort[1];

                        // Fill current TCPFrame
                        var T = new TCPFrame(DestinationIP, DestinationPort, FrameLength, SourceIP, SourcePort,
                            ProtocolNumber);

                        // Pull current TPFrame to dump
                        TCPFrameArray.Add(T);

                        // Miss ending of pcap-file, witch depends on FrameLength
                        reader.ReadBytes((int) (FrameLength - 38));

                    }
                }

                    // TODO fix this bug with reading after file ending
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else throw new FileNotFoundException();
        }

        // Get this dump of processed frames
        public ArrayList GetTCPFrameList()
        {
            return TCPFrameArray;
        }
    }
}