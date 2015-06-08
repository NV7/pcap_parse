using System;
using NUnit.Framework;
using PcapdotNET.Protocols;
using PcapdotNET.Protocols.ICMP;

namespace Tests
{
    [TestFixture]
    class CommonTest
    {
        [Test]
        public void ProtocolListProtocolNameTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            var _currentname = (uint) test.ProtocolList.GetProtocolsSequence()[1];

            Assert.AreEqual(_currentname, 1);

        }

        [Test]
        public void ProtocolListLengthTest()
        {
            var test = new ProtocolChecker();

            test.ReadFile(@"..\..\..\Source\Tests\Testfiles\icmp_protocol.pcap");

            var _currentlength = (uint) test.ProtocolList.GetFrameLengthSequence()[1];

            Assert.AreEqual(_currentlength, 1514);

        }

        [Test]
        public void ExceptionWrongFileNameTest()
        {
            var test = new ProtocolChecker();

            try
            {
                test.ReadFile(@"..\..\..\Source\Tests\Testfiles\omg.lol");
            }
            catch (ContentException ex)
            {
                Assert.AreEqual(ex.Message, @"В файле ..\..\..\Source\Tests\Testfiles\omg.lol нет pcap файлов. Его невозможно обработать");
            }
            
        }

        [Test]
        public void ExceptionEmptyFileNameTest()
        {
            var test = new ProtocolChecker();

            try
            {
                test.ReadFile("");
            }
            catch (ContentException ex)
            {
                Assert.AreEqual(ex.Message, "Укажите название файла");
            }

        }

        [Test]
        public void TableProtocolSimpleTest()
        {
            var test = new TableProtocols();

            Assert.AreEqual(test.GetProtocol(1), "ICMP");
        }
    }
}