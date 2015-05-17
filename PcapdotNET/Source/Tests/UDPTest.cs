using NUnit.Framework;
using PcapdotNET.Protocols.TCP;
using PcapdotNET.Protocols.UDP;

namespace Tests
{
    [TestFixture]
    public class UDPTestFarme
    {
        [Test]
        public void TestGetDestinationIP()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<IUDPParser, UDPParser>();

            var frame = container.Create<UDPParser>();
            frame.FileReader(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");

            var testFrame = new UdpFrame();
            int[] destIp = { 10, 0, 0, 1 };
            int[] sourceIp = { 192, 168, 0, 143 };
            
            
            testFrame.SetDestinationIp(destIp);
            testFrame.SetDestinationPort(80);
            testFrame.SetLenght(54);
            testFrame.SetProtocolNumber(6);
            testFrame.SetSorcePort(3655);
            testFrame.SetSourceIp(sourceIp);
           
            Assert.True(testFrame.Equals(frame.GetUDPFrame()));
        }
    }
}
