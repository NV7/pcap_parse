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
            /// <summary>
            /// Minimum value
            /// </summary>
            MinPortNumber = 0,

            /// <summary>
            /// Maximum value
            /// </summary>
            MaxPortNumber = 65535
        }
    }
}