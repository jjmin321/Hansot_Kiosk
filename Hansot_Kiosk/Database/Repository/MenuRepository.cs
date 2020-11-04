using System;
using Hansot_Kiosk.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Hansot_Kiosk.Database.Repository;

namespace Hansot_Kiosk.Database.Repository
{
    public class MenuRepository
    {
        Connection connection = new Connection();
        private string FindAllMenu = "SELECT idx, category, name, price, image FROM menu;";
        public List<Menu> GetMenus()
        {
            connection.Connect();
            MySqlCommand cmd = new MySqlCommand(FindAllMenu, Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Menu> menus = new List<Menu>();
            while (reader.Read())
            {
                Menu menu = new Menu()
                {
                    Idx = Convert.ToInt32(reader["idx"]),
                    Category = Convert.ToString(reader["category"]),
                    Name = Convert.ToString(reader["name"]),
                    Price = Convert.ToInt32(reader["price"]),
                    Image = Convert.ToString(reader["image"]),
                };

                menus.Add(menu);
            }
            connection.Close();
            return menus;
        }
    }
}
