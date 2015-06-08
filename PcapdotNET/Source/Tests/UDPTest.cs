using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.UDP;

namespace Tests
{
    [TestFixture]
    public class UDPTestFarme
    {
        [Test]
        public void UdpProtocolAmountOfFramesTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_procol.pcap");

            Assert.AreEqual(test.ProtocolList.GetUdpFrameList().Count, 6);
        }

        [Test]
        public void UdpProtocolCheckDestinationIptest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_procol.pcap");

            var _currentframe = (UDPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetDestinationIp(), "192.168.0.1");
        }

        [Test]
        public void UdpProtocolCheckSourceIptest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_procol.pcap");

            var _currentframe = (UDPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetSourceIp(), "192.168.0.143");
        }

        [Test]
        public void UdpProtocolProtocolName()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_procol.pcap");

            var _currentframe = (UDPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetProtocolName(), "UDP");
        }
    }
}