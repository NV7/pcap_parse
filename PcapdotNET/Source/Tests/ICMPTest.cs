using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.ICMP;

namespace Tests
{
    [TestFixture]
    public class TestICMP
    {
        [Test]
        public void IcmpProtocolAmountOfFramesTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            Assert.AreEqual(test.ProtocolList.GetIcmpFrameList().Count, 77);
        }

        [Test]
        public void IcmpProtocolCheckDestinationIptest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            var _currentframe = (ICMPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetDestinationIp(), "10.10.10.11");
        }

        [Test]
        public void IcmpProtocolCheckSourceIptest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            var _currentframe = (ICMPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetSourceIp(), "74.125.236.132");
        }

        [Test]
        public void IcmpProtocolProtocolName()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            var _currentframe = (ICMPFrame) test.ProtocolList.GetFrameList()[1];

            Assert.AreEqual(_currentframe.GetProtocolName(), "ICMP");
        }
    }
}