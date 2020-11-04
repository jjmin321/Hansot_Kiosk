using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.ViewModel
{
    public class UserViewModel : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _barcode;

        public string Barcode
        {
            get => _barcode;
            set => SetProperty(ref _barcode, value);
        }
    }
}
