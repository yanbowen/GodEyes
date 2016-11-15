using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PacketDotNet;

namespace MySniffer
{
    class Format
    {
        /// <summary>
        /// 格式化MAC地址
        /// </summary>
        /// <param name="MacAddress"></param>
        /// <returns></returns>
        public static string MacFormat(string MacAddress)
        {
            for (int i = 10; i > 0; i = i - 2)
            {
                MacAddress = MacAddress.Insert(i, "-");
            }
            return MacAddress;
        }
        /// <summary>
        /// 十六进制显示
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RawDataFormat(byte[] data)
        {
            StringBuilder strBu = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                strBu.AppendFormat("{0:X2} ", data[i]);
                if (i % 16 == 15)
                    strBu.Append("\r\n");
            }
            return strBu.ToString();
        }


        public static string RawDataShotFormat(byte[] data)
        {
            StringBuilder strBu = new StringBuilder();
            int flags=data .Length;
            if (flags > 15)
            {
                flags = 15;
            }
            for (int i = 0; i < flags; i++)
            {
                strBu.AppendFormat("{0:X2} ", data[i]);
            }
            strBu.Append("……");
            return strBu.ToString();
        }

        //获取状态
        public static short getStaus(bool isSelect)
        {
            return (short)(isSelect ? 1 : 0);
        }

        /// <summary>
        /// 获取Flag标志位
        /// </summary>
        /// <param name="tcp"></param>
        /// <returns></returns>
        public static string TcpFlagType(TcpPacket tcp)
        {
            StringBuilder sbr = new StringBuilder();
            if (tcp.Ack)
                sbr.Append("ACK ");
            if (tcp.Urg)
                sbr.Append("URG ");
            if (tcp.Psh)
                sbr.Append("PSH ");
            if (tcp.Rst)
                sbr.Append("RST ");
            if (tcp.Syn)
                sbr.Append("SYN ");
            if (tcp.Fin)
                sbr.Append("FIN ");
            if (tcp.ECN)
                sbr.Append("ECN ");
            if (tcp.CWR)
                sbr.Append("CWR ");
            return sbr.ToString();

        }
    }
}
