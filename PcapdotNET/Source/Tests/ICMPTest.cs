using System;
using NUnit.Framework;
using PcapdotNET.Protocols.ICMP;

namespace Tests
{
    [TestFixture]
    public class TestICMP
    {
        /*Information Test
         * ###########           
         * 74.125.236.132:0 -> 10.10.10.11:39547
         * FrameLength : 1514
         * Protocol: ICMP
         */
        [Test]
        public void IcmpProtocolTest()
        {
            var container = new LightInject.ServiceContainer();
            container.Register<iICMPParser, ICMPParser>();
            var frame = container.Create<ICMPParser>();
            frame.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.cap");
           
            int[] destIp = {10,10,10,11};
            int[] sourceIp = {74,125,236,132};
           
            ICMPFrame testFrame = new ICMPFrame();
            testFrame.SetDestinationIp(destIp);
            testFrame.SetDestinationPort(39547);
            testFrame.SetProtocolLenght(1514);
            testFrame.SetProtocolNumber(1);
            testFrame.SetSourcePort(0);
            testFrame.SetSuorceIp(sourceIp);
            
            Assert.True(testFrame.Equals(frame.GetIcmpFrame()));
          }
    }
}
