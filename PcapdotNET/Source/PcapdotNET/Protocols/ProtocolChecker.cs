using System;
using System.Collections;
using System.IO;
using PcapdotNET.Protocols.Ethernet;
using PcapdotNET.Protocols.ICMP;
using PcapdotNET.Protocols.TCP;
using PcapdotNET.Protocols.UDP;

namespace PcapdotNET.Protocols
{
    public class ProtocolChecker
    {
        
        readonly ArrayList _udpFrameList = new ArrayList();

        readonly ArrayList _tcpFrameList = new ArrayList();

        readonly ArrayList _frameArray = new ArrayList();

        readonly  ArrayList _ICMPFrameList = new ArrayList();

        readonly ArrayList _EthernetFrameList = new ArrayList();

        public ArrayList GetEthernetFrameList()
        {
            return _EthernetFrameList;
        }

        public ArrayList GetIcmpFrameList()
        {
            return _ICMPFrameList;
        }

        public ArrayList GetUdpFrameList()
        {
            return _udpFrameList;
        }

        public ArrayList GetTcpFrameList()
        {
            return _tcpFrameList;
        }

        public ArrayList GetFrameList()
        {
            return _frameArray;
        }

        /// <summary>Open and read pcap file
        /// Read information from pcap file
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var container = new LightInject.ServiceContainer();
                container.Register<ITCPParser, TCPParser>();
                container.Register<iICMPParser, ICMPParser>();
                container.Register<IEthernetParser, EthernetParser>();
                container.Register<IUDPParser, UdpParser>();

                var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
                // Missed header of file
                reader.ReadBytes(PacketFields.PcapHeaderLength);

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Missed frame header
                    reader.ReadBytes(PacketFields.FrameHeaderLength); //8

                    // Read amount of bytes in this frame
                    uint frameLength = reader.ReadUInt32(); //4

                    reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress); //4

                    // skip Ethernet info
                    reader.ReadBytes(PacketFields.AmountOfEthernetParts); //6
                    reader.ReadBytes(PacketFields.AmountOfEthernetParts); //6

                    // Missed
                    reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolId); //11

                    // Read Protocol Identificator
                    uint protocolNumber = reader.ReadByte(); //1
                    // byte[] dataArray = new byte[(int)(frameLength - 40)];

                    var dataArray = reader.ReadBytes(14);

                    switch (protocolNumber)
                    {
                        case 1:
                            {                                
                                var frame = container.Create<ICMPParser>();
                                _frameArray.Add(frame.GetICMPPackets(dataArray));
                                _ICMPFrameList.Add(frame.GetICMPPackets(dataArray));

                                break;
                            }

                        case 6:
                        {
                            var frame = container.Create<TCPParser>();
                            _frameArray.Add(frame.GetTCPPacket(dataArray));
                            _tcpFrameList.Add(frame.GetTCPPacket(dataArray));

                            break;
                            }

                        case 17:
                            {
                               var frame = container.Create<UdpParser>();
                               _frameArray.Add(frame.GetUdpPacket(dataArray));
                               _udpFrameList.Add(frame.GetUdpPacket(dataArray));
                               
                                break;
                            }

                        default:
                        {
                            var frame = container.Create<EthernetParser>();
                            _frameArray.Add(frame.GetEthernetPacket(dataArray));
                            _udpFrameList.Add(frame.GetEthernetPacket(dataArray));
                            
                            break;
                        }
                        
                    }
                    reader.ReadBytes((int)(frameLength - PacketFields.EndingBytes));
                }
            }


        }
    }
}
