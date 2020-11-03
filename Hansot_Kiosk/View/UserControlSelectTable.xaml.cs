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
        Color basicColor = Color.FromRgb(141, 110, 99);
        Color isChooseColor = Color.FromRgb(229, 57, 53);
        Button beforeButton;
        Button CurButton;
        DispatcherTimer _timer;
        public UserControlSelectTable()
        {
            InitializeComponent();
        }

        private void TableClick(object sender, RoutedEventArgs e)
        {
            /*if (CurButton == null)
            {
                CurButton = (Button)sender;
                CurButton.Background = new SolidColorBrush(selectTableColor);
            }
            else
            {
                beforeButton = CurButton;
                CurButton = (Button)sender; 

                beforeButton.Background = new SolidColorBrush(basicColor);
                CurButton.Background = new SolidColorBrush(selectTableColor);
            }*/
            CountDown((Button)sender);
        }

        void CountDown(Button button)
        {
            string inputMinute;
            string inputSecond;
            TimeSpan _time;
            button.Background = new SolidColorBrush(isChooseColor);
            _time = TimeSpan.FromSeconds(300);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                inputMinute = _time.ToString("mm");
                inputSecond = _time.ToString("ss");
                button.Content = inputMinute + "분 " + inputSecond + "초";
                if (_time == TimeSpan.Zero)
                {
                    Console.WriteLine("0");
                    button.Content = button.Name;
                    button.Background = new SolidColorBrush(basicColor);
                    _timer.Stop();

                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }
    }
}

