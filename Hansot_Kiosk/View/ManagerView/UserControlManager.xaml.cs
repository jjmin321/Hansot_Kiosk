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
using System.Diagnostics;
using System.Windows.Threading;

namespace Hansot_Kiosk.View.ManagerView
{
    /// <summary>
    /// UserControlManager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlManager : CustomControlModel
    {
        public static string CurTime;
        public static int dbTime = 0;
        string TimeString;
        DispatcherTimer myTimer = new DispatcherTimer();
        Database.Repository.ManageRepository ManageRepository = new Database.Repository.ManageRepository();
        public UserControlManager()
        {
            InitializeComponent();
            TimerSetting();
            ManageRepository.GetTotalTime();
        }

        void TimerSetting()
        {
            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += MyClock_Tick;
            myTimer.Start();
        }

        void MyClock_Tick(object sender, EventArgs e)
        {
            dbTime++;
            CalculateTime(dbTime);
            header.Content = TimeString;
        }

        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void btnMoveToCategory(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.CATEGORY);
        }

        void CalculateTime(int Time)
        {
            int Hour = 0, Minute = 0, Second = 0;

            if (Time >= 3600)
            {
                while (Time >= 3600)
                {
                    Time -= 3600;
                    Hour++;
                }
            }
            if (Time >= 60)
            {
                while (Time >= 60)
                {
                    Time -= 60;
                    Minute++;
                }
            }
            while (Time != 0)
            {
                Time -= 1;
                Second++;
            }
            if (Minute >= 10)
                header.FontSize = 16;
            Console.WriteLine(Hour + " " + Minute + " " + Second);
            TimeString = string.Format("{0}시간 {1}분 {2}초", Hour, Minute, Second);
        }
    }
}
