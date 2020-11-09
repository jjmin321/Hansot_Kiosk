using Hansot_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Hansot_Kiosk.Database.Repository;

namespace Hansot_Kiosk.Database.Dao
{
    public class MenuDao
    {
        public List<Menu> GetMenus()
        {
            MySqlCommand cmd = new MySqlCommand(MenuRepository.FindAll, Connection.connection);
            //ExecuteNonQuery() : insert, update, delete 사용시
            //ExecuteReader() :select 사용시
            //MySqlDataReader reader = cmd.ExecuteReader();
            List<Menu> menus = new List<Menu>();
            //while (reader.Read())
            //{
            //    Menu menu = new Menu()
            //    {
            //        Idx = Convert.ToInt32(reader["idx"]),
            //        Category = Convert.ToString(reader["category"]),
            //        Name = Convert.ToString(reader["name"]),
            //        Price = Convert.ToInt32(reader["price"]),
            //        Image = Convert.ToString(reader["image"]),
            //    };
             
            //    menus.Add(menu);
            //}
            return menus;
        }
    }
}
