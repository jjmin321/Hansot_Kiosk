using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hansot_Kiosk.Database.Repository;
using MySql.Data.MySqlClient;

namespace Hansot_Kiosk.Database.Repository
{
    public class ManageRepository
    {
        Connection connection = new Connection();
        string SelectTotalTime = "SELECT total_time FROM total";
        string UpdateTotalTime;

        public void GetTotalTime()
        {
            connection.Connect();
            MySqlCommand cmd = new MySqlCommand(SelectTotalTime, Connection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                View.ManagerView.UserControlManager.dbTime = int.Parse(reader["total_time"].ToString());
            }
        }

        public void SetTotalTime()
        {
            View.ManagerView.UserControlManager.CurTime = View.ManagerView.UserControlManager.dbTime.ToString();
            UpdateTotalTime = "Update total SET total_time = " + View.ManagerView.UserControlManager.CurTime;
            connection.Connect();
            MySqlCommand cmd = new MySqlCommand(UpdateTotalTime, Connection.connection);
            if (cmd.ExecuteNonQuery() == 1)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
