using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    class ProcessingBehave
    {
        private string userIPA;
        private string userIPB;
        private string reason;
        private string time;
        private string protocol;
        private string caption;

        public string UserIPA
        {
            get
            {
                return userIPA;
            }

            set
            {
                userIPA = value;
            }
        }

        public string UserIPB
        {
            get
            {
                return userIPB;
            }

            set
            {
                userIPB = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
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

        public string Protocol
        {
            get
            {
                return protocol;
            }

            set
            {
                protocol = value;
            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
            }
        }
    }
}
