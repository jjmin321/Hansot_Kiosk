using System;
using Hansot_Kiosk.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Hansot_Kiosk.Database.Repository;
using Ubiety.Dns.Core.Records;

namespace Hansot_Kiosk.Database.Repository
{
    public class MenuRepository
    {
        Connection connection = new Connection();
        private string FindAllMenu = "SELECT * FROM menu;";
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
                    idx = Convert.ToInt32(reader["idx"]),
                    name = Convert.ToString(reader["name"]),
                    price = Convert.ToInt32(reader["price"]),
                    image =  Convert.ToString(reader["image"]),
                };
                String category = Convert.ToString(reader["category"]);

                if (category.Equals("lunchBox"))
                {
                    menu.category = View.Category.lunchBox;
                }
                else if (category.Equals("RiceBowl"))
                {
                    menu.category = View.Category.RiceBowl;
                } else
                {
                    menu.category = View.Category.juice;
                }

                menus.Add(menu);
            }
            connection.Close();
            return menus;
        }
    }
}
