using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    class ProcessingQQLoginLogout
    {
        private string qqID;
        private string qqIP;
        private int qqLogin=0;
        private string time;

        public string QqID
        {
            get
            {
                return qqID;
            }

            set
            {
                qqID = value;
            }
        }

        public string QqIP
        {
            get
            {
                return qqIP;
            }

            set
            {
                qqIP = value;
            }
        }

        public int QqLogin
        {
            get
            {
                return qqLogin;
            }

            set
            {
                qqLogin = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public int Analysis(ProcessingAllData data)
        {
            this.QqID = (data.BinaryData[49] * 256 * 256 * 256 + data.BinaryData[50] * 256 * 256 +
                data.BinaryData[51] * 256 + data.BinaryData[52]).ToString();
            this.Time = data.Time;
            this.QqIP = data.SourceAddress;
            if (data.BinaryData[45] == (byte)(0x08) && data.BinaryData[46] == (byte)(0x25))
            {
                this.QqLogin = 1;
                return 1;
            }
            else if (data.BinaryData[45] == (byte)(0x00) && data.BinaryData[46] == (byte)(0x59))
            {
                this.QqLogin = 2;
                return 1;
            }
            return 0;
        }
    }
}
