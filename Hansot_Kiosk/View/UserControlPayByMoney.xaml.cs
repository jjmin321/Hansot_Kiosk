using System;
using Hansot_Kiosk.Database.Repository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIStateManagerLibrary;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// UserControlPayByMoney.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPayByMoney : CustomControlModel, INotifyPropertyChanged
    {
        UserRepository userRepository = new UserRepository();
        public string userBarcode = string.Empty;
        public UserControlPayByMoney()
        {
            InitializeComponent();
            this.Loaded += UserControlPayByMoney_Loaded;
            OnPropertyChanged("");
            tbBarcode.Focus();
        }

        private void UserControlPayByMoney_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.payViewModel;
        }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }

        private void tbBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            userBarcode = tbBarcode.Text.ToString();
            if (userBarcode == "9790260532113" || userBarcode == "2112345678900" 
                || userBarcode == "02345673")
            {
                string userName = userRepository.GetUserNameByBarcode(userBarcode);
                MessageBox.Show("결제 완료되었습니다.");
                App.payViewModel.Name = userName;
                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYRESULT);
            }
        }
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
