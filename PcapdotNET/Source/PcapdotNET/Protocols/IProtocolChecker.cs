namespace PcapdotNET.Protocols
{
    // Unique interface, that defines the way to operate packets
    public interface IProtocolChecker<out T>
    {
        T GetPacket(byte[] dataArray);
    }
}
