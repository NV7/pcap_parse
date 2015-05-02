using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.Ethernet
{
    class EthernetParser
    {
        // Put here all info, collected from file
        private readonly ArrayList EthernetFrameArray = new ArrayList();
        
        public EthernetParser(string _FileName)
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
                        // Missed frame header
                        reader.ReadBytes(PacketFields.FrameHeaderLength);

                        uint frameLength = reader.ReadUInt32();

                        // Read amount of bytes in this frame
                        reader.ReadUInt32();

                        reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress);

                        // Get Ethernet info
                        var ethernetDestinationIp = ReadDestinationIp(ref reader);

                        var ethernetSourceIp = ReadSourceIp(ref reader);

                        MissedBytes(ref reader);
                        

                        var ethernetFrame = new EthernetFrame(ethernetDestinationIp, ethernetSourceIp);

                        // Pull current Ethernet frame to dump
                        EthernetFrameArray.Add(ethernetFrame);

                        // Miss ending of pcap-file, witch depends on FrameLength
                        reader.ReadBytes((int) (frameLength - PacketFields.EndingBytes));
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

        internal void MissedBytes(ref System.IO.BinaryReader reader)
        {
            // Missed
            reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolID);

            // Read Protocol Identificator
            reader.ReadByte();

            // Missed
            reader.ReadByte();
            reader.ReadByte();

            reader.ReadBytes(PacketFields.AmountOfIPParts * 2);


            // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
            reader.ReadBytes(PacketFields.AmountOfBytesInPortNumber);

            reader.ReadBytes(PacketFields.AmountOfBytesInPortNumber);
        }
        private int[] ReadSourceIp(ref System.IO.BinaryReader reader)
        {
            var EthernetSourceIP = new int[PacketFields.AmountOfEthernetParts];
            for (int i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                EthernetSourceIP[i] = reader.ReadByte();

            return EthernetSourceIP;
        }
        private int[] ReadDestinationIp(ref System.IO.BinaryReader reader)
        {
            var ethernetDestinationIp = new int[PacketFields.AmountOfEthernetParts];
            for (int i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                ethernetDestinationIp[i] = reader.ReadByte();

            return ethernetDestinationIp;
        }
        
        public ArrayList GetEthernetFrameList()
        {
            return EthernetFrameArray;
        }
    }
}
