using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Config
{
    public class DBConfig
    {
        private static string _dbHost = "127.0.0.1"; //10.80.163.232
        private static string _dbUser = "root";
        private static string _dbPw = "qwerz123";
        private static int _dbPort = 3306;
        private static string _dbName = "hansot";

        public static string GetDBInfo()
        {
            string Attributes = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _dbHost, _dbPort, _dbName, _dbUser, _dbPw);
            return Attributes;
        }
    }
}