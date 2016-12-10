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
        private bool qqLogin;
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

        public bool QqLogin
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

        public void Analysis(ProcessingAllData data)
        {

        }
    }
}
