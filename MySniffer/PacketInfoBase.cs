using PacketDotNet;
using SharpPcap;
using System.Windows.Forms;
using System.Text;
using System;
using TwzyProtocol;
using System.Collections.Generic;


namespace MySniffer
{
    /// <summary>
    /// 用于分析数据包的类
    /// </summary>
    partial class PacketInfo
    {
        //原始网络包
        Packet packet;
        //分析完成之后的载荷数据
        public byte[] PayLoadData;
        //原始数据
        public byte[] Data;
        //协议树
        private TreeView Tree;

        public PacketInfo(TreeView tree)
        {
            this.Tree = tree;
        }

        /// <summary>
        /// 根据名称创造节点
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="imgIndex">图标索引</param>
        /// <returns>节点</returns>
        private TreeNode CreatNode(string name, int imgIndex)
        {
           // if (imgIndex >= Tree.ImageList.Images.Count)
            //    throw new ArgumentException("无效的图标索引！");
            TreeNode node = new TreeNode(name);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Name = name;
            return node;
        }

        TreeNode ExtraDataNode;
        private void ExtraData(byte[] data)
        {
            if (data.Length == 0)
                return;
            if (ExtraDataNode == null)
            {
                ExtraDataNode = CreatNode("Extra", 13);
            }
            ExtraDataNode.Nodes.Clear();
            ExtraDataNode.Text = "Extra Data [bytes Size: " + data.Length + "]";
            ExtraDataNode.Nodes.Add("Data: " + Format.RawDataShotFormat(data));

            Tree.Nodes.Add(ExtraDataNode);
        }

