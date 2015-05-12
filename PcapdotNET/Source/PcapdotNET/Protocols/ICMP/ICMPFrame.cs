namespace PcapdotNET.Protocols.ICMP
{
    /// <summary> Class ICMP frame
    /// Class which contains information about ICMP protocols 
    /// </summary>
    public class ICMPFrame
    {
         private readonly int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private readonly uint _destinationPort;              //2 bytes for the destination port number
        private readonly uint _frameLength;                  //4 bytes for frame length
        private readonly uint _protocolNumber;               //2 bytes for the source port number
        private readonly int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private readonly uint _sourcePort;                   //2 bytes for the source port number

        /// <summary>Constructor ICMPFrame
        /// Constructor which create instance type ICMPFrame
        /// </summary>
        /// <param name="_DestinationIP"></param>
        /// <param name="_DestinationPort"></param>
        /// <param name="_FrameLength"></param>
        /// <param name="_SourceIP"></param>
        /// <param name="_SourcePort"></param>
        /// <param name="_ProtocolNumber"></param>
        public ICMPFrame(int[] _DestinationIP, uint _DestinationPort, uint _FrameLength, int[] _SourceIP, uint _SourcePort, uint _ProtocolNumber)
        {
            _destinationIp = _DestinationIP;
            _destinationPort = _DestinationPort;
            _frameLength = _FrameLength;
            _sourceIp = _SourceIP;
            _sourcePort = _SourcePort;
            _protocolNumber = _ProtocolNumber;
        }

        /// <summary>Information about ICMPFarme
        /// Return information about ICMPFarme
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            return "\n###########\n" + _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3] + ":" + _sourcePort + " -> " +
                   _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3] + ":" +
                   _destinationPort + "\n" + "FrameLength : " + _frameLength + "\n" + "Protocol: " + GetProtocolName();
        }

        /// <summary>Prptocol Name
        /// Return protocol name
        /// </summary>
        /// <returns></returns>
        public string GetProtocolName()
        {
            return TableProtocols.GetProtocol(_protocolNumber);
            //return "ICMP";
        }

        /// <summary>Number protocol
        /// Return number protocol.
        /// </summary>
        /// <returns></returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Length packet
        /// Return length packet from .pcap file.
        /// </summary>
        /// <returns></returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary> Destination Ip
        /// Return destination Ip.
        /// </summary>
        /// <returns></returns>
        public string GetDestinationIp()
        {
            string result = _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3];
            return result;
        }

        /// <summary>Source Ip
        /// Return Source Ip.
        /// </summary>
        /// <returns></returns>
        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        /// <summary>Source Port
        /// Return Source port.
        /// </summary>
        /// <returns></returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Destination Port
        /// Return Destination port.
        /// </summary>
        /// <returns></returns>
        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }
    }
}
