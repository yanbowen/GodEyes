using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace GodEye
{
    class LinkMySQL
    {
        public void test()
        {
            string constructorString = "server=localhost;UserId=root;password=123456;Database=QQ";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("select * from test", myConnnect);
            try
            {
                MySqlDataReader reader = myCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("编号:" + reader.GetString(0) + "|姓名:" + reader.GetInt32(1));
                        //Console.WriteLine("编号:" + reader.GetString(0) + "|姓名:" + reader.GetInt32(1));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
        
}
