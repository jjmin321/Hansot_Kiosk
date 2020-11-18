using Hansot_Kiosk.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Hansot_Kiosk.Enum;
using System;
using System.ComponentModel;
using System.Collections.Generic;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UIStateManagerLibrary;
using System.Threading;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        TCPNet tcpnet = new TCPNet();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            KeyDown += new KeyEventHandler(Window_KeyDown);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            OnPropertyChanged("");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetCustomControls();
            SetStartCustomControl();
            tcpnet.SetUser("2116");
            tcpnet.Login();
            tcpnet.SendMessage("안녕하십니까");
        }

        private void SetCustomControls()
        {
            App.uIStateManager.SetCustomCtrl(ucLogin, CustomControlType.LOGIN);
            App.uIStateManager.SetCustomCtrl(ucHome, CustomControlType.HOME);
            App.uIStateManager.SetCustomCtrl(ucOrder, CustomControlType.ORDER);
            App.uIStateManager.SetCustomCtrl(ucPay, CustomControlType.PAY);
            App.uIStateManager.SetCustomCtrl(ucPlace, CustomControlType.PLACE);
            App.uIStateManager.SetCustomCtrl(ucSelectTable, CustomControlType.TABLE);
            App.uIStateManager.SetCustomCtrl(ucPayByMoney, CustomControlType.PAYBYMONEY);
            App.uIStateManager.SetCustomCtrl(ucPayByQR, CustomControlType.PAYBYQR);
            App.uIStateManager.SetCustomCtrl(ucPayResult, CustomControlType.PAYRESULT);
            App.uIStateManager.SetCustomCtrl(ucManager, CustomControlType.MANAGER);
            App.uIStateManager.SetCustomCtrl(ucCategory, CustomControlType.CATEGORY);
        }

        private void SetStartCustomControl()
        {
            if (App.userViewModel.Auto == 1)
            {
                App.uIStateManager.PushCustomCtrl(ucHome);
                MessageBox.Show("자동 로그인 되었습니다!");
            }
            else
            {
                App.uIStateManager.PushCustomCtrl(ucLogin);
            }
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2 && App.uIStateManager.customCtrlStack.Count > 0 && App.uIStateManager.customCtrlStack.Peek() == ucHome)
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.MANAGER);
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