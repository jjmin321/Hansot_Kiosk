using System;
using System.Collections.Generic;
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
    public partial class UserControlPayByQR : CustomControlModel
    {
        public UserControlPayByQR()
        {
            InitializeComponent();
            webcam.CameraIndex = 0;
        }

        private void webcam_QrDecoded(object sender, string e) { tbRecog.Text = e; }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }
    }
}
