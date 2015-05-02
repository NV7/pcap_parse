using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.TCP;

namespace Tests
{
    [TestFixture]
    public class TestTCPFrameParse
    {
        [Test]
        public void EthernetProtocolTest()
        {
            // All, that we could get from ethernet - source and dest ips
            var Eth = new FileParser("E:/Testfiles/udp_protocol.pcap");
            var Frame = (EthernetFrame) Eth.GetEthernetFrameList()[0];

            Assert.That(Frame.GetDestinationIP(), Is.EqualTo("34.4B.50.B7.EF.8"));
            Assert.That(Frame.GetSourceIP(), Is.EqualTo("36.4B.50.B7.EF.6B"));
        }

        //[Test]
        //public void ICMPProtocolTest()
        //{
        //    var ICMP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/icmp_protocol.cap");
        //    var Frame = (TCPandUDPFrame) (ICMP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetProtocolName(), Is.EqualTo("ICMP"));
        //}

        //[Test]
        //public void TCPProtocolTest()
        //{
        //    var TCP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/tcp_protocol.pcap");
        //    foreach (TCPandUDPFrame element in TCP.GetTCPFrameList())
        //    {
        //        Assert.That(element.GetProtocolName(), Is.EqualTo("TCP"));
        //    }
        //}

        //[Test]
        //public void TestGetDestinationIP()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetDestinationIP(), Is.EqualTo("10.0.0.1"));
        //}

        //[Test]
        //public void TestGetDestinationPort()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetDestinationPort(), Is.EqualTo("80"));
        //}

        //[Test]
        //public void TestGetFrameLength()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetFrameLength(), Is.EqualTo("54"));
        //}

        //[Test]
        //public void TestGetProtocolNumberMethod()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetProtocolNumber(), Is.EqualTo("6"));
        //}

        //[Test]
        //public void TestGetSourceIP()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetSourceIP(), Is.EqualTo("192.168.0.143"));
        //}

        //[Test]
        //public void TestGetSourcePort()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[0];

        //    Assert.That(Frame.GetSourcePort(), Is.EqualTo("3655"));
        //}

        //[Test]
        //public void UDPProtocolTest()
        //{
        //    var UDP = new FileParser("D:/GITHUB/pcap_parse/PcapdotNET/Source/Tests/Testfiles/udp_protocol.pcap");
        //    var Frame = (TCPandUDPFrame) (UDP.GetTCPFrameList())[1];

        //    Assert.That(Frame.GetProtocolName(), Is.EqualTo("UDP"));
        //}
    }
}