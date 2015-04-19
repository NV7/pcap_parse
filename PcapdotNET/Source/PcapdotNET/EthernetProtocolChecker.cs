//using System;
//using PcapDotNet.Core;
//using PcapDotNet.Packets;

//namespace PcapdotNET
//{
//    internal class EthernetProtocolChecker : IProtocol
//    {
//        private String FileName;

//        public EthernetProtocolChecker(string fileName)
//        {
//            FileName = fileName;
//        }

//        // Get Transmission date, formt: 
//        public String GetTimeOfTransmission()
//        {
//            //portion of the packet to capture 65536 guarantees that the whole packet will be captured on all the link layers
//            using (
//                PacketCommunicator communicator = new OfflinePacketDevice(FileName).Open(65536,
//                    PacketDeviceOpenAttributes.Promiscuous, 1000))
//            communicator.SetFilter("ether");

//            return communicator.ReceivePackets(0, DispatcherHandler);
//        }

//    }
//}