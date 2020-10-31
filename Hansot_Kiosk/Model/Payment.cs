using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class Payment
    {
        /// <summary>
        /// 유저 이름
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 메뉴 이름
        /// </summary>
        public String MenuName { get; set; }

        /// <summary>
        /// 음식 주문 갯수
        /// </summary>
        public int MenuCount { get; set; }
    }
}
