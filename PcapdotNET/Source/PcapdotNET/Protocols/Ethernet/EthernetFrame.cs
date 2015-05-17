using System;
using System.Threading;

namespace PcapdotNET.Protocols.Ethernet
{
    /// <summary>Ethernet Protocol
    /// Class which contains information about Ethernet Protocol
    /// </summary>
    public class EthernetFrame : System.Object
    {
        private int[] _destinationIp = new int[PacketFields.AmountOfEthernetParts];
        private int[] _sourceIp = new int[PacketFields.AmountOfEthernetParts];

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

        /// <summary>Set DestinationIp
        /// This method set Destination Ip.
        /// </summary>
        /// <param name="destinationIp"></param>
        public void SetDestinationIP(int[] destinationIp)
        {
            _destinationIp =  destinationIp;
        }

        /// <summary>Set source Ip
        /// This method set source Ip.
        /// </summary>
        /// <param name="sourceIp"></param>
        public void SetSourceIp(int[] sourceIp)
        {
            _sourceIp = sourceIp;
        }

        /// <summary>Get Source Ip
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

        /// <summary>Operator Equals
        /// Override operator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(EthernetFrame other)
        {
            return Equals(_destinationIp, other._destinationIp) && Equals(_sourceIp, other._sourceIp);
        }

        /// <summary>Method Get Hash Code
        /// Override method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_destinationIp != null ? _destinationIp.GetHashCode() : 0) * 397) ^ (_sourceIp != null ? _sourceIp.GetHashCode() : 0);
            }
        }

        /// <summary>Override operator comparison
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((EthernetFrame) obj);
        }
    }
}