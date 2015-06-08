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
        /// <summary>
        /// array, that contains protocols
        /// </summary>
        private readonly ProtocolList _protocolList = new ProtocolList();

        /// <summary>
        /// Getter, that returns protocollist
        /// </summary>
        public ProtocolList ProtocolList
        {
            get { return _protocolList; }
        }

        /// <summary>Open and read pcap file
        /// Read information from pcap file
        /// </summary>
        /// <param name="fileName">string Path to file</param>
        public void ReadFile(string fileName)
        {
            if (!File.Exists(fileName)) throw new ContentException(fileName);
            var container = new LightInject.ServiceContainer();
            container.Register<IProtocolChecker<EthernetFrame>, EthernetParser>("Ethernet");
            container.Register<IProtocolChecker<ICMPFrame>, ICMPParser>("ICMP");
            container.Register<IProtocolChecker<TCPFrame>, TCPParser>("TCP");
            container.Register<IProtocolChecker<UDPFrame>, UdpParser>("UDP");

            var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
            // Missed header of file
            reader.ReadBytes(PacketFields.PcapHeaderLength);

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                // Missed frame header
                reader.ReadBytes(PacketFields.FrameHeaderLength); //8

                // Read amount of bytes in this frame
                uint frameLength = reader.ReadUInt32(); //4
                ProtocolList.FrameLengthSequence.Add(frameLength);

                reader.ReadBytes(PacketFields.BytesBetweenHeaderOfFrameAndEthernetAdress); //4

                // skip Ethernet info
                reader.ReadBytes(PacketFields.AmountOfEthernetParts); //6
                reader.ReadBytes(PacketFields.AmountOfEthernetParts); //6

                // Missed
                reader.ReadBytes(PacketFields.AmountOfBytesBeforeProtocolId); //11

                // Read Protocol Identificator
                uint protocolNumber = reader.ReadByte(); //1
                ProtocolList.ProtocolSequence.Add(protocolNumber);
                // byte[] dataArray = new byte[(int)(frameLength - 40)];

                var dataArray = reader.ReadBytes(PacketFields.DataArrayBytes);

                // Here 1 for ICMP, 6 for TCP and 17 for UDP
                switch (protocolNumber)
                {
                    case 1:
                    {
                        var instance = container.GetInstance<IProtocolChecker<ICMPFrame>>("ICMP");
                        ProtocolList.FrameArray.Add(instance.GetPacket(dataArray));
                        ProtocolList.IcmpFrameList.Add(instance.GetPacket(dataArray));

                        break;
                    }

                    case 6:
                    {
                        var instance = container.GetInstance<IProtocolChecker<TCPFrame>>("TCP");
                        ProtocolList.FrameArray.Add(instance.GetPacket(dataArray));
                        ProtocolList.TcpFrameList.Add(instance.GetPacket(dataArray));

                        break;
                    }

                    case 17:
                    {
                        var instance = container.GetInstance<IProtocolChecker<UDPFrame>>("UDP");
                        ProtocolList.FrameArray.Add(instance.GetPacket(dataArray));
                        ProtocolList.UdpFrameList.Add(instance.GetPacket(dataArray));
                               
                        break;
                    }

                    default:
                    {
                        var instance = container.GetInstance<IProtocolChecker<EthernetFrame>>("Ethernet");
                        ProtocolList.FrameArray.Add(instance.GetPacket(dataArray));
                        ProtocolList.UdpFrameList.Add(instance.GetPacket(dataArray));
                            
                        break;
                    }
                        
                }
                reader.ReadBytes((int)(frameLength - PacketFields.EndingBytes));
            }
            reader.Close();
        }
    }
}