        #region Frame
        TreeNode FrameNode;
        /// 获取最终的数据包封装协议
        public void GetProtcolTree(RawCapture rawPacket)
        {
            Tree.Nodes.Clear();
            Data = rawPacket.Data;

            //构建每个Frame节点
            if (FrameNode == null)
            {
                FrameNode = CreatNode("Frame", 0);
            }
            FrameNode.Nodes.Clear();

            FrameNode.Nodes.Add("Lenght: " + rawPacket.Data.Length.ToString() + " bytes");
            FrameNode.Nodes.Add("Time: " + rawPacket.Timeval.ToString() + " [" + rawPacket.Timeval.Date.ToLocalTime().ToString() + "]");
            FrameNode.Nodes.Add("LinkLayerType: " + rawPacket.LinkLayerType.ToString() + " [0x" + rawPacket.LinkLayerType.ToString("X") + "]");
            Tree.Nodes.Add(FrameNode);
            ///构建通用数据包
            packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            switch (rawPacket.LinkLayerType)
            {
                case LinkLayers.Ethernet://以太网
                    Ethernet(packet);
                    break;
                case LinkLayers.Ppp:
                    byte[] tmpData = PacketDotNet.PPPPacket.GetEncapsulated(packet).Bytes;
                    if (tmpData.Length > 0)
                    {
                        PPP(new TwzyProtocol.PPPPacket(tmpData));
                    }
                    break;
                case LinkLayers.PppSerial:
                    PPPS(PppSerialPacket.GetEncapsulated(packet));
                    break;
                case LinkLayers.CiscoHDLC:
                    HDLC(CiscoHDLCPacket.GetEncapsulated(packet));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 链路层

        #region Enthernet

        TreeNode EthernetNode;
        /// <summary>
        /// 以太网
        /// </summary>
        /// <param name="packet"></param>
        private void Ethernet(Packet packet)
        {
            EthernetPacket e = EthernetPacket.GetEncapsulated(packet);
            if (EthernetNode == null)
            {
                EthernetNode = new TreeNode("EthernetII");
                EthernetNode.Name = "Ethernet";
                EthernetNode.ImageIndex =0;
                EthernetNode.SelectedImageIndex = 0;
            }
            EthernetNode.Nodes.Clear();

            EthernetNode.Nodes.Add("Destination: " + Format.MacFormat(e.DestinationHwAddress.ToString()));
            EthernetNode.Nodes.Add("Source: " + Format.MacFormat(e.SourceHwAddress.ToString()));
            EthernetNode.Nodes.Add("Type: " + e.Type.ToString() + " [0x" + e.Type.ToString("X") + "]");
            Tree.Nodes.Add(EthernetNode);

            switch (e.Type)
            {
                case EthernetPacketType.Arp://ARP协议
                    ARPPacket arp = ARPPacket.GetEncapsulated(packet);
                    Arp(arp);
                    break;
                case EthernetPacketType.IpV4://IP协议
                case EthernetPacketType.IpV6:
                    IpPacket ip = IpPacket.GetEncapsulated(packet);
                    IP(ip);
                    break;
                case EthernetPacketType.WakeOnLan://网络唤醒协议
                    WakeOnLanPacket wake = WakeOnLanPacket.GetEncapsulated(packet);
                    Wake_on_Lan(wake);
                    break;
                case EthernetPacketType.LLDP://链路层发现协议
                    LLDPPacket ll = LLDPPacket.GetEncapsulated(packet);
                    LLDPProtocol(ll);
                    break;
                case EthernetPacketType.PointToPointProtocolOverEthernetDiscoveryStage:
                case EthernetPacketType.PPPoE:
                    PPPoEPacket pppoe = PPPoEPacket.GetEncapsulated(packet);
                    PPPOE(pppoe);
                    break;
                case EthernetPacketType.None://无可用协议
                default:
                    PayLoadData = e.PayloadData;
                    break;
            }
        }
        #endregion

        //网络唤醒协议
        TreeNode WakeOnLanNode;
        private void Wake_on_Lan(WakeOnLanPacket wol)
        {
            if (WakeOnLanNode == null)
            {
                WakeOnLanNode = new TreeNode("Wake on Lan [网络唤醒协议]");
                WakeOnLanNode.ImageIndex = 0;
                WakeOnLanNode.SelectedImageIndex = 0;
                WakeOnLanNode.Name = "WOL";
            }
            WakeOnLanNode.Nodes.Clear();

            WakeOnLanNode.Nodes.Add("Correct: " + wol.IsValid());
            WakeOnLanNode.Nodes.Add("Destination: " + wol.DestinationMAC.ToString());
            Tree.Nodes.Add(WakeOnLanNode);
       }
        //链路层发现协议
        TreeNode LLDPNode;
        private void LLDPProtocol(LLDPPacket lldp)
        {
            if (LLDPNode == null)
            {
                LLDPNode = new TreeNode("LLDP [链路层发现协议]");
                LLDPNode.ImageIndex = 0;
                LLDPNode.SelectedImageIndex = 0;
                LLDPNode.Name = "LLDP";
            }
            LLDPNode.Nodes.Clear();

            LLDPNode.Nodes.Add("Length: " + lldp.Length.ToString());
            foreach (var l in lldp.TlvCollection)
            {
                LLDPNode.Nodes.Add("Type: " + l.Type.ToString() + " Length: " + l.TotalLength.ToString());
            }
            Tree.Nodes.Add(LLDPNode);

       }
        //PPPoE
        TreeNode PPPoENode;
        private void PPPOE(PPPoEPacket pppoe)
        {
            if (PPPoENode == null)
            {
                PPPoENode = CreatNode("PPPoE", 11);
            }
            PPPoENode.Nodes.Clear();

            PPPoENode.Nodes.Add(Convert.ToString(pppoe.Version, 2).PadLeft(4, '0') + " .... = Version: " + pppoe.Version.ToString());
            PPPoENode.Nodes.Add(".... " + Convert.ToString(pppoe.Type, 2).PadLeft(4, '0') + " = Type: " + pppoe.Type.ToString());
            PPPoENode.Nodes.Add("Code: 0x" + pppoe.Code.ToString("X") + " (" + pppoe.Code + ")");
            PPPoENode.Nodes.Add("Session Id: " + pppoe.SessionId.ToString() + " [0x" + pppoe.SessionId.ToString("X4") + "]");
            PPPoENode.Nodes.Add("Payload Length: " + pppoe.Length.ToString());
            Tree.Nodes.Add(PPPoENode);


            //查看数据
            var ppp = PacketDotNet.PPPPacket.GetEncapsulated(packet);
            if (ppp.Bytes.Length > 0)
            {
                var tmpPPP = new TwzyProtocol.PPPPacket(ppp.Bytes);
                PPP(tmpPPP);
            }
        }

        #region PPP
        //PPP
        TreeNode PPPNode;
        /// <summary>
        /// 通过TwzyProtocol实现
        /// </summary>
        /// <param name="ppp"></param>
        private void PPP(TwzyProtocol.PPPPacket ppp)
        {
            if (PPPNode == null)
            {
                PPPNode = CreatNode("PPP", 10);
            }
            PPPNode.Text = "PPP [0x" + ((ushort)ppp.Protocol).ToString("X4") + "]";
            PPPNode.Nodes.Clear();

            PPPNode.Nodes.Add("Protocol: " + ppp.Protocol.ToString() + " [0x" + ppp.Protocol.ToString("X") + "]");
            Tree.Nodes.Add(PPPNode);
            switch (ppp.Protocol)
            {
                case PPPProType.IPv4:
                case PPPProType.IPv6:
                    IpPacket ip = IpPacket.GetEncapsulated(packet);
                    IP(ip);
                    break;
                case PPPProType.LCP:
                    LCPPacket lcp = LCPPacket.GetEncapsulated(packet);
                    LCP(lcp);
                    break;
                case PPPProType.CompressedDatagram:
                    ExtraData(ppp.PayloadData);
                    return;
                case PPPProType.Padding://填充
                    break;
            }
        }
        /// <summary>
        /// 通过PacketDotNet类库实现
        /// </summary>
        /// <param name="ppp"></param>
        private void PPP(PacketDotNet.PPPPacket ppp)
        {
            if (PPPNode == null)
            {
                PPPNode = CreatNode("PPP", 10);
            }
            PPPNode.Text = "PPP [0x" + ((ushort)ppp.Protocol).ToString("X4") + "]";
            PPPNode.Nodes.Clear();

            PPPNode.Nodes.Add("Protocol: " + ppp.Protocol.ToString() + " [0x" + ppp.Protocol.ToString("X") + "]");

            Tree.Nodes.Add(PPPNode);
  
            switch (ppp.Protocol)
            {
                case PPPProtocol.IPv4:
                case PPPProtocol.IPv6:
                    IpPacket ip = IpPacket.GetEncapsulated(packet);
                    IP(ip);
                    break;
                case PPPProtocol.LCP:
                    LCPPacket lcp = LCPPacket.GetEncapsulated(packet);
                    LCP(lcp);
                    break;
                case PPPProtocol.CompressedDatagram:
                    ExtraData(ppp.PayloadData);
                    return;
                case PPPProtocol.Padding://填充
                    break;
            }
        }
        #endregion
        //PPPS
        TreeNode PPPSNode;
        private void PPPS(PppSerialPacket ppps)
        {
            if (PPPSNode == null)
            {
                PPPSNode = new TreeNode("PPP");
                PPPSNode.Name = "PPPSerial";
                PPPSNode.SelectedImageIndex = 0;
                PPPSNode.ImageIndex = 0;
            }
            PPPSNode.Nodes.Clear();

            PPPSNode.Nodes.Add("Address: 0x" + ppps.Address.ToString("X2"));
            PPPSNode.Nodes.Add("Control: 0x" + ppps.Control.ToString("X2"));
            PPPSNode.Nodes.Add("Protocol: " + ppps.Protocol.ToString() + " [0x" + ppps.Protocol.ToString("X") + "]");
            Tree.Nodes.Add(PPPSNode);


            switch (ppps.Protocol)
            {
                case PPPProtocol.IPv4:
                case PPPProtocol.IPv6:
                    IpPacket ip = IpPacket.GetEncapsulated(packet);
                    IP(ip);
                    break;
                case PPPProtocol.LCP:
                    LCPPacket lcp = LCPPacket.GetEncapsulated(packet);
                    LCP(lcp);
                    break;
                case PPPProtocol.Padding://填充
                case PPPProtocol.CDP://Csico 发现协议

                    break;
            }
        }
        //HDLC
        TreeNode HDLCNode;
        private void HDLC(CiscoHDLCPacket hdlc)
        {
            if (HDLCNode == null)
            {
                HDLCNode = new TreeNode("Cisco HDLC");
                HDLCNode.Name = "HDLC";
                HDLCNode.ImageIndex = 0;
                HDLCNode.SelectedImageIndex = 0;
            }
            HDLCNode.Nodes.Clear();

            HDLCNode.Nodes.Add("Address: 0x" + hdlc.Address.ToString("X2"));
            HDLCNode.Nodes.Add("Control: 0x" + hdlc.Control.ToString("X2"));
            HDLCNode.Nodes.Add("Protocol: " + hdlc.Protocol.ToString() + " [0x" + hdlc.Protocol.ToString("X") + "]");

            Tree.Nodes.Add(HDLCNode);

            switch (hdlc.Protocol)
            {
                case HDLCType.CDP://Csico 发现协议
                case HDLCType.SLARP://链路控制协议
                    break;
            }

        }
        //LCP ppp链路控制协议
        TreeNode LCPNode;
        private void LCP(LCPPacket lcp)
        {
            if (LCPNode == null)
            {
                LCPNode = CreatNode("LCP", 4);
            }
            LCPNode.Nodes.Clear();

            LCPNode.Nodes.Add("Code: " + lcp.Code + " [0x" + lcp.Code.ToString("X") + "]");
            LCPNode.Nodes.Add("Identifier: " + lcp.Identifier.ToString("X2"));
            LCPNode.Nodes.Add("Length: " + lcp.Length);
            LCPNode.Nodes.Add("Data (" + lcp.PayloadData.Length + "bytes)");

            Tree.Nodes.Add(LCPNode);

        }
        //LinuxSLL
        TreeNode LinuxSllNode;
        private void LinuxSLL(LinuxSLLPacket linuxSLL)
        {
            if (LinuxSllNode == null)
            {
                LinuxSllNode = new TreeNode("LinuxSLL");
                LinuxSllNode.ImageIndex = 0;
                LinuxSllNode.SelectedImageIndex =0;
                LinuxSllNode.Name = "SLL";
            }
            LinuxSllNode.Nodes.Clear();

            LinuxSllNode.Nodes.Add("Type: " + linuxSLL.Type.ToString() + " (" + ((int)linuxSLL.Type).ToString() + ")");
            LinuxSllNode.Nodes.Add("Link Layer address Type: " + linuxSLL.LinkLayerAddressType.ToString());
            LinuxSllNode.Nodes.Add("Link Layer address Length: " + linuxSLL.LinkLayerAddressLength.ToString());
            LinuxSllNode.Nodes.Add("Surce: " + BitConverter.ToString(linuxSLL.LinkLayerAddress));
            LinuxSllNode.Nodes.Add("Protocol: " + linuxSLL.EthernetProtocolType.ToString() + " [0x" + linuxSLL.EthernetProtocolType.ToString("X") + "]");

            Tree.Nodes.Add(LinuxSllNode);

       }

        #endregion

        #region 网络层
        TreeNode ArpNode;
        private void Arp(ARPPacket arp)
        {
            if (ArpNode == null)
            {
                ArpNode = CreatNode("ARP", 2);
            }
            ArpNode.Nodes.Clear();

            ArpNode.Nodes.Add("Hardware Type: " + arp.HardwareAddressType.ToString() + " [0x" + arp.HardwareAddressType.ToString("X") + "]");
            ArpNode.Nodes.Add("Protocol Type: " + arp.ProtocolAddressType.ToString() + " [0x" + arp.ProtocolAddressType.ToString("X") + "]");
            ArpNode.Nodes.Add("Hardware size: " + arp.HardwareAddressLength);
            ArpNode.Nodes.Add("Protocol size: " + arp.ProtocolAddressLength);
            ArpNode.Nodes.Add("Operation: " + arp.Operation.ToString() + " [0x" + arp.Operation.ToString("x") + "]");
            ArpNode.Nodes.Add("Sender Hardware Address: " + Format.MacFormat(arp.SenderHardwareAddress.ToString()));
            ArpNode.Nodes.Add("Sender Protocol Address: " + arp.SenderProtocolAddress.ToString());
            ArpNode.Nodes.Add("Target Hardware Address: " + Format.MacFormat(arp.TargetHardwareAddress.ToString()));
            ArpNode.Nodes.Add("Target Protocol Address: " + arp.TargetProtocolAddress.ToString());
            Tree.Nodes.Add(ArpNode);

        }
        #region IP
        //IP

        private void IP(IpPacket ip)
        {
            if (ip.Version == IpVersion.IPv4)
            {
                IPv4Packet ipv4 = ip as IPv4Packet;
                IPv4(ipv4);

            }
            else
            {
                IPv6Packet ipv6 = ip as IPv6Packet;
                IPv6(ipv6);
            }
            ipNext(ip);

        }
        private void ipNext(IpPacket ip)
        {
            PayLoadData = ip.PayloadData;
            switch (ip.NextHeader)
            {
                case IPProtocolType.TCP://最终协议为TCP
                    TcpPacket tcp = TcpPacket.GetEncapsulated(packet);
                    TCP(tcp);
                    break;
                case IPProtocolType.UDP:
                    UdpPacket udp = UdpPacket.GetEncapsulated(packet);
                    UDP(udp);
                    break;
                case IPProtocolType.ICMP:
                    ICMPv4Packet icmp = ICMPv4Packet.GetEncapsulated(packet);
                    ICMPv4(icmp);
                    break;
                case IPProtocolType.ICMPV6:
                    ICMPv6Packet icmpv6 = ICMPv6Packet.GetEncapsulated(packet);
                    ICMPv6(icmpv6);
                    break;
                case IPProtocolType.IGMP:
                    IGMPv2Packet igmp = IGMPv2Packet.GetEncapsulated(packet);
                    IGMP(igmp);
                    break;
                case IPProtocolType.IPV6:
                    List<byte> packetData = new List<byte>();
                    byte[] tmp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    packetData.AddRange(tmp);
                    packetData.AddRange(new byte[] { 0x86, 0xdd });
                    packetData.AddRange(ip.PayloadData);
                    Packet p = Packet.ParsePacket(LinkLayers.Ethernet, packetData.ToArray());
                    IPv6Packet ip6 = (IPv6Packet)IPv6Packet.GetEncapsulated(p);
                    IPv6(ip6);
                    packet = p;
                    ipNext(ip6 as IpPacket);
                    break;
                case IPProtocolType.GRE:
                    GREPacket gre = new GREPacket(ip.PayloadData);
                    GRE(gre);
                    break;
            }
        }

        //IPv4
        TreeNode IPv4Node;
        TreeNode DifferNode;
        TreeNode IPv4FlagNode;
        TreeNode IPv4ChecksumNode;
        private void IPv4(IPv4Packet v4)
        {
            if (IPv4Node == null)
            {
                IPv4Node = new TreeNode("IPv4");
                IPv4Node.ImageIndex = 0;
                IPv4Node.SelectedImageIndex = 0;
                IPv4Node.Name = "IPv4";

            }
            IPv4Node.Nodes.Clear();

            IPv4Node.Nodes.Add("Version: " + v4.Version.ToString());
            IPv4Node.Nodes.Add("Header Length: " + v4.Header.Length.ToString() + " bytes");
            #region 区分服务
            if (DifferNode == null)
            {
                DifferNode = new TreeNode();
            }
            DifferNode.Nodes.Clear();
            DifferNode.Text = "Differentiated Services: 0x" + v4.DifferentiatedServices.ToString("X2");

            string diffServices = Convert.ToString(v4.DifferentiatedServices, 2).PadLeft(8, '0').Insert(4, " ");
            DifferNode.Nodes.Add(diffServices.Substring(0, 7) + ".. = [" + (v4.DifferentiatedServices >> 2) + "] Differentiated Services Codepoint");
            DifferNode.Nodes.Add(".... .." + diffServices[7] + ". = [" + diffServices[7] + "] ECN");
            DifferNode.Nodes.Add(".... ..." + diffServices[8] + " = [" + diffServices[8] + "] ECE");
            IPv4Node.Nodes.Add(DifferNode);
            #endregion
            IPv4Node.Nodes.Add("Total Length: " + v4.TotalLength.ToString());
            IPv4Node.Nodes.Add("Identification: 0x" + v4.Id.ToString("X2") + " (" + v4.Id + ")");
            #region Flag
            if (IPv4FlagNode == null)
            {
                IPv4FlagNode = new TreeNode();
            }
            IPv4FlagNode.Nodes.Clear();
            IPv4FlagNode.Text = "Flags: 0x" + v4.FragmentFlags.ToString("X2");

            string flagStr = Convert.ToString(v4.FragmentFlags, 2).PadLeft(8, '0').Substring(5, 3);
            IPv4FlagNode.Nodes.Add(flagStr[0] + "... .... = [" + flagStr[0] + "] Reserved bit");
            IPv4FlagNode.Nodes.Add("." + flagStr[1] + ".. .... = [" + flagStr[1] + "] Don't Fragment");
            IPv4FlagNode.Nodes.Add(".." + flagStr[2] + ". .... = [" + flagStr[2] + "] More Fragment");
            IPv4Node.Nodes.Add(IPv4FlagNode);
            #endregion
            IPv4Node.Nodes.Add("Fragment offset: " + v4.FragmentOffset.ToString());
            IPv4Node.Nodes.Add("Time To Live: " + v4.HopLimit.ToString() + " hops");
            IPv4Node.Nodes.Add("Protocol: " + v4.Protocol.ToString() + " (" + v4.Protocol.ToString("d") + ")");
            if (IPv4ChecksumNode == null)
            {
                IPv4ChecksumNode = new TreeNode();
            }
            IPv4ChecksumNode.Nodes.Clear();
            IPv4ChecksumNode.Text = "Header Checksum: 0x" + v4.Checksum.ToString("X2") + " [" + (v4.ValidChecksum ? "Valid" : "Invalid") + "]";
            if (!v4.ValidChecksum)
            {
                IPv4Node.BackColor = IPv4ChecksumNode.BackColor = System.Drawing.Color.Red;
                IPv4Node.ForeColor = IPv4ChecksumNode.ForeColor = System.Drawing.Color.White;

            }
            else
            {
                IPv4Node.BackColor = IPv4ChecksumNode.BackColor = Tree.BackColor;
                IPv4Node.ForeColor = IPv4ChecksumNode.ForeColor = Tree.ForeColor;
            }

            IPv4ChecksumNode.Nodes.Add("Correct: " + v4.ValidIPChecksum.ToString());
            IPv4Node.Nodes.Add(IPv4ChecksumNode);
            IPv4Node.Nodes.Add("Source: " + v4.SourceAddress.ToString());
            IPv4Node.Nodes.Add("Destination: " + v4.DestinationAddress.ToString());
            Tree.Nodes.Add(IPv4Node);
     }
        //IPv6
        TreeNode IPv6Node;
        TreeNode trafficNode;
        private void IPv6(IPv6Packet v6)
        {
            if (IPv6Node == null)
            {
                IPv6Node = new TreeNode("IPv6");
                IPv6Node.ImageIndex = 0;
                IPv6Node.SelectedImageIndex =0;
                IPv6Node.Name = "IPv6";
            }
            IPv6Node.Nodes.Clear();

            string ipver = Convert.ToString((int)v6.Version, 2).PadLeft(4, '0');
            IPv6Node.Nodes.Add("Version:       " + ipver + " .... .... .... .... .... .... .... = " + v6.Version);
            #region Traffic Class
            string traffStr = Convert.ToString(v6.TrafficClass, 2).PadLeft(8, '0').Insert(4, " ");
            if (trafficNode == null)
            {
                trafficNode = new TreeNode();
            }
            trafficNode.Nodes.Clear();
            trafficNode.Text = "Traffic Class: .... " + traffStr + " .... .... .... .... .... = 0x" + v6.TrafficClass.ToString("X").PadLeft(8, '0');
            trafficNode.Nodes.Add("            .... " + traffStr.Substring(0, 7) + ".. .... .... .... .... .... = [" + (v6.TrafficClass >> 2) + "]Differentiated Services Field");
            trafficNode.Nodes.Add("            .... .... .." + traffStr[7] + ". .... .... .... .... .... = [" + traffStr[7] + "]ECT ECN-Capable Transport");
            trafficNode.Nodes.Add("            .... .... ..." + traffStr[8] + " .... .... .... .... .... = [" + traffStr[8] + "]ECN-CE");
            #endregion

            IPv6Node.Nodes.Add(trafficNode);

            string flowLableStr = Convert.ToString(v6.FlowLabel, 2).PadLeft(20, '0').Insert(16, " ").Insert(12, " ").Insert(8, " ").Insert(4, " ");
            IPv6Node.Nodes.Add("Flow Label:    .... .... .... " + flowLableStr + " = 0x" + v6.FlowLabel.ToString("X").PadLeft(8, '0'));
            IPv6Node.Nodes.Add("Payload Length: " + v6.PayloadLength.ToString());
            IPv6Node.Nodes.Add("Next Header: " + v6.NextHeader.ToString() + " (0x" + v6.NextHeader.ToString("d") + ")");
            IPv6Node.Nodes.Add("Hop Limit: " + v6.HopLimit.ToString());
            IPv6Node.Nodes.Add("Source: " + v6.SourceAddress.ToString());
            IPv6Node.Nodes.Add("Destination: " + v6.DestinationAddress.ToString());
            Tree.Nodes.Add(IPv6Node);


        }
        #endregion

        #region ICMP IGMP
        //ICMPv4
        TreeNode ICMPv4Node;
        private void ICMPv4(ICMPv4Packet v4)
        {
            if (ICMPv4Node == null)
            {
                ICMPv4Node = CreatNode("ICMPv4", 4);
            }
            ICMPv4Node.Nodes.Clear();

            ICMPv4Node.Nodes.Add("Type/Code: " + v4.TypeCode.ToString() + " [0x" + v4.TypeCode.ToString("X") + "]");
            ICMPv4Node.Nodes.Add("Checksum: 0x" + v4.Checksum.ToString("X"));
            ICMPv4Node.Nodes.Add("Identifier: " + v4.ID.ToString("d") + " [0x" + v4.ID.ToString("X") + "]");
            ICMPv4Node.Nodes.Add("Sequence Number: " + v4.Sequence.ToString() + " [0x" + v4.Sequence.ToString("X") + "]");
            Tree.Nodes.Add(ICMPv4Node);

        }
        //ICMPv6
        TreeNode ICMPv6Node;
        private void ICMPv6(ICMPv6Packet v6)
        {
            if (ICMPv6Node == null)
            {
                ICMPv6Node = CreatNode("ICMPv6", 4);
            }
            ICMPv6Node.Nodes.Clear();

            ICMPv6Node.Nodes.Add("Type: " + v6.Type.ToString() + " (" + (int)v6.Type + ")");
            ICMPv6Node.Nodes.Add("Code: " + v6.Code.ToString());
            ICMPv6Node.Nodes.Add("checksum: 0x" + v6.Checksum.ToString("X"));
            Tree.Nodes.Add(ICMPv6Node);

        }

        //IGMP
        TreeNode IGMPNode;
        private void IGMP(IGMPv2Packet v2)
        {
            if (IGMPNode == null)
            {
                IGMPNode = new TreeNode("IGMP  [只适用于IGMPv2]");
                IGMPNode.ImageIndex = 4;
                IGMPNode.SelectedImageIndex = 4;
                IGMPNode.Name = "IGMP";
            }
            IGMPNode.Nodes.Clear();

            IGMPNode.Nodes.Add("Type: " + v2.Type.ToString() + " [0x" + v2.Type.ToString("X") + "]");
            IGMPNode.Nodes.Add("Max Response Time: " + string.Format("{0:0:0}", v2.MaxResponseTime / 10) + "sec [0x" + v2.MaxResponseTime.ToString("X") + "]");
            IGMPNode.Nodes.Add("Header Checksum: 0x" + v2.Checksum.ToString("X"));
            IGMPNode.Nodes.Add("Group Address: " + v2.GroupAddress.ToString());
            Tree.Nodes.Add(IGMPNode);

        }
        #endregion

        #endregion

        //GRE协议
        #region GRE
        private void GRE(GREPacket gre)
        {
            if (gre.Version == GREVersion.GREv0)
            { }
            else if (gre.Version == GREVersion.GREv1)
            {
                GREv1Packet v1 = new GREv1Packet(gre.rawData);
                if (v1 != null)
                {
                    GREv1(v1);
                }
            }
        }
        /// <summary>
        /// GRE封装的下层协议
        /// </summary>
        /// <param name="data"></param>
        /// <param name="e"></param>
        private void NextGRE(byte[] data, EthernetProtocolType e)
        {
            if (data.Length <= 0)
                return;
            switch (e)
            {
                case EthernetProtocolType .PPP:
                    var ppp = new TwzyProtocol.PPPPacket(data);
                    if (ppp != null)
                        PPP(ppp);
                    break;
                case EthernetProtocolType.Arp://ARP协议
                    ARPPacket arp = ARPPacket.GetEncapsulated(packet);
                    Arp(arp);
                    break;
                case EthernetProtocolType.IpV4://IP协议
                case EthernetProtocolType.IpV6:
                    IpPacket ip = IpPacket.GetEncapsulated(packet);
                    IP(ip);
                    break;
                case EthernetProtocolType.WakeOnLan://网络唤醒协议
                    WakeOnLanPacket wake = WakeOnLanPacket.GetEncapsulated(packet);
                    Wake_on_Lan(wake);
                    break;
                case EthernetProtocolType.LLDP://链路层发现协议
                    LLDPPacket ll = LLDPPacket.GetEncapsulated(packet);
                    LLDPProtocol(ll);
                    break;
                case EthernetProtocolType.PointToPointProtocolOverEthernetDiscoveryStage:
                case EthernetProtocolType.PPPoE:
                    PPPoEPacket pppoe = PPPoEPacket.GetEncapsulated(packet);
                    PPPOE(pppoe);
                    break;
                case EthernetProtocolType.None://无可用协议
                    break;
            }

        }

        //GREv1
        TreeNode GREv1Node;
        TreeNode GREv1FlagsNode;
        private void GREv1(GREv1Packet v1)
        {
            if (GREv1Node == null)
            {
                GREv1Node = CreatNode("GREv1", 12);
            }
            GREv1Node.Nodes.Clear();

            #region CRKSsFlagsVersion
            if (GREv1FlagsNode == null)
                GREv1FlagsNode = new TreeNode();
            GREv1FlagsNode.Nodes.Clear();
            GREv1FlagsNode.Text = "CRKSsAFlagsVersion：[0x" + v1.CRKSsAFlagsVersion.ToString("X4") + "]";
            //第一个字节
            GREv1FlagsNode.Nodes.Add(v1.C + "... .... .... .... = [" + v1.C + "] C(Checksum Present): " + ((v1.C == 1) ? "Yes" : "No"));//0
            GREv1FlagsNode.Nodes.Add("." + v1.R + ".. .... .... .... = [" + v1.R + "] R(Routing Present): " + ((v1.R == 1) ? "Yes" : "No"));//0
            GREv1FlagsNode.Nodes.Add(".." + v1.K + ". .... .... .... = [" + v1.K + "] K(Key Present): " + ((v1.K == 1) ? "Yes" : "No"));//used
            GREv1FlagsNode.Nodes.Add("..." + v1.S + " .... .... .... = [" + v1.S + "] S(Sequence Number present): " + ((v1.S == 1) ? "Yes" : "No"));//used
            GREv1FlagsNode.Nodes.Add(".... " + v1.s + "... .... .... = [" + v1.s + "] s(Strict Source Route): " + ((v1.s == 1) ? "Yes" : "No"));//0
            string tmpRecuer = Convert.ToString(v1.Recur, 2).PadLeft(3, '0');
            GREv1FlagsNode.Nodes.Add(".... ." + tmpRecuer + " .... .... = [0x" + v1.Recur.ToString("X2") + "] Recur(Recursion Control): " + v1.Recur);//0  递归控制
            //第二个字节
            GREv1FlagsNode.Nodes.Add(".... .... " + v1.A + "... .... = [" + v1.A + "] A(Acknowledgment sequence number present): " + ((v1.A == 1) ? "Yes" : "No"));//used
            string tmpFlags = Convert.ToString(v1.Flags).PadLeft(4, '0').Insert(3, " ");
            GREv1FlagsNode.Nodes.Add(".... .... ." + tmpFlags + "... = [0x" + v1.Flags.ToString("X2") + "] Flags: " + v1.Flags);//0
            GREv1FlagsNode.Nodes.Add(".... .... .... ." + Convert.ToString((ushort)v1.Version, 2).PadLeft(3, '0') + " = [0x" + ((ushort)v1.Version).ToString("X2") + "] Version: " + v1.Version);//used

            GREv1Node.Nodes.Add(GREv1FlagsNode);
            #endregion

            GREv1Node.Nodes.Add("Protocol: " + v1.Protocol + " [0x" + ((ushort)v1.Protocol).ToString("X4") + "]");
            GREv1Node.Nodes.Add("Payload Length: " + v1.PayloadLength);
            GREv1Node.Nodes.Add("Call ID: " + v1.CallID + " [0x" + ((ushort)v1.CallID).ToString("X4") + "]");

            if (v1.S == 1)
            {
                GREv1Node.Nodes.Add("Sequence Number: " + v1.SequenceNumber);
            }
            if (v1.A == 1)
            {
                GREv1Node.Nodes.Add("Acknowledgment Number: " + v1.AcknowledgmentNumber);
            }
            Tree.Nodes.Add(GREv1Node);
            NextGRE(v1.PayloadData,v1.Protocol);
        }

        #endregion

        #region 传输层
        //UDP
        TreeNode UDPNode;
        TreeNode UdpChecksumNode;
        private void UDP(UdpPacket udp)
        {
            if (UDPNode == null)
            {
                UDPNode = CreatNode("UDP", 5);
            }
            UDPNode.Nodes.Clear();

            UDPNode.Nodes.Add("Source Port: " + udp.SourcePort.ToString());
            UDPNode.Nodes.Add("Destination Port: " + udp.DestinationPort.ToString());
            UDPNode.Nodes.Add("Length: " + udp.Length.ToString());
            if (UdpChecksumNode == null)
            {
                UdpChecksumNode = new TreeNode();
            }
            UdpChecksumNode.Nodes.Clear();
            UdpChecksumNode.Text = "Checksum: 0x" + udp.Checksum.ToString("X") + " [" + (udp.ValidUDPChecksum ? "Valid" : "Invaid") + "]";

            UdpChecksumNode.Nodes.Add("Correct: " + udp.ValidUDPChecksum.ToString());
            if (!udp.ValidChecksum)
            {
                UDPNode.BackColor = UdpChecksumNode.BackColor = System.Drawing.Color.Red;
                UDPNode.ForeColor = UdpChecksumNode.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                UDPNode.BackColor = UdpChecksumNode.BackColor = Tree.BackColor;
                UDPNode.ForeColor = UdpChecksumNode.ForeColor = Tree.ForeColor;
            }
            UDPNode.Nodes.Add(UdpChecksumNode);
            Tree.Nodes.Add(UDPNode);

            //应用层协议

            AppNode(udp.PayloadData, udp.SourcePort, udp.DestinationPort);

        }
        //Tcp
        TreeNode TCPNode;
        TreeNode TcpFlagNode;
        TreeNode TcpChecksumNode;
        TreeNode TcpOptionsNode;
        private void TCP(TcpPacket tcp)
        {
            if (TCPNode == null)
            {
                TCPNode = CreatNode("TCP", 6);
            }
            TCPNode.Nodes.Clear();
            //port
            TCPNode.Nodes.Add("Source Port: " + tcp.SourcePort.ToString());
            TCPNode.Nodes.Add("Destination Port: " + tcp.DestinationPort.ToString());
            // Seq and Ack
            TCPNode.Nodes.Add("Sequence Number: " + tcp.SequenceNumber.ToString() + " [0x" + tcp.SequenceNumber.ToString("X") + "]");
            TCPNode.Nodes.Add("Acknowledgement Number: " + tcp.AcknowledgmentNumber.ToString() + " [0x" + tcp.AcknowledgmentNumber.ToString("X") + "]");
            //Data Offset
            TCPNode.Nodes.Add("Data Offset: " + (tcp.DataOffset * 4).ToString() + " [0x" + tcp.DataOffset.ToString("X") + "]");
            //Flags
            #region Flags
            if (TcpFlagNode == null)
            {
                TcpFlagNode = new TreeNode();
            }
            TcpFlagNode.Nodes.Clear();
            TcpFlagNode.Text = "Flags: [" + Format.TcpFlagType(tcp) + "] [0x" + string.Format("{0:X2}", tcp.AllFlags) + "]";
            TcpFlagNode.Nodes.Add("000. .... .... = Reserved");
            TcpFlagNode.Nodes.Add("...0 .... .... = Nonce");
            TcpFlagNode.Nodes.Add(".... " + Format.getStaus(tcp.CWR) + "... .... = CWR");
            TcpFlagNode.Nodes.Add(".... ." + Format.getStaus(tcp.ECN) + ".. .... = ECN-Echo");
            TcpFlagNode.Nodes.Add(".... .." + Format.getStaus(tcp.Urg) + ". .... = URG");
            TcpFlagNode.Nodes.Add(".... ..." + Format.getStaus(tcp.Ack) + " .... = ACK");
            TcpFlagNode.Nodes.Add(".... .... " + Format.getStaus(tcp.Psh) + "... = PSH");
            TcpFlagNode.Nodes.Add(".... .... ." + Format.getStaus(tcp.Rst) + ".. = RST");
            TcpFlagNode.Nodes.Add(".... .... .." + Format.getStaus(tcp.Syn) + ". = SYN");
            TcpFlagNode.Nodes.Add(".... .... ..." + Format.getStaus(tcp.Fin) + " = FIN");
            TCPNode.Nodes.Add(TcpFlagNode);
            #endregion
            //WinSize
            TCPNode.Nodes.Add("Window Size: " + tcp.WindowSize.ToString());
            //check Sum
            if (TcpChecksumNode == null)
            {
                TcpChecksumNode = new TreeNode();
            }
            TcpChecksumNode.Nodes.Clear();
            TcpChecksumNode.Text = "Checksum: 0x" + tcp.Checksum.ToString("X") + " [" + (tcp.ValidChecksum ? "Valid" : "Invalid") + "]";
            if (!tcp.ValidChecksum)
            {
                TCPNode.BackColor = TcpChecksumNode.BackColor = System.Drawing.Color.Red;
                TCPNode.ForeColor = TcpChecksumNode.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                TCPNode.BackColor = TcpChecksumNode.BackColor = Tree.BackColor;
                TCPNode.ForeColor = TcpChecksumNode.ForeColor = Tree.ForeColor;
            }

            TcpChecksumNode.Nodes.Add("Correct: " + tcp.ValidTCPChecksum.ToString());
            TCPNode.Nodes.Add(TcpChecksumNode);
            //Urgent
            TCPNode.Nodes.Add("Urgent Pointer: " + tcp.UrgentPointer.ToString() + " [0x" + tcp.UrgentPointer.ToString("X") + "]");
            //Options
            if (tcp.Options.Length > 0)
            {
                if (TcpOptionsNode == null)
                {
                    TcpOptionsNode = new TreeNode();
                }
                TcpOptionsNode.Nodes.Clear();
                TcpOptionsNode.Text = "Options: " + tcp.Options.Length.ToString() + " bytes";
                // [0x" + BitConverter.ToString(tcp.Options).Replace("-", "").PadLeft(12, '0') + "]
                if (tcp.OptionsCollection != null)
                {
                    var tmpColl = tcp.OptionsCollection;
                    for (int i = 0; i < tmpColl.Count; i++)
                    {
                        TcpOptionsNode.Nodes.Add(tmpColl[i].ToString());
                    }
                }
                TCPNode.Nodes.Add(TcpOptionsNode);
            }
            Tree.Nodes.Add(TCPNode);


            AppNode(tcp.PayloadData, tcp.SourcePort, tcp.DestinationPort);
        }

        #endregion

    }
}
