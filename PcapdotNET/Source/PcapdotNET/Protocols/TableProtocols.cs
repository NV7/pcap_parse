using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapdotNET.Annotations;

namespace PcapdotNET.Protocols
{
    static class TableProtocols
    {
        [UsedImplicitly] private static string[] _tableProtocols;

        static TableProtocols()
        {
            _tableProtocols[0] = "HOPOPT";  //IPv6 Hop-by-Hop Option
            _tableProtocols[1] = "ICMP";    //Internet Control Message
            _tableProtocols[2] = "IGMP";    //Internet Group Management 
            _tableProtocols[3] = "GGP";     //Gateway-to-Gateway 
            _tableProtocols[4] = "IP";      //IP in IP (инкапсуляция)
            _tableProtocols[5] = "ST";      //Stream
            _tableProtocols[6] = "TCP";     //Transmission Control
            _tableProtocols[7] = "CBT";     //CBT
            _tableProtocols[8] = "EGP";     //Exterior Gateway Protocol
            _tableProtocols[9] = "IGP";     //любой частный внутренний шлюз(используется компанией Cisco для протокола IGRP)
            _tableProtocols[10] = "BBN-RCC-MON";    //BBN RCC Monitoring
            _tableProtocols[11] = "NVP-II";     //Network Voice Protocol
            _tableProtocols[12] = "PUP";    //PUP
            _tableProtocols[13] = "ARGUS";      //ARGUS
            _tableProtocols[14] = "EMCON";      //EMCON
            _tableProtocols[15] = "XNET";       //Cross Net Debugger
            _tableProtocols[16] = "CHAOS";      //Chaos
            _tableProtocols[17] = "UDP";        //User Datagram
            _tableProtocols[18] = "MUX";        //Multiplexing
            _tableProtocols[19] = "DCN-MEANS";  //DCN Measurement Subsystems
            _tableProtocols[20] = "HMP";        //Host Monitoring
            _tableProtocols[21] = "PRM";        //Packet Radio Measurement
            _tableProtocols[22] = "XNS-IDP";    //XEROX NS IDP
            _tableProtocols[23] = "TRUNK-1";    //Trunk-1
            _tableProtocols[24] = "TRUNK-2";    //Trunk-2
            _tableProtocols[25] = "LEAF-1";     //Leaf-1
            _tableProtocols[26] = "LEAF-2";     //Leaf-2
            _tableProtocols[27] = "RDP";        //Reliable Data Protocol
            _tableProtocols[28] = "IRTP";       //Internet Reliable Transaction
            _tableProtocols[29] = "ISO-TP4";    //ISO Transport Protocol Class 4 
            _tableProtocols[30] = "NETBLT";     //Bulk Data Transfer Protocol
            _tableProtocols[31] = "MFE-NSP";    //MFE Network Services Protocol
            _tableProtocols[32] = "MERIT-INP";  //MERIT Internodal Protocol
            _tableProtocols[33] = "SEP";        //Sequential Exchange Protocol
            _tableProtocols[34] = "3PC";        //Third Party Connect Protocol
            _tableProtocols[35] = "IDPR";       //Inter-Domain Policy Routing Protocol
            _tableProtocols[36] = "XTP";        //XTP
            _tableProtocols[37] = "DDP";        //Datagram Delivery Protocol
            _tableProtocols[38] = "IDPR-CMTP";  //IDPR Control Message Transport Protol
            _tableProtocols[39] = "TP++";       //TP++ Transport Protocol
            _tableProtocols[40] = "IL";         //IL Transport Protocol
            _tableProtocols[41] = "IPv6";       //Ipv6
            _tableProtocols[42] = "SDRP";       //Source Demand Routing Protocol 
            _tableProtocols[43] = "IPv6-Route"; //Routing Header for IPv6
            _tableProtocols[44] = "IPv6-Frag";  //Fragment Header for IPv6
            _tableProtocols[45] = "IDRP";       //Inter-Domain Routing Protocol
            _tableProtocols[46] = "RSVP";       //Reservation Protocol
            _tableProtocols[47] = "GRE";        //General Routing Encapsulation
            _tableProtocols[48] = "MHRP";       //Mobile Host Routing Protocol
            _tableProtocols[49] = "BNA";        //BNA
            _tableProtocols[50] = "ESP";        //Encap Security Payload for IPv6 
            _tableProtocols[51] = "AH";         //Authentication Header for IPv6
            _tableProtocols[52] = "I-NLSP";     //Integrated Net Layer Security  TUBA
            _tableProtocols[53] = "SWIPE";      //IP with Encryption
            _tableProtocols[54] = "NARP";       //NBMA Address Resolution Protocol
            _tableProtocols[55] = "MOBILE";     //IP Mobility
            _tableProtocols[56] = "TLSP";       //Transport Layer Security Protocol с использованием обработки ключей Kryptonet
            _tableProtocols[57] = "SKIP";       //SKIP
            _tableProtocols[58] = "IPv6-ICMP";  //ICMP for IPv6 
            _tableProtocols[59] = "IPv6-NoNxt"; //No Next Header for IPv6
            _tableProtocols[60] = "IPv6-Opts";  //Destination Options for IPv6
            _tableProtocols[61] = "Any_Internal_Protocol_Node";
            _tableProtocols[62] = "CFTP";       //CFTP 
            _tableProtocols[63] = "Any_Local_Network";
            _tableProtocols[64] = "SAT-EXPAK";  //SATNET и Backroom EXPAK
            _tableProtocols[65] = "KRYPTOLAN";  //Kryptolan
            _tableProtocols[66] = "RVD";        //MIT Remote Virtual Disk Protocol
            _tableProtocols[67] = "IPPC";       //Internet Pluribus Packet Core
            _tableProtocols[68] = "AnyDistributedFileSystem";
            _tableProtocols[69] = "SAT-MON";    //SATNET Monitoring
            _tableProtocols[70] = "VISA";       //VISA Protocol
            _tableProtocols[71] = "IPCV";       //Internet Packet Core Utility
            _tableProtocols[72] = "CPNX";       //Computer Protocol Network Executive
            _tableProtocols[73] = "CPHB";       //Computer Protocol Heart Beat
            _tableProtocols[74] = "WSN";        //Wang Span Network
            _tableProtocols[75] = "PVP";        //Packet Video Protocol
            _tableProtocols[76] = "BR-SAT-MON"; //Backroom SATNET Monitoring
            _tableProtocols[77] = "SUN-ND";     //SUN ND PROTOCOL-Temporary
            _tableProtocols[78] = "WB-MON";     //WIDEBAND Monitoring
            _tableProtocols[79] = "WB-EXPAK";   //WIDEBAND EXPAK
            _tableProtocols[80] = "ISO-IP";     //ISO Internet Protocol
            _tableProtocols[81] = "VMTP";       //VMTP
            _tableProtocols[82] = "SECURE-VMTP";//SECURE-VMTP
            _tableProtocols[83] = "VINES";      //VINES
            _tableProtocols[84] = "TTP";        //TTP
            _tableProtocols[85] = "NSFNET-IGP"; //NSFNET-IGP
            _tableProtocols[86] = "DGP";        //Dissimilar Gateway Protocol
            _tableProtocols[87] = "TCF";        //TCF
            _tableProtocols[88] = "EIGRP";      //EIGRP
            _tableProtocols[89] = "OSPFIGP";    //OSPFIGP
            _tableProtocols[90] = "Sprite-RPC"; //Sprite RPC Protocol
            _tableProtocols[91] = "LARP";       //Locus Address Resolution Protocol
            _tableProtocols[92] = "MTP";        //Multicast Transport Protocol
            _tableProtocols[93] = "AX.25";      //AX.25 Frames
            _tableProtocols[94] = "IPIP";       //IP-within-IP Encapsulation Protocol
            _tableProtocols[95] = "MICP";       //Mobile Internetworking Control Pro.
            _tableProtocols[96] = "SCC-SP";     //Semaphore Communications Sec. Pro.
            _tableProtocols[97] = "ETHERIP";    //Ethernet-within-IP Encapsulation
            _tableProtocols[98] = "ENCAP";      //Encapsulation Header
            _tableProtocols[99] = "Any_Private_Encryption_Scheme";
            _tableProtocols[100] = "GMTP";      //GMTP
            _tableProtocols[101] = "IFMP";      //Ipsilon Flow Management Protocol
            _tableProtocols[102] = "PNNI";      //PNNI over IP
            _tableProtocols[103] = "PIM";       //Protocol Independent Multicast
            _tableProtocols[104] = "ARIS";      //ARIS
            _tableProtocols[105] = "SCPS";      //SCPS
            _tableProtocols[106] = "QNX";       //QNX
            _tableProtocols[107] = "A/N";       //Active Networks
            _tableProtocols[108] = "IPComp";    //IP Payload Compression Protocol
            _tableProtocols[109] = "SNP";       //Sitara Networks Protocol
            _tableProtocols[110] = "Compaq-Peer";//Compaq Peer Protocol
            _tableProtocols[111] = "IPX-in-IP"; //IPX in IP
            _tableProtocols[112] = "VRRP";      //Virtual Router Redundancy Protocol
            _tableProtocols[113] = "PGM";       //PGM Reliable Transport Protocol
            _tableProtocols[114] = "Any_Protocol_0-hop";
            _tableProtocols[115] = "L2TP";      //Layer Two Tunneling Protocol
            _tableProtocols[116] = "DDX";       //D-II Data Exchange (DDX)
            _tableProtocols[117] = "IATP";      //Interactive Agent Transfer Protocol
            _tableProtocols[118] = "STP";       //Schedule Transfer Protocol
            _tableProtocols[119] = "SRP";       //SpectraLink Radio Protocol
            _tableProtocols[120] = "UTI";       //UTI
            _tableProtocols[121] = "SMP";       //Simple Message Protocol
            _tableProtocols[122] = "SM";        //SM
            _tableProtocols[123] = "PTP";       //Performance Transparency Protocol
            _tableProtocols[124] = "ISIS over IPv4";
            _tableProtocols[125] = "FIRE";
            _tableProtocols[126] = "CRTP";      //Combat Radio Transport Protocol
            _tableProtocols[127] = "CRUDP";     //Combat Radio User Datagram
            _tableProtocols[128] = "SSCOPMCE";
            _tableProtocols[129] = "IPLT";
            _tableProtocols[130] = "SPS";       //Secure Packet Shield
            _tableProtocols[131] = "PIPE";      //Private IP Encapsulation within IP
            _tableProtocols[132] = "SCTP";      //Stream Control Transmission Protocol
            _tableProtocols[133] = "FC";        //Fibre Channel

            /*
             * 134-254 - free numbers
             * 255 - reserved number 
             * */
        }
    }
}
