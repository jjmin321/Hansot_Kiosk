using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Config
{
    class DBConfig
    {
        private static string _dbHost = "localhost";
        private static string _dbUser = "root";
        private static string _dbPw = "chlwlsdn";
        private static int _dbPort = 3306;
        private static string _dbName = "kiosk";
        public static string GetDBConnectionString()
        {
            return String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _dbHost, _dbPort, _dbName, _dbUser, _dbPw);
        }
    }
}