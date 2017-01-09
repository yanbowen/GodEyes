using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GodEye
{
    class EmailAnalysis
    {
        ProcessingEmail pe;
        ProcessingEmailList<ProcessingEmail> peList = ProcessingEmailList<ProcessingEmail>.GetInstance();
        Regex rea = new Regex("=\\.\\.");

        public int Analysis(ProcessingAllData data)
        {
            
            string resulta = rea.Replace(data.Data, "");
            MatchCollection furtherM = Regex.Matches(data.Data, "From:.*To:");
            if (furtherM.Count != 0)
            {
                pe = new ProcessingEmail();
                //from
                MatchCollection mc2 = Regex.Matches(data.Data, "From:.*?\\.\\.");
                foreach (Match m in mc2)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    pe.FurtherSender = result;
                }

                //to
                MatchCollection mc3 = Regex.Matches(data.Data, "To:.*?\\.\\.");
                foreach (Match m in mc3)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    pe.FurtherReceiver = result;
                }

                //subject
                MatchCollection mc4 = Regex.Matches(data.Data, "Subject:.*?\\.\\.");
                foreach (Match m in mc4)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    pe.Subject = result;
                }

                //subject
                MatchCollection mc5 = Regex.Matches(data.Data, "NextPart.*?_");
                foreach (Match m in mc5)
                {
                    Regex re = new Regex("\\.\\.");
                    string result = re.Replace(m.ToString(), "");
                    Debug.WriteLine(result);
                    pe.FurtherNextPart = result;
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
                        pe.NowNextPart = m.ToString();
                        Debug.WriteLine(pe.NowNextPart + "**");
                        //nextPart相互匹配
                        if (pe.NowNextPart.Equals(pe.FurtherNextPart))
                        {
                            Debug.WriteLine("匹配成功");
                            pe.Time = data.Time;
                            pe.SenderIP = data.SourceAddress;
                            foreach (Match mm in mc1)
                            {
                                //Debug.WriteLine(m);
                                //Console.WriteLine(m);
                                Regex re = new Regex("=\\.\\.");
                                string result = re.Replace(mm.ToString(), "");
                                re = new Regex("=0A");
                                result = re.Replace(result, "");
                                Debug.WriteLine(result);
                                pe.Caption = result;
                            }
                            pe.Sender = pe.FurtherSender;
                            pe.Receiver = pe.FurtherReceiver;

                            lock (peList.SyncRoot)
                            {
                                peList.Add(pe);
                            }
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
