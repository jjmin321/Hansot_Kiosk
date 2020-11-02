using Hansot_Kiosk.Database;
using Hansot_Kiosk.Database.Dao;
using Hansot_Kiosk.Model;
using Hansot_Kiosk.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UIStateManagerLibrary;

namespace Hansot_Kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static UIStateManager uIStateManager = new UIStateManager();

        public static List<Menu> Menus = new List<Menu>();

        private MenuDao menuDao = new MenuDao();

        public static List<Total> Totals = new List<Total>();

        public static List<Payment> Payments = new List<Payment>();

        public static PayViewModel payViewModel = new PayViewModel();

        public App()
        {
            Database.Connection.Connect();
            Menus = menuDao.GetMenus();
        }

        DateTime StartTime = DateTime.Now;

        // WPF 전역 예외처리, 어플리케이션 강제 종료 방지
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occured: " + e.Exception, "예외 발생", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DateTime ExitTime = DateTime.Now;
            String RunTime = (ExitTime - StartTime).ToString("h'시간 'm'분 's'초'");

            MessageBox.Show("프로그램 구동 시간: " + RunTime);
        }
    }
}
