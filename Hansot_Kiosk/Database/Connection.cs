using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hansot_Kiosk.Database
{
    public class Connection
    {
        public static MySqlConnection connection = null;
        public void Connect()
        {
            string Attributes = Config.DBConfig.GetDBInfo();
            connection = new MySqlConnection(Attributes);
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
