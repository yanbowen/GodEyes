using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GodEye
{
    class ProcessingEmail
    {

        private string sender;
        private string receiver;
        private string senderIP;
        private string caption;
        private string time;


        private string furtherSender;
        private string furtherReceiver;
        private string furtherSubject;
        private string furtherNextPart;

        public string Sender
        {
            get
            {
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        public string Receiver
        {
            get
            {
                return receiver;
            }

            set
            {
                receiver = value;
            }
        }

        public string SenderIP
        {
            get
            {
                return senderIP;
            }

            set
            {
                senderIP = value;
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

        public void Analysis(ProcessingAllData data)
        {
            MatchCollection furtherM = Regex.Matches(data.Data, "From:.*To:");

            if(furtherM.Count!=0)
            {

                MatchCollection mc2 = Regex.Matches(data.Data, "From:.*\\.\\.");
                foreach (Match m in mc2)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    this.furtherSender = result;
                }

                MatchCollection mc3 = Regex.Matches(data.Data, "To:.*\\.\\.");
                foreach (Match m in mc3)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    this.furtherReceiver = result;
                }

                MatchCollection mc4 = Regex.Matches(data.Data, "Subject:.*\\.\\.");
                foreach (Match m in mc4)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    this.furtherReceiver = result;
                }
            }
           
            this.time = data.Time;
            //this.caption = data.Data;//
            MatchCollection mc1 = Regex.Matches(data.Data, "<html>.*html>");
            if (mc1.Count != 0)
            {
                this.senderIP = data.SourceAddress;
                foreach (Match m in mc1)
                {
                    //Debug.WriteLine(m);
                    //Console.WriteLine(m);
                    Regex re = new Regex("=\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    re = new Regex("=0A");
                    result = re.Replace(result, "");
                    Debug.WriteLine(result);
                    this.caption = result;
                }
                
            }
        }
    }
}
