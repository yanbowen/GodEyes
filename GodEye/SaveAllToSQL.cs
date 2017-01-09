using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GodEye
{
    class SaveAllToSQL
    {

        MySqlConnection myConnect = null;

        Regex re1 = new Regex("'");
        Regex re2 = new Regex(" ");
        Regex re3 = new Regex("-");

        public MySqlConnection MyConnect
        {
            get
            {
                return myConnect;
            }

            set
            {
                myConnect = value;
            }
        }

        public SaveAllToSQL()
        {
            SetConnect();
        }

        private void SetConnect()
        {
            string constructorString = "server=10.10.4.151;UserId=root;password=123456;Database=godeye;Charset=utf8";
            MyConnect = new MySqlConnection(constructorString);
        }

        public void SaveAll(MySqlConnection myConnect,ProcessingAllData rowData)
        {
            myConnect.Open();

            string sql ="";

            MySqlCommand myCmd = null;
            
                ///
            sql = SetSQLString(rowData);
            Debug.WriteLine(sql);
            try
            {
                myCmd = new MySqlCommand(get_uft8(sql), myConnect);
                myCmd.ExecuteNonQuery();
            }
            finally
            {
                myConnect.Close();
            }
                 
 //MySqlCommand mycmd = new MySqlCommand("insert into buyer(name,password,email) values('小王','dikd3939','1134384387@qq.com')", mycon);
        }

        public void SaveAll(MySqlConnection myConnect,ProcessingEmail rowData)
        {
            myConnect.Open();

            string sql = "";

            MySqlCommand myCmd = null;

            ///
            sql = SetSQLString(rowData);
            Debug.WriteLine(sql);
            try
            {
                myCmd = new MySqlCommand(get_uft8(sql), myConnect);
                myCmd.ExecuteNonQuery();
            }
            finally
            {
                myConnect.Close();
            }

            //MySqlCommand mycmd = new MySqlCommand("insert into buyer(name,password,email) values('小王','dikd3939','1134384387@qq.com')", mycon);
        }

        public void SaveAll(MySqlConnection myConnect, ProcessingQQLoginLogout rowData)
        {
            myConnect.Open();

            string sql = "";

            MySqlCommand myCmd = null;

            ///
            sql = SetSQLString(rowData);
            Debug.WriteLine(sql);
            try
            {
                myCmd = new MySqlCommand(get_uft8(sql), myConnect);
                myCmd.ExecuteNonQuery();
            }
            finally
            {
                myConnect.Close();
            }

            //MySqlCommand mycmd = new MySqlCommand("insert into buyer(name,password,email) values('小王','dikd3939','1134384387@qq.com')", mycon);
        }

        public void SaveAll(MySqlConnection myConnect, ProcessingBehave rowData)
        {
            myConnect.Open();

            string sql = "";

            MySqlCommand myCmd = null;

            ///
            sql = SetSQLString(rowData);
            Debug.WriteLine(sql);
            try
            {
                myCmd = new MySqlCommand(get_uft8(sql), myConnect);
                myCmd.ExecuteNonQuery();
            }
            finally
            {
                myConnect.Close();
            }

            //MySqlCommand mycmd = new MySqlCommand("insert into buyer(name,password,email) values('小王','dikd3939','1134384387@qq.com')", mycon);
        }

        private string SetSQLString(ProcessingAllData p)
        {
            string id;
            string data_id;
            string protocol;
            string length;
            string sourceAddress;
            string destinationAddress;
            string time;
            string data;
            id = p.Id;
            data_id = p.Id;
            protocol = p.Protocol;
            length = p.Length;
            sourceAddress = re2.Replace(p.SourceAddress,"");
            destinationAddress = re2.Replace(p.DestinationAddress, ""); 
            time = re2.Replace(p.Time, "");
            data = re1.Replace(p.Data,"''");
            time = re3.Replace(time, "");
            //time = "1";
            //protocol = "1";
            //sourceAddress = "1";
            //destinationAddress = "1";
            //protocol = "tcp";
            //time = "1";
            //data = "123456";
            return "insert into all_info(data_id,protocol,length,sourceAddress,destinationAddress,time,data) values('" + data_id + "','" + protocol + "','" + length + "','" + sourceAddress + "','" + destinationAddress + "','" + time + "','" + data + "')";
            //re.Replace(m.ToString(), "");
        }

        private string SetSQLString(ProcessingEmail pe)
        {
            string sender;
            string receiver;
            string senderIP;
            string caption;
            string time;
            string subject;
            sender = pe.Sender;
            receiver = pe.Receiver;
            senderIP = pe.SenderIP;
            caption = pe.Caption;
            time = pe.Time;
            subject = pe.Subject;

            return "insert into email_info values('"+sender+"','"+receiver+"','"+senderIP+"','"+caption+"','"+time+"')";
        }

        private string SetSQLString(ProcessingQQLoginLogout qq)
        {
            string qqnum;
            string IP;
            string logn_out;
            string time;
            qqnum = qq.QqID;
            IP = qq.QqID;
            if (qq.QqLogin == 1)
            {
                logn_out = "上线";
            }
            else
            {
                logn_out = "下线";
            }
            time = qq.Time;
            return "insert into qq_info(qqnum,qqIP,qqLogin,time) values('" + qqnum + "','" + IP + "','" + logn_out + "','" + time + "')";
        }

        private string SetSQLString(ProcessingBehave pb)
        {
            string senderIP;
            string receiverIP;
            string reason;
            string detailReason;
            string time;

            senderIP = pb.UserIPA;
            receiverIP = pb.UserIPB;
            reason = pb.Reason;
            detailReason = pb.DetailReason;
            time = pb.Time;
            return "insert into behave_info values('"+senderIP+"','"+receiverIP+"','"+reason+"','"+detailReason+"','"+time+"')";
        }

        public static string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }
    }
}
