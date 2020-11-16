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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UIStateManagerLibrary;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetCustomControls();
            SetStartCustomControl();
        }

        private void SetCustomControls()
        {
            App.uIStateManager.SetCustomCtrl(ucHome, CustomControlType.HOME);
            App.uIStateManager.SetCustomCtrl(ucOrder, CustomControlType.ORDER);
            App.uIStateManager.SetCustomCtrl(ucPay, CustomControlType.PAY);
            App.uIStateManager.SetCustomCtrl(ucPlace, CustomControlType.PLACE);
            App.uIStateManager.SetCustomCtrl(ucSelectTable, CustomControlType.TABLE);
            App.uIStateManager.SetCustomCtrl(ucPayByMoney, CustomControlType.PAYBYMONEY);
            App.uIStateManager.SetCustomCtrl(ucPayByQR, CustomControlType.PAYBYQR);
            App.uIStateManager.SetCustomCtrl(ucPayResult, CustomControlType.PAYRESULT);
        }

        private void SetStartCustomControl()
        {
            App.uIStateManager.PushCustomCtrl(ucHome);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            header.Content = DateTime.Now.ToString("yyyy년 MM월 dd일 dddd tt HH : mm : ss");
        }

        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
            if (UserControlSelectTable.CurButton != null) // 홈버튼 누를 경우 테이블 선택이 취소도니다.
            {
                UserControlSelectTable.CurButton.Background = new SolidColorBrush(ucSelectTable.basicColor);
                UserControlSelectTable.CurButton = null;
            }
        }
    }
}
