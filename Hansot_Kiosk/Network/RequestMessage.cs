using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hansot_Kiosk.Enum;

namespace Hansot_Kiosk.Network
{
    public class RequestMessage
    {
        public MessageType MSGType { get; set; }
        public string Id { get; set; }
        public string Content { get; set; }
        public string ShopName { get; set; }
        public string OrderNumber { get; set; }
        public List<Menu> Menus { get; set; }

        public class Menu
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
        }
    }
}
