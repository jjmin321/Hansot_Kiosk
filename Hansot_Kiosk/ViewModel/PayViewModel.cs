﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.ViewModel
{
    public class PayViewModel : BindableBase
    {
        private string _qrCode;
        public string QrCode
        {
            get => _qrCode;
            set => SetProperty(ref _qrCode, value);
        }
    }
}
