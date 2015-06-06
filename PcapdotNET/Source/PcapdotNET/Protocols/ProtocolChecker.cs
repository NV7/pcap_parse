using System.Collections;
using System.Dynamic;
using System.IO;
using PcapdotNET.Protocols.UDP;

namespace PcapdotNET.Protocols
{
    public class ProtocolChecker
    {
        private string _foundProtocolName;
        private string _fileName;

        public ProtocolChecker(string fileName)
        {
            _fileName = fileName;
        }
        
        readonly ArrayList _udpFrameList = new ArrayList();

        readonly ArrayList _frameArray = new ArrayList();

        public ArrayList FrameList
        {
            get { return _udpFrameList; }
        }
       
        

        public ArrayList GetUdpFrameList()
        {
            return _udpFrameList;
        }

        public void ReadFile()
        {
            if (File.Exists(_fileName))
            {
                var reader = new BinaryReader(File.Open(_fileName, FileMode.Open));
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

                            byte[] dataArray = reader.ReadBytes((int)(frameLength - 40));
                            UdpParser temp = new UdpParser(); 
                            _frameArray.Add(temp.GetUdpPacket(dataArray));
                            _udpFrameList.Add(temp.GetUdpPacket(dataArray));
                            break;
                        }

                        default:
                        {
                            var result = "WTF!!!";
                            break;
                        }
                    }
                }
            }


        }
    }
}
