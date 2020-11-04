using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class User
    {
        /// <summary>
        /// 유저 이름
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 유저 바코드 번호
        /// </summary>
        public String Barcode { get; set; }
    }
}
