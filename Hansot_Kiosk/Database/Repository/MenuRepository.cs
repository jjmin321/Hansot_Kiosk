using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Database.Repository
{
    static class MenuRepository
    {
        public static string FindAll = "SELECT idx, category, name, price, image FROM menu;";
    }
}
