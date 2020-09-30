using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hansot_Kiosk.Database
{
    public class Select
    {
        public List<object> id = new List<object>();
        public List<object> SelectAll()
        {
            string sql = "select * from test";
            MySqlCommand cmd = new MySqlCommand(sql, Database.Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id.Add(reader["id"]);
            }
            return id;
        }
    }
}
