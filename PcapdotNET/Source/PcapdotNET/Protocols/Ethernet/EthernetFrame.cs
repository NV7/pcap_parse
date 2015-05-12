namespace PcapdotNET.Protocols.Ethernet
{
    /// <summary>Ethernet Protocol
    /// Class which contains information about Ethernet Protocol
    /// </summary>
    public class EthernetFrame
    {
        private readonly int[] _destinationIp = new int[PacketFields.AmountOfEthernetParts];
        private readonly int[] _sourceIp = new int[PacketFields.AmountOfEthernetParts];

        /// <summary>Constructor
        /// Constructor for EthernetFarme
        /// </summary>
        /// <param name="destinationIp"></param>
        /// <param name="sourceIp"></param>
        public EthernetFrame(int[] destinationIp, int[] sourceIp)
        {
            _destinationIp = destinationIp;
            _sourceIp = sourceIp;
        }

        /// <summary>Destination Ip 
        /// Method which returns Destination Ip 
        /// </summary>
        /// <returns></returns>
        public string GetDestinationIp()
        {
            string result = _destinationIp[0].ToString("X") + "." + _destinationIp[1].ToString("X") + "." + _destinationIp[2].ToString("X") + "." + _destinationIp[3].ToString("X") +
                            "." + _destinationIp[4].ToString("X") + "." + _destinationIp[5].ToString("X");
            return result;
        }

        /// <summary>Source Ip
        /// Method which returns Source Ip
        /// </summary>
        /// <returns></returns>
        public string GetSourceIP()
        {
            string result = _sourceIp[0].ToString("X") + "." + _sourceIp[1].ToString("X") + "." + _sourceIp[2].ToString("X") + "." + _sourceIp[3].ToString("X") + "." + _sourceIp[4].ToString("X") +
                            "." + _sourceIp[5].ToString("X");
            return result;
        }

        /// <summary>Returns Informations
        /// Method which returns all information about Ethernet Protocol
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            return _destinationIp[0].ToString("X") + "." + _destinationIp[1].ToString("X") + "." +
                   _destinationIp[2].ToString("X") + "." + _destinationIp[3].ToString("X") +
                   "." + _destinationIp[4].ToString("X") + "." + _destinationIp[5].ToString("X") + " <- " +
                   _sourceIp[0].ToString("X") + "." + _sourceIp[1].ToString("X") + "." + _sourceIp[2].ToString("X") + "." +
                   _sourceIp[3].ToString("X") + "." + _sourceIp[4].ToString("X") +
                   "." + _sourceIp[5].ToString("X");
        }
    }
}