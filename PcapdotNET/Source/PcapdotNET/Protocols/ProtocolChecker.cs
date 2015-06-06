using System.Collections;
using System.IO;
using PcapdotNET.Protocols.UDP;

namespace PcapdotNET.Protocols
{
    public class ProtocolChecker
    {
        readonly ArrayList _udpFrameList = new ArrayList();

        readonly ArrayList _tcpFrameList = new ArrayList();

        readonly ArrayList _frameArray = new ArrayList();

        public ArrayList GetUdpFrameList()
        {
            return _udpFrameList;
        }

        public ArrayList GetTcpFrameList()
        {
            return _tcpFrameList;
        }

        public void ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
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

                    switch (protocolNumber)
                    {
                        case 6:
                            {
                                var dataArray = reader.ReadBytes(14);
                                UdpParser temp = new UdpParser();
                                _frameArray.Add(temp.GetUdpPacket(dataArray));
                                _tcpFrameList.Add(temp.GetUdpPacket(dataArray));
                                reader.ReadBytes((int)(frameLength - PacketFields.EndingBytes));
                                break;
                            }

                        case 17:
                            {
                                var dataArray = reader.ReadBytes(14);
                                UdpParser temp = new UdpParser();
                                _frameArray.Add(temp.GetUdpPacket(dataArray));
                                _udpFrameList.Add(temp.GetUdpPacket(dataArray));
                                reader.ReadBytes((int)(frameLength - PacketFields.EndingBytes));
                                break;
                            }

                        default:
                            {
                                reader.ReadBytes((int)(frameLength - PacketFields.EndingBytes + 14));
                                break;
                            }
                    }
                }
            }


        }
    }
}
