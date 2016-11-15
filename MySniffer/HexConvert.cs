using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySniffer
{
    class HexConvert
    {
        /// <summary>
        /// 拼接十六进制字符串
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns></returns>
        public static string ConvertToHexText(byte[] data)
        {
            var buffer = new StringBuilder();
            string bytes = "";
            string ascii = "";
            //转化原始数据
            for (int i = 1; i <= data.Length; i++)
            {
                // hex
                bytes += (data[i - 1].ToString("X2")) + " ";

                // ascii
                if (data[i - 1] < 0x21 || data[i - 1] > 0x7e)
                {
                    ascii += ".";
                }
                else
                {
                    ascii += Encoding.ASCII.GetString(new byte[1] { data[i - 1] });
                }

                //空格换行
                if (i % 16 != 0 && i % 8 == 0)
                {
                    bytes += " ";
                    ascii += " ";
                }

                //拼接字符串
                if (i % 16 == 0)
                {
                    // 构建每一行
                    buffer.AppendLine(i.ToString("X5") + "  " + bytes + "  " + ascii);

                    // 重置数据
                    bytes = "";
                    ascii = "";

                    continue;
                }

                // 构建最后一行
                if (i == data.Length)
                {
                    // build the line
                    buffer.AppendLine(i.ToString("X5") + "  " + bytes.PadRight(49, ' ') + "  " + ascii);
                }
            }

            return buffer.ToString();
        }

    }
}
