using System;
using NUnit.Framework;
using PcapdotNET.Protocols;
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

            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\tpncp_udp.pcap");

            Console.WriteLine(test.ProtocolList.GetUdpFrameList().Count);

            var testFrame = new UDPFrame();
            int[] destIp = { 10, 0, 0, 1 };
            int[] sourceIp = { 192, 168, 0, 143 };


            testFrame.SetDestinationIp(destIp);
            testFrame.SetDestinationPort(80);
            testFrame.SetLenght(54);
            testFrame.SetProtocolNumber(6);
            testFrame.SetSorcePort(3655);
            testFrame.SetSourceIp(sourceIp);

            // Assert.True(testFrame.Equals(frame.GetUdpFrame()));
        }
    }
}
