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
using System.Windows.Threading;

namespace Hansot_Kiosk.View
{
    public partial class UserControlSelectTable : CustomControlModel
    {
        Color selectTableColor = Color.FromRgb(118, 255, 3);
        public Color basicColor = Color.FromRgb(141, 110, 99);
        static Color isChooseColor = Color.FromRgb(229, 57, 53);
        Button beforeButton;
        public static Button CurButton;
        public UserControlSelectTable()
        {
            InitializeComponent();
        }


        private void TableClick(object sender, RoutedEventArgs e)
        {
            if (CurButton == null)
            {
                CurButton = (Button)sender;
                if ((CurButton.Background as SolidColorBrush).Color == isChooseColor)
                {
                    CurButton.Background = new SolidColorBrush(isChooseColor);
                    CurButton = null;
                }
                else
                    CurButton.Background = new SolidColorBrush(selectTableColor);
            }
            else
            {
                beforeButton = CurButton;
                CurButton = (Button)sender;
                if ((CurButton.Background as SolidColorBrush).Color == isChooseColor)
                {
                    CurButton = null;
                    beforeButton.Background = new SolidColorBrush(basicColor);
                    beforeButton = null;
                }
                else
                {
                    beforeButton.Background = new SolidColorBrush(basicColor);
                    CurButton.Background = new SolidColorBrush(selectTableColor);
                }
            }
        }

        public void CountDown(Button button, string TableNum)
        {
            DispatcherTimer _timer = new DispatcherTimer();
            string selectTableNum = TableNum;
            string inputMinute;
            string inputSecond;
            TimeSpan _time;
            _time = TimeSpan.FromSeconds(60);
            CurButton = null;
            button.Background = new SolidColorBrush(isChooseColor);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                inputMinute = _time.ToString("mm");
                inputSecond = _time.ToString("ss");
                button.Content = inputMinute + "분 " + inputSecond + "초";
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    Console.WriteLine("0");
                    button.Content = selectTableNum;
                    button.Background = new SolidColorBrush(basicColor);
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        private void btnMoveToPlace(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
            if (CurButton != null) // 홈버튼 누를 시 선택한 테이블이 없어진다
            {
                CurButton.Background = new SolidColorBrush(basicColor);
                CurButton = null;
            }
        }

        private void btnMoveToPay(object sender, RoutedEventArgs e)
        {
            if (CurButton == null) // 선택한 테이블이 없는데 다음버튼을 누를 경우
            {
                MessageBox.Show("선택된 테이블이 없습니다.");
                return;
            }
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }
    }
}