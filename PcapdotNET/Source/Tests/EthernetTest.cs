using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.Ethernet;

namespace Tests
{
    [TestFixture]
    internal class EthernetTest
    {
        [Test]
        public void EthernetGetEachIPTest()
        {
            int[] Source = { 1, 2, 3, 4, 5, 6 };
            int[] Dest = { 1, 2, 3, 4, 5, 6 };
            var Ethernetframe1 = new EthernetFrame(Source, Dest);

            Assert.AreEqual(Ethernetframe1.GetDestinationIp(), Ethernetframe1.GetDestinationIp());
        }

        [Test]
        public void EthernetEqualsTest()
        {
            int[] Source = {1, 2, 3, 4};
            int[] Dest = {3, 4, 2, 1};
            var Ethernetframe1 = new EthernetFrame(Source, Dest);
            var Ethernetframe2 = new EthernetFrame(Source, Dest);

            Assert.AreEqual(Ethernetframe1, Ethernetframe2);
        }
    }
}