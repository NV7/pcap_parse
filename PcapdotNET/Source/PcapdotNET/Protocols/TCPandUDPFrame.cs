namespace PcapdotNET.Protocols.TCP
{
    // TCPandUDPFrame - contains information about processed frame (UDP & TCP files)
    public class TCPandUDPFrame
    {
        private readonly int[] DestinationIP = new int[4];  //4 parts of IP address
        private readonly uint DestinationPort;              //2 bytes for the destination port number
        private readonly uint FrameLength;                  //4 bytes for frame length
        private readonly uint ProtocolNumber;               //2 bytes for the source port number
        private readonly int[] SourceIP = new int[4];       //4 parts for source ip
        private readonly uint SourcePort;                   //2 bytes for the source port number

        public TCPandUDPFrame(int[] _DestinationIP, uint _DestinationPort, uint _FrameLength, int[] _SourceIP,
            uint _SourcePort,
            uint _ProtocolNumber)
        {
            DestinationIP = _DestinationIP;
            DestinationPort = _DestinationPort;
            FrameLength = _FrameLength;
            SourceIP = _SourceIP;
            SourcePort = _SourcePort;
            ProtocolNumber = _ProtocolNumber;
        }

        public string GetInformation()
        {
            return "\n###########\n" + SourceIP[0] + "." + SourceIP[1] + "." + SourceIP[2] + "." + SourceIP[3] + ":" + SourcePort + " -> " +
                   DestinationIP[0] + "." + DestinationIP[1] + "." + DestinationIP[2] + "." + DestinationIP[3] + ":" +
                   DestinationPort + "\n" + "FrameLength : " + FrameLength + "\n" + "Protocol: " + GetProtocolName();
        }


        public string GetProtocolName()
        {
            switch (ProtocolNumber)
            {
                case 1:
                    return "ICMP";
                case 6:
                    return "TCP";
                case 17:
                    return "UDP";
                default:
                    return "Not stated";
            }
        }

        public string GetProtocolNumber()
        {
            return ProtocolNumber.ToString();
        }

        public string GetFrameLength()
        {
            return FrameLength.ToString();
        }

        public string GetDestinationIP()
        {
            string result = DestinationIP[0] + "." + DestinationIP[1] + "." + DestinationIP[2] + "." + DestinationIP[3];
            return result;
        }

        public string GetSourceIP()
        {
            string result = SourceIP[0] + "." + SourceIP[1] + "." + SourceIP[2] + "." + SourceIP[3];
            return result;
        }

        public string GetSourcePort()
        {
            return SourcePort.ToString();
        }

        public string GetDestinationPort()
        {
            return DestinationPort.ToString();
        }
    }
}