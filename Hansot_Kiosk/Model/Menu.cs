using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class Menu
    {
        /// <summary>
        /// 카테고리명
        /// </summary>
        public String Category { get; set; }

        /// <summary>
        /// 음식 이름
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 음식 가격
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 음식 이미지 경로
        /// </summary>
        public String ImagePath { get; set; }
    }
}
