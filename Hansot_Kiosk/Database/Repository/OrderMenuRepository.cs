using Hansot_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Hansot_Kiosk.Database.Repository
{
    
    public class OrderMenuRepository
    {


    Connection connection = new Connection();

        private int idx = 1;
        public int GetIdx()
        {
            connection.Connect();
            string sql = "SELECT idx FROM payment;";
            MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["idx"]) > idx)
                {
                    idx = Convert.ToInt32(reader["idx"]);
                }
            }
            idx++;
            App.payViewModel.OrderCount = idx;
            return idx;
        }

        public void InsertMneu(List<Menu> OrderMenu, int userIdx)
        {
            string name = App.payViewModel.QrCode;
            connection.Connect();
            
            for (int i = 0; i < OrderMenu.Count; i++)
            {
                string sql = string.Format("INSERT into payment( idx, user_name, menu_name, menu_count) VALUES({0},'{1}','{2}',{3});",userIdx,name,OrderMenu[i].name,OrderMenu[i].count );
                MySqlCommand cmd = new MySqlCommand(sql, Connection.connection);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }


}
