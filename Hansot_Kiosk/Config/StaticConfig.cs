using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Config
{
    public class StaticConfig
    {
        private static string Commercial = "C:/Users/user/source/repos/Hansot_Kiosk/Hansot_Kiosk/Static/뜨끈한 한솥_ 1월 한달 내내 초특가 할인! '블랙한솥데이 '.mp4";
        private static string HomeImage = "C:/Users/user/source/repos/Hansot_Kiosk/Hansot_Kiosk/Static/Hansot.jpg"; 

        public static string GetCommercialRoute()
        {
            return Commercial;
        }

        public static string GetHomeImageRoute()
        {
            return HomeImage;
        }
    }
}
