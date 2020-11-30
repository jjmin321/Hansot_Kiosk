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
    /// UserControlPlace.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPlace : CustomControlModel
    {
        public UserControlPlace()
        {
            InitializeComponent();
        }

        private void btnMoveToSelectTable(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.TABLE);
        }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }

        private void btnMoveToOrder(object sender, RoutedEventArgs e)
        {
            App.payViewModel.OrderCount = App.payViewModel.OrderCount - 1;
            App.uIStateManager.SwitchCustomControl(CustomControlType.ORDER);
        }
    }
}
