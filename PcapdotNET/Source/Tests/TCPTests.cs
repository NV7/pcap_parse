using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.TCP;

namespace Tests
{
    [TestFixture]
    public class TestFrameParse
    {
        [Test]
        public void TcpProtocolAmountOfFramesTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            Assert.AreEqual(test.ProtocolList.GetTcpFrameList().Count, 7);
        }

        [Test]
        public void TcpProtocolNameTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            var _currentframe = (TCPFrame)test.ProtocolList.GetFrameList()[0];

            Assert.AreEqual(_currentframe.GetProtocolName(), "TCP");
        }

        [Test]
        public void TcpProtocolSourceIPTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            var _currentframe = (TCPFrame)test.ProtocolList.GetFrameList()[0];

            Assert.AreEqual(_currentframe.GetSourceIp(), "127.0.0.1");
        }

        [Test]
        public void TcpProtocolDestIPTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            var _currentframe = (TCPFrame)test.ProtocolList.GetFrameList()[0];

            Assert.AreEqual(_currentframe.GetDestinationIp(), "127.0.0.1");
        }

        [Test]
        public void TcpProtocolDestPortTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            var _currentframe = (TCPFrame)test.ProtocolList.GetFrameList()[0];

            Assert.AreEqual(_currentframe.GetDestinationPort(), "5353");
        }

        [Test]
        public void TcpProtocolSrcPortTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            var _currentframe = (TCPFrame)test.ProtocolList.GetFrameList()[0];

            Assert.AreEqual(_currentframe.GetSourcePort(), "32921");
        }

    }
}