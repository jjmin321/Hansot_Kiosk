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

namespace Hansot_Kiosk.View.ManagerView
{
    /// <summary>
    /// UserControlManager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlManager : CustomControlModel
    {

        Stopwatch stopwatch = new Stopwatch();

        public UserControlManager()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            header.Content = "asdf";
            header.Content = stopwatch.Elapsed;
        }


        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void btnMoveToCategory(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.CATEGORY);
        }

    }
}
