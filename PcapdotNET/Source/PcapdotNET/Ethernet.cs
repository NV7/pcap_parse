using System;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace PcapdotNET
{
    internal class Ethernet : IProtocol
    {
        private String FileName;

        public Ethernet(string fileName)
        {
            FileName = fileName;
        }

        private bool OpenFile()
        {
            var selectedDevice = new OfflinePacketDevice(fileName);
            using (PacketCommunicator communicator =
            selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))


            return true;
        }
    }
}