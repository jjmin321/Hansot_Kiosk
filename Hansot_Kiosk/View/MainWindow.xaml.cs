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

namespace Hansot_Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            header.Content = DateTime.Now.ToString("yyyy년 MM월 dd일 dddd tt HH : mm : ss");
        }

        public void MoveToOrder()
        {
            ucHome.Visibility = Visibility.Collapsed;
            ucOrder.Visibility = Visibility.Visible;
        }

        public void MoveToHome()
        {
            ucOrder.Visibility = Visibility.Collapsed;
            ucHome.Visibility = Visibility.Visible;
        }
    }
}
