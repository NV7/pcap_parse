using System.Collections;

namespace PcapdotNET.Protocols
{
    public class ProtocolList
    {
        public readonly ArrayList UdpFrameList = new ArrayList();
        public readonly ArrayList TcpFrameList = new ArrayList();
        public readonly ArrayList FrameArray = new ArrayList();
        public readonly  ArrayList IcmpFrameList = new ArrayList();
        public readonly ArrayList EthernetFrameList = new ArrayList();
        public ArrayList ProtocolSequence = new ArrayList();
        public ArrayList FrameLengthSequence = new ArrayList();

        public ArrayList GetEthernetFrameList()
        {
            return EthernetFrameList;
        }

        public ArrayList GetIcmpFrameList()
        {
            return IcmpFrameList;
        }

        public ArrayList GetUdpFrameList()
        {
            return UdpFrameList;
        }

        public ArrayList GetTcpFrameList()
        {
            return TcpFrameList;
        }

        public ArrayList GetFrameList()
        {
            return FrameArray;
        }

        public ArrayList GetProtocolsSequence()
        {
            return ProtocolSequence;
        }

        public ArrayList GetFrameLengthSequence()
        {
            return FrameLengthSequence;
        }
    }
}