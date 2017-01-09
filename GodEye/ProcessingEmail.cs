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

        private string nowNextPart;

        private string furtherSender;
        private string furtherReceiver;
        private string subject;
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

        public string NowNextPart
        {
            get
            {
                return nowNextPart;
            }

            set
            {
                nowNextPart = value;
            }
        }

        public string FurtherSender
        {
            get
            {
                return furtherSender;
            }

            set
            {
                furtherSender = value;
            }
        }

        public string FurtherReceiver
        {
            get
            {
                return furtherReceiver;
            }

            set
            {
                furtherReceiver = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public string FurtherNextPart
        {
            get
            {
                return furtherNextPart;
            }

            set
            {
                furtherNextPart = value;
            }
        }

        //public void Analysis(ProcessingAllData data)
        //{
        //    Regex rea = new Regex("=\\.\\.");
        //    string resulta = rea.Replace(data.Data, "");

        //    ProcessingEmailList<ProcessingEmail> peList = ProcessingEmailList<ProcessingEmail>.GetInstance();
        //    MatchCollection furtherM = Regex.Matches(data.Data, "From:.*To:");
        //    if(furtherM.Count!=0)
        //    {
        //        ProcessingEmail pea = new ProcessingEmail();
        //        //from
        //        MatchCollection mc2 = Regex.Matches(data.Data, "From:.*?\\.\\.");
        //        foreach (Match m in mc2)
        //        {
        //            Regex re = new Regex("\\.\\.");
        //            string result = re.Replace(m.ToString(), "");
        //            Debug.WriteLine(result);
        //            this.FurtherSender = result;
        //        }

        //        //to
        //        MatchCollection mc3 = Regex.Matches(data.Data, "To:.*?\\.\\.");
        //        foreach (Match m in mc3)
        //        {
        //            Regex re = new Regex("\\.\\.");
        //            string result = re.Replace(m.ToString(), "");
        //            Debug.WriteLine(result);
        //            this.FurtherReceiver = result;
        //        }

        //        //subject
        //        MatchCollection mc4 = Regex.Matches(data.Data, "Subject:.*?\\.\\.");
        //        foreach (Match m in mc4)
        //        {
        //            Regex re = new Regex("\\.\\.");
        //            string result = re.Replace(m.ToString(), "");
        //            Debug.WriteLine(result);
        //            this.FurtherSubject = result;
        //        }
                 
        //        //subject
        //        MatchCollection mc5 = Regex.Matches(data.Data, "NextPart.*?_");
        //        foreach (Match m in mc5)
        //        {
        //            Regex re = new Regex("\\.\\.");
        //            string result = re.Replace(m.ToString(), "");
        //            Debug.WriteLine(result);
        //            this.FurtherNextPart = result;
        //        }
                
        //    }
           
        //    else
        //    {
                
        //        //this.caption = data.Data;//
        //        MatchCollection mc1 = Regex.Matches(resulta, "<html>.*</html>");
        //        if (mc1.Count != 0)
        //        {
        //            Debug.WriteLine(mc1.Count);
        //            MatchCollection mc6 = Regex.Matches(resulta, "NextPart.*?_");
        //            foreach (Match m in mc6)
        //            {
        //                NowNextPart = m.ToString();
        //                Debug.WriteLine(NowNextPart+"**");
        //                //nextPart相互匹配
        //                if (NowNextPart.Equals(FurtherNextPart))
        //                {
        //                    Debug.WriteLine("匹配成功");
        //                    this.time = data.Time;
        //                    this.senderIP = data.SourceAddress;
        //                    foreach (Match mm in mc1)
        //                    {
        //                        //Debug.WriteLine(m);
        //                        //Console.WriteLine(m);
        //                        Regex re = new Regex("=\\.\\.");
        //                        string result = re.Replace(mm.ToString(), "");
        //                        re = new Regex("=0A");
        //                        result = re.Replace(result, "");
        //                        Debug.WriteLine(result);
        //                        this.caption = result;
        //                    }
        //                    this.sender = FurtherSender;
        //                    this.receiver = FurtherReceiver;

        //                    lock(peList.SyncRoot)
        //                    {
        //                        peList.Add(this);
        //                    }
        //                }
        //                //一个包中有三个NextPart出现
        //                break;
        //            }
                    

        //        }
        //    }
            
        //}
    }
}
