using Hansot_Kiosk.Model;
using System;
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
    /// UserControlPayResult.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPayResult : CustomControlModel, INotifyPropertyChanged
    {   
        public string User;         

        public UserControlPayResult()
        {
            InitializeComponent();
            Loaded += UserControlPayResult_Loaded;
            OnPropertyChanged("");
        }

        private void UserControlPayResult_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.payViewModel;
        }

        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
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
