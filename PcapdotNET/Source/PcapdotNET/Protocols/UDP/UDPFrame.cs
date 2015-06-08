namespace PcapdotNET.Protocols.UDP
{
    /// <summary>UDP frame
    /// Class UDP Frame
    /// </summary>
    public class UDPFrame
    {
        private int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private uint _destinationPort;              //2 bytes for the destination port number
        private uint _frameLength;                  //4 bytes for frame length
        private uint _protocolNumber;               //2 bytes for the source port number
        private int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private uint _sourcePort;                   //2 bytes for the source port number
        
        /// <summary>Contructor
        /// Constructor UDP Frame
        /// </summary>
        /// <param name="destinationIp">int[] dest ip</param>
        /// <param name="destinationPort">uint dest port</param>
        /// <param name="frameLength">uint length of frame</param>
        /// <param name="sourceIp">int[] source ip</param>
        /// <param name="sourcePort">uint source port</param>
        /// <param name="protocolNumber">uint protocol number</param>
        public UDPFrame(int[] destinationIp, uint destinationPort, uint frameLength, int[] sourceIp, uint sourcePort, uint protocolNumber)
        {
            _destinationIp = destinationIp;
            _destinationPort = destinationPort;
            _frameLength = frameLength;
            _sourceIp = sourceIp;
            _sourcePort = sourcePort;
            _protocolNumber = protocolNumber;
        }


        /// <summary>Return UDP Protocol Name
        /// Return INformation about Protocol Name
        /// </summary>
        /// <returns>return string protocol name</returns>
        public string GetProtocolName()
        {
            //return TableProtocols.GetProtocol(_protocolNumber);
            return "UDP";
        }

        /// <summary>SetProtocolNumber
        /// Method which set protocol number
        /// </summary>
        /// <param name="protocol">uint protocol for setting</param>
        public void SetProtocolNumber(uint protocol)
        {
            _protocolNumber = protocol;
        }

        /// <summary>Protocol Number
        /// Return Protocol Number
        /// </summary>
        /// <returns>string number of protocol</returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Set frame lenght
        /// Method which set frame lenght
        /// </summary>
        /// <param name="lenght">uint length of the frame</param>
        public void SetLenght(uint lenght)
        {
            _frameLength = lenght;
        }

        /// <summary>Frame length
        /// Return information about packet length
        /// </summary>
        /// <returns>string frame length</returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary>Set destination Ip
        /// Method which set destination Ip
        /// </summary>
        /// <param name="destinationIp">int[] destination ip</param>
        public void SetDestinationIp(int[] destinationIp)
        {
            _destinationIp = destinationIp;
        }

        /// <summary>
        /// Return information about Destination Ip
        /// </summary>
        /// <returns>string destination IP</returns>
        public string GetDestinationIp()
        {
            string result = _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3];
            return result;
        }

        /// <summary>Set source Ip
        /// Method which set source Ip
        /// </summary>
        /// <param name="sourceIp">int[] source IP</param>
        public void SetSourceIp(int[] sourceIp)
        {
            _sourceIp = sourceIp;
        }

        /// <summary>Source Ip
        /// Return Information about Source Ip
        /// </summary>
        /// <returns>string Source IP</returns>
        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        /// <summary>Set source Port
        /// Method which set source port
        /// </summary>
        /// <param name="port">uint port to set</param>
        public void SetSorcePort(uint port)
        {
            _sourcePort = port;
        }

        /// <summary>Source Port
        /// Return information about Source Port
        /// </summary>
        /// <returns>string Source Port</returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Set destination port
        /// Method which set destination port
        /// </summary>
        /// <param name="port">uint port to set</param>
        public void SetDestinationPort(uint port)
        {
            _destinationPort = port;
        }
        
        /// <summary>
        /// Return Information about Destination Port
        /// </summary>
        /// <returns>string destination port</returns>
        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }

        /// <summary>Override Equals
        /// Override Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UDPFrame) obj);
        }

        /// <summary>Override Equals
        /// Override Equals
        /// </summary>
        /// <param name="other">UDPFrame other frame</param>
        /// <returns>bool are they equal</returns>
        protected bool Equals(UDPFrame other)
        {
            return _destinationPort == other._destinationPort && _frameLength == other._frameLength && _protocolNumber == other._protocolNumber && _sourcePort == other._sourcePort;
        }

        /// <summary>OverrideGetHashCode
        /// Override GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)_destinationPort;
                hashCode = (hashCode * 397) ^ (int)_frameLength;
                hashCode = (hashCode * 397) ^ (int)_protocolNumber;
                hashCode = (hashCode * 397) ^ (int)_sourcePort;
                return hashCode;
            }
        }
    }
}
