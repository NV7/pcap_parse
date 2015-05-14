namespace PcapdotNET.Protocols.TCP
{
    /// <summary>TCP Frame
    /// TCP Frame
    /// </summary>
    public class TCPFrame
    {
        private readonly int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private readonly uint _destinationPort;              //2 bytes for the destination port number
        private readonly uint _frameLength;                  //4 bytes for frame length
        private readonly uint _protocolNumber;               //2 bytes for the source port number
        private readonly int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private readonly uint _sourcePort;                   //2 bytes for the source port number

        /// <summary>Constructor
        /// Constructor 
        /// </summary>
        /// <param name="destinationIp"></param>
        /// <param name="destinationPort"></param>
        /// <param name="frameLength"></param>
        /// <param name="sourceIp"></param>
        /// <param name="sourcePort"></param>
        /// <param name="protocolNumber"></param>
        public TCPFrame(int[] destinationIp, uint destinationPort, uint frameLength, int[] sourceIp, uint sourcePort, uint protocolNumber)
        {
            _destinationIp = destinationIp;
            _destinationPort = destinationPort;
            _frameLength = frameLength;
            _sourceIp = sourceIp;
            _sourcePort = sourcePort;
            _protocolNumber = protocolNumber;
        }

        /// <summary>Return information
        /// Return Information about TCP protocol
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            return "\n###########\n" + _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3] + ":" + _sourcePort + " -> " +
                   _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3] + ":" +
                   _destinationPort + "\n" + "FrameLength : " + _frameLength + "\n" + "Protocol: " + GetProtocolName();
        }

        /// <summary>Protocol name
        /// Return protocol Name
        /// </summary>
        /// <returns></returns>
        public string GetProtocolName()
        {
            return TableProtocols.GetProtocol(_protocolNumber);
        }

        /// <summary>Protocol Number
        /// Return Protocol Number
        /// </summary>
        /// <returns></returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Frame Length
        /// Return Frame Length
        /// </summary>
        /// <returns></returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary>Destination Ip
        /// Return Destination Ip
        /// </summary>
        /// <returns></returns>
        public string GetDestinationIp()
        {
            string result = _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3];
            return result;
        }

        /// <summary>Source Ip
        /// Return Source Ip
        /// </summary>
        /// <returns></returns>
        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        /// <summary>Source Port
        /// Return Source Port
        /// </summary>
        /// <returns></returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Destination Port
        /// Return Destination Port
        /// </summary>
        /// <returns></returns>
        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }
    }
}
