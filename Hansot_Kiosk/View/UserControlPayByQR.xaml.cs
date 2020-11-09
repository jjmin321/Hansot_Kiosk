using Hansot_Kiosk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// UserControlPayByQR.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPayByQR : CustomControlModel, INotifyPropertyChanged
    {
        public UserControlPayByQR()
        {
            InitializeComponent();
            webcam.CameraIndex = 0;
            this.Loaded += MainWindow_Loaded;
            OnPropertyChanged("");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.payViewModel;
        }


        private void webcam_QrDecoded(object sender, string e)
        { 
            tbRecog.Text = e;
            App.payViewModel.QrCode = e;
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAYRESULT);
        }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
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
