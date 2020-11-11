using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class Menu
    {
        public int idx { get; set; }

        /// <summary>
        /// 카테고리명
        /// </summary>
        /// 
        public View.Category category { get; set; }

        /// <summary>
        /// 음식 이름
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 음식 가격
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// 음식 이미지 경로
        /// </summary>
        public String image { get; set; }

        /// <summary>
        /// 음식 이미지 경로
        /// </summary>
        public int count { get; set; }
    }
}
