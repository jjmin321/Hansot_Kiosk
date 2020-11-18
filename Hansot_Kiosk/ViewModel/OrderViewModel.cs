using Prism.Mvvm;
using System;
using Hansot_Kiosk.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.ViewModel
{
    public class OrderViewModel : BindableBase
    {
        public List<Menu> orderMenu = new List<Menu>{};

        public List<Menu> OrderMenu
        {
            get => orderMenu;
            set => SetProperty(ref orderMenu, value);
        }
    }
}