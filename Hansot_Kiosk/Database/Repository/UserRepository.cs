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
        private int is_auto;
        private string name;
        private string barcode;

        public int GetIsAuto()
        {
            connection.Connect();
            string sql = "SELECT auto FROM login;";
            MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                is_auto = Convert.ToInt32(reader["auto"]);
            }
            connection.Close();
            return is_auto;
        }

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

        public void SetLogin(string name, string barcode)
        {
            connection.Connect();
            string sql = string.Format("UPDATE LOGIN SET auto = 1, name = '{0}', barcode = '{1}' WHERE auto = 0", name, barcode);
            MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
