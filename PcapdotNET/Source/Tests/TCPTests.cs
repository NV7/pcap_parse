using System;
using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.TCP;

namespace Tests
{
    [TestFixture]
    public class TestTCPFrameParse
    {
        [Test]
        public void NoFileTest()
        {
            var T = new FileParser("D:/loopback-udp-dns.pcap");
            Console.WriteLine(T.GetTCPFrameList().Capacity);

            foreach (TCPandUDPFrame Element in T.GetTCPFrameList())
            {
                Console.WriteLine(Element.GetInformation());
            }
        }
    }
}