namespace PcapdotNET.Protocols
{
    public static class TCPProtocolsConstants
    {
        // Обычно, длина заголовка TCP составляет 20 байт
        public const byte MinHeaderLength = 20;

        // У TCP есть ограничение на длину заголовка в 60 байт
        public const byte MaxHeaderLength = 60;

        // Номер порта
        public enum PortNumber
        {

            MinPortNumber = 0,

            MaxPortNumber = 65535
        }
    }
}