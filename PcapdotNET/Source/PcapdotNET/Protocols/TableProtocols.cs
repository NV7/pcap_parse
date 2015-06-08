namespace PcapdotNET.Protocols
{
    public class TableProtocols
    {
        /// <summary>Name Protocols
        /// Class consist All name protocols
        /// </summary>
        private static readonly string[] _tableProtocols =
        {
            "HOPOPT",  //IPv6 Hop-by-Hop Option
            "ICMP",    //Internet Control Message
            "IGMP",    //Internet Group Management 
            "GGP",     //Gateway-to-Gateway 
            "IP",      //IP in IP (инкапсуляция)
            "ST",      //Stream
            "TCP",     //Transmission Control
            "CBT",     //CBT
            "EGP",     //Exterior Gateway Protocol
            "IGP",     //любой частный внутренний шлюз(используется компанией Cisco для протокола IGRP)
            "BBN-RCC-MON",    //BBN RCC Monitoring
            "NVP-II",     //Network Voice Protocol
            "PUP",    //PUP
            "ARGUS",      //ARGUS
            "EMCON",      //EMCON
            "XNET",       //Cross Net Debugger
            "CHAOS",      //Chaos
            "UDP",        //User Datagram
            "MUX",        //Multiplexing
            "DCN-MEANS",  //DCN Measurement Subsystems
            "HMP",        //Host Monitoring
            "PRM",        //Packet Radio Measurement
            "XNS-IDP",    //XEROX NS IDP
            "TRUNK-1",    //Trunk-1
            "TRUNK-2",    //Trunk-2
            "LEAF-1",     //Leaf-1
            "LEAF-2",     //Leaf-2
            "RDP",        //Reliable ProtocolList Protocol
            "IRTP",       //Internet Reliable Transaction
            "ISO-TP4",    //ISO Transport Protocol Class 4 
            "NETBLT",     //Bulk ProtocolList Transfer Protocol
            "MFE-NSP",    //MFE Network Services Protocol
            "MERIT-INP",  //MERIT Internodal Protocol
            "SEP",        //Sequential Exchange Protocol
            "3PC",        //Third Party Connect Protocol
            "IDPR",       //Inter-Domain Policy Routing Protocol
            "XTP",        //XTP
            "DDP",        //Datagram Delivery Protocol
            "IDPR-CMTP",  //IDPR Control Message Transport Protol
            "TP++",       //TP++ Transport Protocol
            "IL",         //IL Transport Protocol
            "IPv6",       //Ipv6
            "SDRP",       //Source Demand Routing Protocol 
            "IPv6-Route", //Routing Header for IPv6
            "IPv6-Frag",  //Fragment Header for IPv6
            "IDRP",       //Inter-Domain Routing Protocol
            "RSVP",       //Reservation Protocol
            "GRE",        //General Routing Encapsulation
            "MHRP",       //Mobile Host Routing Protocol
            "BNA",        //BNA
            "ESP",        //Encap Security Payload for IPv6 
            "AH",         //Authentication Header for IPv6
            "I-NLSP",     //Integrated Net Layer Security  TUBA
            "SWIPE",      //IP with Encryption
            "NARP",       //NBMA Address Resolution Protocol
            "MOBILE",     //IP Mobility
            "TLSP",       //Transport Layer Security Protocol с использованием обработки ключей Kryptonet
            "SKIP",       //SKIP
            "IPv6-ICMP",  //ICMP for IPv6 
            "IPv6-NoNxt", //No Next Header for IPv6
            "IPv6-Opts",  //Destination Options for IPv6
            "Any_Internal_Protocol_Node",
            "CFTP",       //CFTP 
            "Any_Local_Network",
            "SAT-EXPAK",  //SATNET и Backroom EXPAK
            "KRYPTOLAN",  //Kryptolan
            "RVD",        //MIT Remote Virtual Disk Protocol
            "IPPC",       //Internet Pluribus Packet Core
            "AnyDistributedFileSystem", 
            "SAT-MON",    //SATNET Monitoring
            "VISA",       //VISA Protocol
            "IPCV",       //Internet Packet Core Utility
            "CPNX",       //Computer Protocol Network Executive
            "CPHB",       //Computer Protocol Heart Beat
            "WSN",        //Wang Span Network
            "PVP",        //Packet Video Protocol
            "BR-SAT-MON", //Backroom SATNET Monitoring
            "SUN-ND",     //SUN ND PROTOCOL-Temporary
            "WB-MON",     //WIDEBAND Monitoring
            "WB-EXPAK",   //WIDEBAND EXPAK
            "ISO-IP",     //ISO Internet Protocol
            "VMTP",       //VMTP
            "SECURE-VMTP", //SECURE-VMTP
            "VINES",      //VINES
            "TTP",        //TTP
            "NSFNET-IGP", //NSFNET-IGP
            "DGP",        //Dissimilar Gateway Protocol
            "TCF",        //TCF
            "EIGRP",      //EIGRP
            "OSPFIGP",    //OSPFIGP
            "Sprite-RPC", //Sprite RPC Protocol
            "LARP",       //Locus Address Resolution Protocol
            "MTP",        //Multicast Transport Protocol
            "AX.25",      //AX.25 Frames
            "IPIP",       //IP-within-IP Encapsulation Protocol
            "MICP",       //Mobile Internetworking Control Pro.
            "SCC-SP",     //Semaphore Communications Sec. Pro.
            "ETHERIP",    //Ethernet-within-IP Encapsulation
            "ENCAP",      //Encapsulation Header
            "Any_Private_Encryption_Scheme",
            "GMTP",      //GMTP
            "IFMP",      //Ipsilon Flow Management Protocol
            "PNNI",      //PNNI over IP
            "PIM",       //Protocol Independent Multicast
            "ARIS",      //ARIS
            "SCPS",      //SCPS
            "QNX",       //QNX
            "A/N",       //Active Networks
            "IPComp",    //IP Payload Compression Protocol
            "SNP",       //Sitara Networks Protocol
            "Compaq-Peer",//Compaq Peer Protocol
            "IPX-in-IP", //IPX in IP
            "VRRP",      //Virtual Router Redundancy Protocol
            "PGM",       //PGM Reliable Transport Protocol
            "Any_Protocol_0-hop",
            "L2TP",      //Layer Two Tunneling Protocol
            "DDX",       //D-II ProtocolList Exchange (DDX)
            "IATP",      //Interactive Agent Transfer Protocol
            "STP",       //Schedule Transfer Protocol
            "SRP",       //SpectraLink Radio Protocol
            "UTI",       //UTI
            "SMP",       //Simple Message Protocol
            "SM",        //SM
            "PTP",       //Performance Transparency Protocol
            "ISIS over IPv4",
            "FIRE",
            "CRTP",      //Combat Radio Transport Protocol
            "CRUDP",     //Combat Radio User Datagram
            "SSCOPMCE",
            "IPLT",
            "SPS",       //Secure Packet Shield
            "PIPE",      //Private IP Encapsulation within IP
            "SCTP",      //Stream Control Transmission Protocol
            "FC"        //Fibre Channel
        };

        /// <summary>Return name of protocol
        /// Return name of protocol on index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetProtocol(uint index)
        {
           return _tableProtocols[index];
        }
    }
}
