using System;
using System.Collections;
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
        private string detailReason;
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

        public string DetailReason
        {
            get
            {
                return detailReason;
            }

            set
            {
                detailReason = value;
            }
        }

        public string Analysis(ProcessingAllData data, Hashtable ht, ProcessingBehaveList<ProcessingBehave> pbList)
        {
            String keys = "key";
            foreach (String key in ht.Keys)
            {

                if (data.Data.Contains(key) || data.Data.Contains(key))
                {
                    this.UserIPA = data.SourceAddress;
                    this.UserIPB = data.DestinationAddress;
                    this.time = data.Time;
                    this.protocol = data.HardwareType;
                    this.reason = (String)ht[key];
                    lock (pbList.SyncRoot)
                    {
                        pbList.Add(this);
                    }

                    keys = key;
                }

            }

            return keys;
        }
    }
}
