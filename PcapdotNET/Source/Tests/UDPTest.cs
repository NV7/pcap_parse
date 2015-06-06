using System;
using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.UDP;

namespace Tests
{
    [TestFixture]
    public class UDPTestFarme
    {
        [Test]
        public void TestGetDestinationIP()
        {
            //var container = new LightInject.ServiceContainer();
            //container.Register<IUDPParser, UdpParser>();

            //var frame = container.Create<UdpParser>();
            //frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");

            var frame = new ProtocolChecker(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");

            frame.ReadFile();
            

            //ReadFile(@"..\..\..\Source\Tests\Testfiles\udp_protocol.pcap");


            var testFrame = new UDPFrame();
            int[] destIp = {10, 0, 0, 1};
            int[] sourceIp = {192, 168, 0, 143};


            testFrame.SetDestinationIp(destIp);
            testFrame.SetDestinationPort(80);
            testFrame.SetLenght(54);
            testFrame.SetProtocolNumber(6);
            testFrame.SetSorcePort(3655);
            testFrame.SetSourceIp(sourceIp);

            foreach (var currentFrame in frame.FrameList)
            {
                Console.WriteLine(currentFrame);
            }

            //Assert.True(testFrame.Equals(frame.GetUdpFrameList()));
        }
    }
}