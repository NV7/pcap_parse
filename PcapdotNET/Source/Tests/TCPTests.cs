using NUnit.Framework;
using PcapdotNET.Protocols.TCP;

namespace Tests
{
    [TestFixture]
    public class TestFrameParse
    {
        [Test]
        public void TcpProtocolTest()
        {
            var container = new LightInject.ServiceContainer();  
            container.Register<ITCPParser,TCPParser>();

            var frame = container.Create<TCPParser>();

            frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\tcp_protocol.pcap");

            int[] destIp = { 127, 0, 0, 1 };
            int[] sourceIp = { 127, 0, 0, 1 };

            var testFrame = new TCPFrame();
            testFrame.SetDestinationIp(destIp);
            testFrame.SetDestinationPort(5353);
            testFrame.SetFrameLenght(74);
            testFrame.SetProtocolNumber(6);
            testFrame.SetSourcePort(32921);
            testFrame.SetSourceIp(sourceIp);


            Assert.True(testFrame.Equals(frame.GetTCPFrame()));
           }
    }
}