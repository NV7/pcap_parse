namespace PcapdotNET.Protocols.ICMP
{
    /// <summary> Class ICMP frame
    /// Class which contains information about ICMP protocols 
    /// </summary>
    public class ICMPFrame : System.Object
    {
        /// <summary>Override Equals
        /// Override method Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(ICMPFrame other)
        {
            return _destinationPort == other._destinationPort && _frameLength == other._frameLength && _protocolNumber == other._protocolNumber 
                && _sourcePort == other._sourcePort;
        }

        /// <summary>Override GetHashCode
        /// Override method GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_destinationIp != null ? _destinationIp.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) _destinationPort;
                hashCode = (hashCode*397) ^ (int) _frameLength;
                hashCode = (hashCode*397) ^ (int) _protocolNumber;
                hashCode = (hashCode*397) ^ (_sourceIp != null ? _sourceIp.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) _sourcePort;
                return hashCode;
            }
        }

        private int[] _destinationIp = new int[PacketFields.AmountOfIpParts];  //4 parts of IP address
        private uint _destinationPort;              //2 bytes for the destination port number
        private uint _frameLength;                  //4 bytes for frame length
        private uint _protocolNumber;               //2 bytes for the source port number
        private int[] _sourceIp = new int[PacketFields.AmountOfIpParts];       //4 parts for source ip
        private uint _sourcePort;                   //2 bytes for the source port number

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
        
        /// <summary>Default constructor 
        /// Constructor
        /// </summary>
        public ICMPFrame()
        {}

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

        /// <summary>Set protocol name
        /// Method which set protocol number
        /// </summary>
        /// <param name="protocol"></param>
        public void SetProtocolNumber(uint protocol)
        {
            _protocolNumber = protocol;
        }
        /// <summary>Prptocol Name
        /// Return protocol name
        /// </summary>
        /// <returns></returns>
        public string GetProtocolName()
        {
            //return TableProtocols.GetProtocol(_protocolNumber);
            return "ICMP";
        }

        /// <summary>Number protocol
        /// Return number protocol.
        /// </summary>
        /// <returns></returns>
        public string GetProtocolNumber()
        {
            return _protocolNumber.ToString();
        }

        /// <summary>Set protocol lenght
        /// Method which set protocol lenght
        /// </summary>
        /// <param name="lenght"></param>
        public void SetProtocolLenght(uint lenght)
        {
            _frameLength = lenght;
        }
      
        /// <summary>Length packet
        /// Return length packet from .pcap file.
        /// </summary>
        /// <returns></returns>
        public string GetFrameLength()
        {
            return _frameLength.ToString();
        }

        /// <summary>Set destinatioIP
        /// Method which set destination Ip
        /// </summary>
        /// <param name="destinationIp"></param>
        public void SetDestinationIp(int[] destinationIp)
        {
            _destinationIp = destinationIp;
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

        /// <summary>Set source Ip
        /// Method which set source Ip
        /// </summary>
        /// <param name="sourceIp"></param>
        public void SetSuorceIp(int[] sourceIp)
        {
            _sourceIp = sourceIp;
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

        /// <summary>Set Source Ip
        /// Method which set source Ip 
        /// </summary>
        /// <param name="port"></param>
        public void SetSourcePort(uint port)
        {
            _sourcePort = port;
        }
        
        /// <summary>Source Port
        /// Return Source port.
        /// </summary>
        /// <returns></returns>
        public string GetSourcePort()
        {
            return _sourcePort.ToString();
        }

        /// <summary>Set Destination Ip
        /// Method thich set destination Ip
        /// </summary>
        /// <param name="destinationPort"></param>
        public void SetDestinationPort(uint destinationPort)
        {
            _destinationPort = destinationPort;
        }
        
        /// <summary>Destination Port
        /// Return Destination port.
        /// </summary>
        /// <returns></returns>
        public string GetDestinationPort()
        {
            return _destinationPort.ToString();
        }

        /// <summary>Override Equals
        /// Override method Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ICMPFrame) obj);
        }
    }
}
