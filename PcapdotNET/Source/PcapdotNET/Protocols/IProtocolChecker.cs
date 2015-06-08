using PcapdotNET.Protocols.Ethernet;
using PcapdotNET.Protocols.ICMP;

namespace PcapdotNET.Protocols
{
    public interface IProtocolChecker<out T>
    {
        T GetPacket(byte[] dataArray);
    }
}
