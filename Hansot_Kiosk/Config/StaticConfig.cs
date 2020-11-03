using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Config
{
    class StaticConfig
    {
        private static string Commercial = "C:/Users/user/Documents/GitHub/Hansot_Kiosk-1/Hansot_Kiosk/Static/뜨끈한 한솥_ 1월 한달 내내 초특가 할인! '블랙한솥데이 '.mp4";

        public static string GetCommercialRoute()
        {
            return Commercial;
        }
    }
}
