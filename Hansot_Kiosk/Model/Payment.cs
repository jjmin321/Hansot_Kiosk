using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansot_Kiosk.Model
{
    public class Payment : INotifyPropertyChanged
    {
        /// <summary>
        /// 유저 이름
        /// </summary>
        private String _userName;
        public String UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        /// <summary>
        /// 메뉴 이름
        /// </summary>
        public static String MenuName { get; set; }

        /// <summary>
        /// 음식 주문 갯수
        /// </summary>
        public static int MenuCount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
