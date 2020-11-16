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

        private int _totalMoney;

        public int TotalMoney
        {
            get => _totalMoney;
            set => SetProperty(ref _totalMoney, value);
        }

        private string _qrCode;
        public string QrCode
        {
            get => _qrCode;
            set => SetProperty(ref _qrCode, value);
        }
    }
}
