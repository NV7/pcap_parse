﻿using System;
using System.Collections;
using System.IO;

namespace PcapdotNET.Protocols.UDP
{
    /// <summary>UDP Parser
    /// Class UDP Parser
    /// </summary>
    public class UDPParser : IUDPParser
    {
        private readonly ArrayList _tcpFrameArray = new ArrayList();

        /// <summary>Method wich read .pcap file
        /// Method Udp Parser which read information from .pcap file
        /// </summary>
        /// <param name="fileName"></param>
        public void FileReader(string fileName)
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
                        var T = new UdpFrame(DestinationIP, destinationPort, frameLength, SourceIP, sourcePort,
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

        /// <summary>Read Source Ip
        /// Read information about source Ip
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private int[] ReadSourceIp(ref System.IO.BinaryReader reader)
        {
            var SourceIP = new int[PacketFields.AmountOfIpParts];

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i)
                SourceIP[i] = reader.ReadByte();

            return SourceIP;
        }

        /// <summary>Destination Ip
        /// Read information about destination Ip
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private int[] ReadDestinationIp(ref System.IO.BinaryReader reader)
        {
            var DestinationIP = new int[PacketFields.AmountOfIpParts];

            for (int i = 0; i < PacketFields.AmountOfIpParts; ++i)
                DestinationIP[i] = reader.ReadByte();

            return DestinationIP;
        }
        
        /// <summary>Return UPD Frame 
        ///  Get this dump of processed frames
        /// </summary>
        /// <returns></returns>
        public UdpFrame GetUDPFrame()
        {
            return (UdpFrame)_tcpFrameArray[0];
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
