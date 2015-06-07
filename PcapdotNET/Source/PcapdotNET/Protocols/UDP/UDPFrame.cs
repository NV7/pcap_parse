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
        /// <param name="destinationIp"></param>
        /// <param name="destinationPort"></param>
        /// <param name="frameLength"></param>
        /// <param name="sourceIp"></param>
        /// <param name="sourcePort"></param>
        /// <param name="protocolNumber"></param>
        public UDPFrame(int[] destinationIp, uint destinationPort, uint frameLength, int[] sourceIp, uint sourcePort, uint protocolNumber)
        {
            _destinationIp = destinationIp;
            _destinationPort = destinationPort;
            _frameLength = frameLength;
            _sourceIp = sourceIp;
            _sourcePort = sourcePort;
            _protocolNumber = protocolNumber;
        }

        /// <summary>Constructor
        /// Default constructor
        /// </summary>
        public UDPFrame()
        {}

        /// <summary>Return Information
        /// Return information about UDP protocol
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            return "\n###########\n" + _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3] + ":" + _sourcePort + " -> " +
                   _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3] + ":" +
                   _destinationPort + "\n" + "FrameLength : " + _frameLength + "\n" + "Protocol: " + GetProtocolName();
        }

        /// <summary>Return UDP Protocol Name
        /// Return INformation about Protocol Name
        /// </summary>
        /// <returns></returns>
        public string GetProtocolName()
        {
            //return TableProtocols.GetProtocol(_protocolNumber);
            return "UDP";
        }

        /// <summary>SetProtocolNumber
        /// Method which set protocol number
        /// </summary>
        /// <param name="number"></param>
        public void SetProtocolNumber(uint number)
        {
            _protocolNumber = number;
        }

        /// <summary>Protocol Number
        /// Return Protocol Number
        /// </summary>
        /// <returns></returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Set frame lenght
        /// Method which set frame lenght
        /// </summary>
        /// <param name="lenght"></param>
        public void SetLenght(uint lenght)
        {
            _frameLength = lenght;
        }

        /// <summary>Frame length
        /// Return information about packet length
        /// </summary>
        /// <returns></returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary>Set destination Ip
        /// Method which set destination Ip
        /// </summary>
        /// <param name="destinationIp"></param>
        public void SetDestinationIp(int[] destinationIp)
        {
            _destinationIp = destinationIp;
        }

        /// <summary>
        /// Return information about Destination Ip
        /// </summary>
        /// <returns></returns>
        public string GetDestinationIp()
        {
            string result = _destinationIp[0] + "." + _destinationIp[1] + "." + _destinationIp[2] + "." + _destinationIp[3];
            return result;
        }

        /// <summary>Set source Ip
        /// Method which set source Ip
        /// </summary>
        /// <param name="sourceIp"></param>
        public void SetSourceIp(int[] sourceIp)
        {
            _sourceIp = sourceIp;
        }

        /// <summary>Source Ip
        /// Return Information about Source Ip
        /// </summary>
        /// <returns>string</returns>
        public string GetSourceIp()
        {
            string result = _sourceIp[0] + "." + _sourceIp[1] + "." + _sourceIp[2] + "." + _sourceIp[3];
            return result;
        }

        /// <summary>Set source Port
        /// Method which set source port
        /// </summary>
        /// <param name="port"></param>
        public void SetSorcePort(uint port)
        {
            _sourcePort = port;
        }

        /// <summary>Source Port
        /// Return information about Source Port
        /// </summary>
        /// <returns></returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Set destination port
        /// Method which set destination port
        /// </summary>
        /// <param name="port"></param>
        public void SetDestinationPort(uint port)
        {
            _destinationPort = port;
        }
        
        /// <summary>
        /// Return Information about Destination Port
        /// </summary>
        /// <returns></returns>
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
        /// <param name="other"></param>
        /// <returns></returns>
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
