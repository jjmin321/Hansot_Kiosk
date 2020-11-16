using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class Total
    {
        /// <summary>
        /// 총 판매 금액
        /// </summary>
        public int TotalMoney { get; set; }

        /// <summary>
        /// 할인된 금액
        /// </summary>
        public int DiscountedMoney { get; set; }

        /// <summary>
        /// 현금 주문 금액
        /// </summary>
        public int CashMoney { get; set; }

        /// <summary>
        /// 카드 주문 금액
        /// </summary>
        public int CardMoney { get; set; }
    }
}
