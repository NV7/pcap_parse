namespace PcapdotNET.Protocols.TCP
{
    /// <summary>TCP Frame
    /// TCP Frame
    /// </summary>
    public class TCPFrame
    {
       private int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private uint _destinationPort;              //2 bytes for the destination port number
        private uint _frameLength;                  //4 bytes for frame length
        private uint _protocolNumber;               //2 bytes for the source port number
        private int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private uint _sourcePort;                   //2 bytes for the source port number

        /// <summary>Override Equals
        /// Override method Equals
        /// </summary>
        /// <param name="other">TCPFrame other frame</param>
        /// <returns>bool is equal</returns>
        protected bool Equals(TCPFrame other)
        {
            return _destinationPort == other._destinationPort && _frameLength == other._frameLength
                && _protocolNumber == other._protocolNumber && _sourcePort == other._sourcePort;
        }

        /// <summary>Override GetHashCode
        /// Override method GetHashCode
        /// </summary>
        /// <returns>int hashcode</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_destinationIp != null ? _destinationIp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_destinationPort;
                hashCode = (hashCode * 397) ^ (int)_frameLength;
                hashCode = (hashCode * 397) ^ (int)_protocolNumber;
                hashCode = (hashCode * 397) ^ (_sourceIp != null ? _sourceIp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_sourcePort;
                return hashCode;
            }
        }
        
        /// <summary>Constructor
        /// Constructor 
        /// </summary>
        /// <param name="destinationIp">int[] dest ip</param>
        /// <param name="destinationPort">uint dest port</param>
        /// <param name="frameLength">uint length of frame</param>
        /// <param name="sourceIp">int[] source ip</param>
        /// <param name="sourcePort">uint source port</param>
        /// <param name="protocolNumber">uint protocol number</param>
        public TCPFrame(int[] destinationIp, uint destinationPort, uint frameLength, int[] sourceIp, uint sourcePort, uint protocolNumber)
        {
            _destinationIp = destinationIp;
            _destinationPort = destinationPort;
            _frameLength = frameLength;
            _sourceIp = sourceIp;
            _sourcePort = sourcePort;
            _protocolNumber = protocolNumber;
        }

        /// <summary>Protocol name
        /// Return protocol Name
        /// </summary>
        /// <returns>string protocol name</returns>
        public string GetProtocolName()
        {
            //return TableProtocols.GetProtocol(_protocolNumber);
            return "TCP";
        }

        /// <summary>Set Protocol Number
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
        /// <returns>string protocol number</returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Set Frame Lenght
        /// Method which Set Frame Lenght
        /// </summary>
        /// <param name="lenght">uint length of frame</param>
        public void SetFrameLenght(uint lenght)
        {
            _frameLength = lenght;
        }

        /// <summary>Frame Length
        /// Return Frame Length
        /// </summary>
        /// <returns>string length of frame</returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary>Set destination Ip
        /// Method which set destination Ip 
        /// </summary>
        /// <param name="destinationIp">int[] destination IP</param>
        public void SetDestinationIp(int[] destinationIp)
        {
            _destinationIp = destinationIp;
        }

        /// <summary>Destination Ip
        /// Return Destination Ip
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
        /// <param name="sourceIp">int[] Source IP</param>
        public void SetSourceIp(int[] sourceIp)
        {
            _sourceIp = sourceIp;
        }

        /// <summary>Source Ip
        /// Return Source Ip
        /// </summary>
        /// <returns>string Source IP</returns>
        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        /// <summary>Set source port
        /// Method which set source port
        /// </summary>
        /// <param name="port">uint port number</param>
        public void SetSourcePort(uint port)
        {
            _sourcePort = port;
        }
       
        /// <summary>Source Port
        /// Return Source Port
        /// </summary>
        /// <returns>string Source port number</returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Set source port
        /// Method which set source port
        /// </summary>
        /// <param name="port">uint port for setting</param>
        public void SetDestinationPort(uint port)
        {
            _destinationPort = port;
        }
     
        /// <summary>Destination Port
        /// Return Destination Port
        /// </summary>
        /// <returns>string Destination port</returns>
        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }

        public override bool Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TCPFrame) obj);
        }
        
    }
}
