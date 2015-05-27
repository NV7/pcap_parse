using System;
using NUnit.Framework;
using PcapdotNET.Protocols.Ethernet;

namespace Tests
{
    [TestFixture]
    public class EthernetParse
    {
        
        [Test]
        public void EthernetProtocolTest()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<IEthernetParser, EthernetParser>();
            
            var frame = container.Create<EthernetParser>();
           frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");

            Assert.That(frame.GetEthernetFrame().GetDestinationIp(), Is.EqualTo("34.4B.50.B7.EF.8"));
            Assert.That(frame.GetEthernetFrame().GetSourceIP(), Is.EqualTo("36.4B.50.B7.EF.6B"));
            Console.WriteLine(frame.GetEthernetFrame().GetSourceIP());        
        }
    }
}
