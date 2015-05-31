using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.Ethernet
{
    /// <summary>Parser Ethernet protocol
    /// This class read from .pcap file information about Ethernet protocol.
    /// </summary>
    public class EthernetParser : IEthernetParser
    {
        // Put here all info, collected from file
        private readonly ArrayList _ethernetFrameArray = new ArrayList();

        /// <summary>Method
        /// This method get parameter : file name and path to him ,and them read helpful information.
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var reader = new BinaryReader(File.Open(fileName, FileMode.Open));

                try
                {
                    // Missed header of file
                    reader.ReadBytes(PacketFields.PcapHeaderLength);

                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        // Missed frame header
                        reader.ReadBytes(PacketFields.FrameHeaderLength);

                        uint frameLength = reader.ReadUInt32();

                        reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress);

                        // Get Ethernet info
                        var ethernetDestinationIp = ReadDestinationIp(ref reader);

                        var ethernetSourceIp = ReadSourceIp(ref reader);

                        MissedBytes(ref reader);


                        var ethernetFrame = new EthernetFrame(ethernetDestinationIp, ethernetSourceIp);

                        // Pull current Ethernet frame to dump
                        _ethernetFrameArray.Add(ethernetFrame);

                        // Miss ending of .pcap file, witch depends on FrameLength
                        reader.ReadBytes((int) (frameLength - PacketFields.EndingBytes));
                    }
                }

                catch (MyException)
                {
                    var exception = new MyException("End of File!");
                    throw (exception);
                }

                reader.Close();
            }

                //Throw an exception if file not found
            else
            {
                var exception = new MyException("File not found!");
                throw (exception);
            }
        }

        /// <summary>Pass some bytes
        /// Missed some bytes
        /// </summary>
        /// <param name="reader"></param>
        internal void MissedBytes(ref System.IO.BinaryReader reader)
        {
            // Missed
            reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolId);

            // Read Protocol Identificator
            reader.ReadByte();

            // Missed
            reader.ReadByte();
            reader.ReadByte();

            reader.ReadBytes(PacketFields.AmountOfIpParts*2);


            // ReadUInt16 reads in another endian, so we have to use this trick ( multiply 256 is the same for 8 bit offset to the left)
            reader.ReadBytes(PacketFields.AmountOfBytesInPortNumber);

            reader.ReadBytes(PacketFields.AmountOfBytesInPortNumber);
        }

        /// <summary>Source Ip
        ///Read Source Ip from .pcap file 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private int[] ReadSourceIp(ref System.IO.BinaryReader reader)
        {
            var ethernetSourceIp = new int[PacketFields.AmountOfEthernetParts];
            for (var i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                ethernetSourceIp[i] = reader.ReadByte();

            return ethernetSourceIp;
        }

        /// <summary>Destination Ip
        /// Read Destination Ip from .pcap file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private int[] ReadDestinationIp(ref System.IO.BinaryReader reader)
        {
            var ethernetDestinationIp = new int[PacketFields.AmountOfEthernetParts];
            for (var i = 0; i < PacketFields.AmountOfEthernetParts; ++i)
                ethernetDestinationIp[i] = reader.ReadByte();

            return ethernetDestinationIp;
        }

        /// <summary>Get Ethernet Frame
        /// Get Array list there [0] - Destination Ip; [1] - Source Ip; [2] - Ethernet Frame;
        /// </summary>
        /// <returns></returns>
        public EthernetFrame GetEthernetFrame()
        {
            return (EthernetFrame)_ethernetFrameArray[0];
        }

        /// <summary>Get Ethernet Frame List
        /// Get Array list 
        /// </summary>
        /// <returns>ArrayList -ethernetFrameArray</returns>
        public ArrayList GetEthernetFrameList()
        {
            return _ethernetFrameArray;
        }

        /// <summary>Use in LightInject
        /// This method refers to IoC Container
        /// </summary>
        public void IEthernetParser()
        {
            throw new NotImplementedException();
        }
    }
}
