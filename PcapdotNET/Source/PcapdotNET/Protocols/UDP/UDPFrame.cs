using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapdotNET.Protocols.UDP
{
    public class UdpFrame
    {
        private readonly int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private readonly uint _destinationPort;              //2 bytes for the destination port number
        private readonly uint _frameLength;                  //4 bytes for frame length
        private readonly uint _protocolNumber;               //2 bytes for the source port number
        private readonly int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private readonly uint _sourcePort;                   //2 bytes for the source port number

        public UdpFrame(int[] destinationIp, uint destinationPort, uint frameLength, int[] sourceIp,
            uint sourcePort, uint protocolNumber)
        {
            _destinationIp = destinationIp;
            _destinationPort = destinationPort;
            _frameLength = frameLength;
            _sourceIp = sourceIp;
            _sourcePort = sourcePort;
            _protocolNumber = protocolNumber;
        }

        public string GetInformation()
        {
            return "\n###########\n" + _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3] + ":" + _sourcePort + " -> " +
                   _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3] + ":" +
                   _destinationPort + "\n" + "FrameLength : " + _frameLength + "\n" + "Protocol: " + GetProtocolName();
        }


        public string GetProtocolName()
        {
            return TableProtocols.GetProtocol(_protocolNumber);
            //return "UDP";
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
