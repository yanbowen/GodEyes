using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
using System.Xml;
namespace MySniffer
{
    class DataBuilder
    {
        //标记当前数据是否有效

        #region 构建数据行
        /// <summary>
        /// DataGridRow
        /// </summary>
        /// <returns>返回字符串数据</returns>
        public string[] Row(RawCapture rawPacket, uint packetID)
        {
            string[] rows = new string[6];

            rows[0] = string.Format("{0:D7}", packetID);//编号
            rows[1] = "Unknown";
            rows[2] = rawPacket.Data.Length.ToString();//数据长度bytes
            rows[3] = "--";
            rows[4] = "--";
            rows[5] = "--";

            Packet packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            EthernetPacket ep = EthernetPacket.GetEncapsulated(packet);
            if (ep != null)
            {
                rows[1] = "Ethernet(v2)";
                rows[3] = Format.MacFormat(ep.SourceHwAddress.ToString());
                rows[4] = Format.MacFormat(ep.DestinationHwAddress.ToString());
                rows[5] = "[" + ep.Type.ToString() + "]";

                #region IP
                IpPacket ip = IpPacket.GetEncapsulated(packet);
                if (ip != null)
                {
                    if (ip.Version == IpVersion.IPv4)
                    {
                        rows[1] = "IPv4";
                    }
                    else
                    {
                        rows[1] = "IPv6";
                    }
                    rows[3] = ip.SourceAddress.ToString();
                    rows[4] = ip.DestinationAddress.ToString();
                    rows[5] = "[下层协议:" + ip.NextHeader.ToString() + "] [版本:" + ip.Version.ToString() + "]";

                    TcpPacket tcp = TcpPacket.GetEncapsulated(packet);
                    if (tcp != null)
                    {
                        rows[1] = "TCP";
                        rows[3] += " [" + tcp.SourcePort.ToString() + "]";
                        rows[4] += " [" + tcp.DestinationPort.ToString() + "]";
                     
                        return rows;
                    }
                    UdpPacket udp = UdpPacket.GetEncapsulated(packet);
                    if (udp != null)
                    {
                        rows[1] = "UDP";
                        rows[3] += " [" + udp.SourcePort.ToString() + "]";
                        rows[4] += " [" + udp.DestinationPort.ToString() + "]";
                        return rows;
                    }

                    ICMPv4Packet icmpv4 = ICMPv4Packet.GetEncapsulated(packet);
                    if (icmpv4 != null)
                    {
                        rows[1] = "ICMPv4";
                        rows[5] = "[校验:" + icmpv4.Checksum.ToString() + "] [类型:" + icmpv4.TypeCode.ToString() + "] [序列号:" + icmpv4.Sequence.ToString() + "]";
                        return rows;
                    }
                    ICMPv6Packet icmpv6 = ICMPv6Packet.GetEncapsulated(packet);
                    if (icmpv6 != null)
                    {
                        rows[1] = "ICMPv6";
                        rows[5] = "[Code:" + icmpv6.Code.ToString() + "] [Type" + icmpv6.Type.ToString() + "]";
                        return rows;
                    }
                    IGMPv2Packet igmp = IGMPv2Packet.GetEncapsulated(packet);
                    if (igmp != null)
                    {
                        rows[1] = "IGMP";
                        rows[5] = "[只适用于IGMPv2] [组地址:" + igmp.GroupAddress.ToString() + "]  [类型:" + igmp.Type.ToString() + "]";
                        return rows;
                    }
                    return rows;
                }
                #endregion

                ARPPacket arp = ARPPacket.GetEncapsulated(packet);
                if (arp != null)
                {
                    rows[1] = "ARP";
                    rows[3] = Format.MacFormat(arp.SenderHardwareAddress.ToString());
                    rows[4] = Format.MacFormat(arp.TargetHardwareAddress.ToString());
                    rows[5] = "[Arp操作方式:" + arp.Operation.ToString() + "] [发送者:" + arp.SenderProtocolAddress.ToString() + "] [目标:" + arp.TargetProtocolAddress.ToString() + "]";
                    return rows;
                }
                WakeOnLanPacket wp = WakeOnLanPacket.GetEncapsulated(packet);
                if (wp != null)
                {
                    rows[1] = "Wake On Lan";
                    rows[3] = Format.MacFormat(ep.SourceHwAddress.ToString());
                    rows[4] = Format.MacFormat(wp.DestinationMAC.ToString());
                    rows[5] = "[唤醒网络地址:" + wp.DestinationMAC.ToString() + "] [有效性:" + wp.IsValid().ToString() + "]";
                    return rows;
                }
                PPPoEPacket poe = PPPoEPacket.GetEncapsulated(packet);
                if (poe != null)
                {
                    rows[1] = "PPPoE";
                    rows[5] = poe.Type.ToString() + " " + poe.Version.ToString();
                    return rows;

                }
                LLDPPacket llp = LLDPPacket.GetEncapsulated(packet);
                if (llp != null)
                {
                    rows[1] = "LLDP";
                    rows[5] = llp.ToString();
                    return rows;
                }
                return rows;
            }
            //链路层
            PPPPacket ppp = PPPPacket.GetEncapsulated(packet);
            if (ppp != null)
            {
                rows[1] = "PPP";
                rows[3] = "--";
                rows[4] = "--";
                rows[5] = "协议类型:" + ppp.Protocol.ToString();
                return rows;

            }
            //PPPSerial
            PppSerialPacket ppps = PppSerialPacket.GetEncapsulated(packet);
            if (ppps != null)
            {
                rows[1] = "PPP";
                rows[3] = "--";
                rows[4] = "0x" + ppps.Address.ToString("X2");
                rows[5] = "地址：" + ppps.Address.ToString("X2") + " 控制：" + ppps.Control.ToString() + " 协议类型:" + ppps.Protocol.ToString();
                return rows;
            }
            //Cisco HDLC
            CiscoHDLCPacket hdlc = CiscoHDLCPacket.GetEncapsulated(packet);
            if (hdlc != null)
            {
                rows[1] = "Cisco HDLC";
                rows[3] = "--";
                rows[4] = "0x" + hdlc.Address.ToString("X2");
                rows[5] = "地址：" + hdlc.Address.ToString("X2") + " 控制：" + hdlc.Control.ToString() + " 协议类型:" + hdlc.Protocol.ToString();
                return rows;
            }
#warning 需要测试
            PacketDotNet.Ieee80211.MacFrame ieee = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data) as PacketDotNet.Ieee80211.MacFrame;
            if (ieee != null)
            {
                rows[1] = "IEEE802.11 MacFrame";
                rows[3] = "--";
                rows[4] = "--";
                rows[5] = "帧校验序列:" + ieee.FrameCheckSequence.ToString() + " 封装帧:" + ieee.FrameControl .ToString();
                return rows;
            }
            PacketDotNet.Ieee80211.RadioPacket ieeePacket = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data) as PacketDotNet.Ieee80211.RadioPacket;
            if (ieeePacket != null)
            {
                rows[1] = "IEEE Radio";
                rows[5] = "Version=" + ieeePacket.Version.ToString();
            }
            LinuxSLLPacket linux = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data) as LinuxSLLPacket;
            if (linux != null)
            {
                rows[1] = "LinuxSLL";
                rows[5] = "Tyep=" + linux.Type.ToString() + " Protocol=" + linux.EthernetProtocolType.ToString();
            }
            return rows;
        }
    }
        #endregion




}
