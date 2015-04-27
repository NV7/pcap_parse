using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.TCP;

namespace Tests
{
    [TestFixture]
    public class TestTCPFrameParse
    {
        [Test]
        {

        }

        [Test]
        public void TestGetDestinationIP()
        {

            Assert.That(Frame.GetDestinationIP(), Is.EqualTo("10.0.0.1"));
        }

        [Test]
        public void TestGetDestinationPort()
        {

            Assert.That(Frame.GetDestinationPort(), Is.EqualTo("80"));
        }

        [Test]
        public void TestGetFrameLength()
        {

            Assert.That(Frame.GetFrameLength(), Is.EqualTo("54"));
        }

        [Test]
        public void TestGetProtocolNumberMethod()
        {

            Assert.That(Frame.GetProtocolNumber(), Is.EqualTo("6"));
        }

        [Test]
        public void TestGetSourceIP()
        {

            Assert.That(Frame.GetSourceIP(), Is.EqualTo("192.168.0.143"));
        }

        [Test]
        public void TestGetSourcePort()
        {

            Assert.That(Frame.GetSourcePort(), Is.EqualTo("3655"));
        }

        [Test]
        public void UDPProtocolTest()
        {

            Assert.That(Frame.GetProtocolName(), Is.EqualTo("UDP"));
        }
    }
}