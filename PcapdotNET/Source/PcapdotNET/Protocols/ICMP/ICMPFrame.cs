using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapdotNET.Protocols.ICMP
{
    public class ICMPFrame
    {
          private readonly int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private readonly uint _destinationPort;              //2 bytes for the destination port number
        private readonly uint _frameLength;                  //4 bytes for frame length
        private readonly uint _protocolNumber;               //2 bytes for the source port number
        private readonly int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private readonly uint _sourcePort;                   //2 bytes for the source port number

        public ICMPFrame(int[] _DestinationIP, uint _DestinationPort, uint _FrameLength, int[] _SourceIP,
            uint _SourcePort,
            uint _ProtocolNumber)
        {
            _destinationIp = _DestinationIP;
            _destinationPort = _DestinationPort;
            _frameLength = _FrameLength;
            _sourceIp = _SourceIP;
            _sourcePort = _SourcePort;
            _protocolNumber = _ProtocolNumber;
        }

        public string GetInformation()
        {
            return "\n###########\n" + _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3] + ":" + _sourcePort + " -> " +
                   _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3] + ":" +
                   _destinationPort + "\n" + "FrameLength : " + _frameLength + "\n" + "Protocol: " + GetProtocolName();
        }


        public string GetProtocolName()
        {
            return "ICMP";
        }

        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        public string GetDestinationIp()
        {
            string result = _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3];
            return result;
        }

        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }
    }
}
