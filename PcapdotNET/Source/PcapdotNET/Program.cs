using System;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace ReadingPacketsFromADumpFile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create the offline device
            var selectedDevice = new OfflinePacketDevice("D:/TempC#/MSVS2013/PcapdotNET/Source/PcapdotNET/tcp-dns.pcap");

            // Open the capture file
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536, // portion of the packet to capture
                    // 65536 guarantees that the whole packet will be captured on all the link layers
                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                    1000)) // read timeout
            {
                // Read and dispatch packets until EOF is reached
                communicator.ReceivePackets(0, DispatcherHandler);
            }
        }

        private static void DispatcherHandler(Packet packet)
        {
            // print packet timestamp and packet length
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);
            Console.WriteLine("Read only packet: " + packet.IsReadOnly);
            Console.WriteLine("Valid packet:" + packet.IsValid);
            Console.WriteLine("Datalink kind:" + packet.DataLink.Kind);
            Console.WriteLine("Ethernet II Src:" + packet.Ethernet.Source);
            Console.WriteLine("Ethernet II Dst:" + packet.Ethernet.Destination);
            Console.WriteLine("Header length:" + packet.Ethernet.HeaderLength);
            Console.WriteLine("Ethernet type:" + packet.Ethernet.EtherType);
            Console.WriteLine("Protocol:" + packet.Ethernet.IpV4.Protocol);


            // Print the packet
            //const int LineLength = 64;
            //for (int i = 0; i != packet.Length; ++i)
            //{
            //   Console.Write((packet[i]).ToString("X2"));
            //    if ((i + 1) % LineLength == 0)
            //      Console.WriteLine();
            //}

            // Easiest way to determine highest level protocol
            //if (packet.Ethernet.EtherType == EthernetType.IpV4)
            //{
            //    if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Tcp)
            //    {
            //        if (packet.Ethernet.IpV4.Tcp.DestinationPort == 80) //HTTP
            //        ...
            //        else
            //            if (packet.Ethernet.IpV4.Tcp.DestinationPort == 21) //FTP
            //            ...
            //    }
            //    else if (packet.Ethernet.IpV4.Protocol == IpV4Protocol.Udp)
            //    {
            //        if (packet.Ethernet.IpV4.Udp.DestinationPort == 53) //DNS
            //        ...
            //        else
            //            if (packet.Ethernet.IpV4.Udp.DestinationPort == 69) //TFTP
            //            ...
            //    }
            //}
            //else if (packet.Ethernet.EtherType == EthernetType.IpV6)
            //{
            //...
            //}
            //else if (packet.Ethernet.EtherType == EthernetType.Arp)
            //{
            //...
            //}


            Console.WriteLine();
            Console.WriteLine();


            // print ip addresses and udp ports
            //if (packet.Ethernet.IpV4.Source.ToString() != "0.0.0.0")
            Console.WriteLine(packet.Ethernet.IpV4.Source + ":" + packet.Ethernet.IpV4.Udp.SourcePort + " -> " +
                              packet.Ethernet.IpV4.Destination + ":" + packet.Ethernet.IpV4.Udp.DestinationPort);


            Console.WriteLine("***********************");
            Console.WriteLine();
        }
    }
}