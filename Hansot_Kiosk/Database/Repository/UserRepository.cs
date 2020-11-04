using Hansot_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Hansot_Kiosk.Database.Repository
{ 
    public class UserRepository
    {
        Connection connection = new Connection();
        private string name;
        private string barcode;
        public string GetUserName(string id, string pw)
        {
            connection.Connect();
            string sql = string.Format("SELECT name FROM user WHERE ID = '{0}' AND PW = '{1}';", id, pw);
            MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            MySqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                name = Convert.ToString(reader["name"]);
            }
            connection.Close();
            return name;
        }

        public string GetUserBarcode(string id, string pw)
        {
            connection.Connect();
            string sql = string.Format("SELECT barcode FROM user WHERE ID = '{0}' AND PW = '{1}';", id, pw);
            MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                barcode = Convert.ToString(reader["barcode"]);
            }
            connection.Close();
            return barcode;
        }
    }
}
