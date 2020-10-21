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
    /// UserControlPayByMoney.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPayByMoney : CustomControlModel
    {
        public UserControlPayByMoney()
        {
            InitializeComponent();
            double totalMoney = 15236236236236;
            tbTotalMoney.Text = "총 금액: " + String.Format("{0:#,0}", totalMoney) + "원";
        }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }
    }
}
