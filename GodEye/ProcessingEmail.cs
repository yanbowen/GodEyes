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

        public int Analysis(ProcessingAllData data)
        {
            Regex rea = new Regex("=\\.\\.");
            string resulta = rea.Replace(data.Data, "");
            MatchCollection furtherM = Regex.Matches(data.Data, "From:.*To:");
            if (furtherM.Count != 0)
            {
                //pe = new ProcessingEmail();
                //from
                MatchCollection mc2 = Regex.Matches(data.Data, "From:.*?\\.\\.");
                foreach (Match m in mc2)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    FurtherSender = result;
                }

                //to
                MatchCollection mc3 = Regex.Matches(data.Data, "To:.*?\\.\\.");
                foreach (Match m in mc3)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    FurtherReceiver = result;
                }

                //subject
                MatchCollection mc4 = Regex.Matches(data.Data, "Subject:.*?\\.\\.");
                foreach (Match m in mc4)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    Subject = result;
                }

                //subject
                MatchCollection mc5 = Regex.Matches(data.Data, "NextPart.*?_");
                foreach (Match m in mc5)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    FurtherNextPart = result;
                }
                return 0;
            }

            else
            {

                //pe.caption = data.Data;//
                MatchCollection mc1 = Regex.Matches(resulta, "<html>.*</html>");
                if (mc1.Count != 0)
                {
                    Debug.WriteLine(mc1.Count);
                    MatchCollection mc6 = Regex.Matches(resulta, "NextPart.*?_");
                    foreach (Match m in mc6)
                    {
                        NowNextPart = m.ToString();
                        Debug.WriteLine(NowNextPart + "**");
                        //nextPart相互匹配
                        if (NowNextPart.Equals(FurtherNextPart))
                        {
                            Debug.WriteLine("匹配成功");
                           Time = data.Time;
                            SenderIP = data.SourceAddress;
                            foreach (Match mm in mc1)
                            {
                                //Debug.WriteLine(m);
                                //Console.WriteLine(m);
                                Regex re = new Regex("=\\.\\.");
                                string result = re.Replace(mm.ToString(), "");
                                re = new Regex("=0A");
                                result = re.Replace(result, "");
                                Debug.WriteLine(result);
                                Caption = result;
                            }
                            Sender = FurtherSender;
                            Receiver = FurtherReceiver;

                        }
                        //一个包中有三个NextPart出现
                        return 1;
                        //break;
                    }


                }
            }
            return 0;
        }
    }
}
