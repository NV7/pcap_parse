using NUnit.Framework;
using PcapdotNET.Protocols.Ethernet;
using PcapdotNET.Protocols.ICMP;
using PcapdotNET.Protocols.TCP;
using PcapdotNET.Protocols.UDP;

namespace Tests
{
    
    [TestFixture]
    public class TestFrameParse
    {
        
        [Test]
        public void EthernetProtocolTest()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<IEthernetParser, EthernetParser>();
            
            var frame = container.Create<EthernetParser>();

            frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");

            Assert.That(frame.GetEthernetFrameList().GetDestinationIp(), Is.EqualTo("34.4B.50.B7.EF.8"));
            Assert.That(frame.GetEthernetFrameList().GetSourceIP(), Is.EqualTo("36.4B.50.B7.EF.6B"));
        }

        [Test]
        public void IcmpProtocolTest()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<iICMPParser, ICMPParser>();
            
            var frame = container.Create<ICMPParser>();
            frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.cap");

            Assert.That(frame.GetIcmpFrame().GetProtocolName(), Is.EqualTo("ICMP"));
        }

        [Test]
        public void TcpProtocolTest()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<ITCPParser,TCPParser>();

            var frame = container.Create<TCPParser>();

            frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");
            
            Assert.That(frame.GetTCPFrame().GetProtocolName(), Is.EqualTo("TCP"));
        }

        [Test]
        public void TestGetDestinationIP()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<IUDPParser,UDPParser>();

            var frame = container.Create<UDPParser>();
            frame.FileReader(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");
            
            Assert.That(frame.GetUDPFrame().GetDestinationIp(), Is.EqualTo("10.0.0.1"));
            Assert.That(frame.GetUDPFrame().GetDestinationPort(), Is.EqualTo("80"));
            Assert.That(frame.GetUDPFrame().GetFrameLength(), Is.EqualTo("54"));
            Assert.That(frame.GetUDPFrame().GetProtocolNumber(), Is.EqualTo("6"));
            Assert.That(frame.GetUDPFrame().GetSourceIp(), Is.EqualTo("192.168.0.143"));
            Assert.That(frame.GetUDPFrame().GetSourcePort(), Is.EqualTo("3655"));
            Assert.That(frame.GetUDPFrame().GetProtocolName(), Is.EqualTo("TCP"));
        }
    }
}