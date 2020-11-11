using Hansot_Kiosk.Network;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Hansot_Kiosk.Enum;
using UIStateManagerLibrary;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// UserControlHome.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlHome : CustomControlModel
    {
        TCPNet tcpnet = new TCPNet();
        public UserControlHome()
        {
            InitializeComponent();
            tcpnet.StartClient();
            RequestMessage requestJson = new RequestMessage();

            requestJson.MSGType = (MessageType)0;
            requestJson.Id = "2116";
            requestJson.Content = "";
            requestJson.ShopName = "";
            requestJson.OrderNumber = "";
            requestJson.Menus = null;

            string json = JsonConvert.SerializeObject(requestJson);
            tcpnet.Send(json);
            tcpnet.waitForReceive();
        }

        private void HansotVideoEnded(object sender, RoutedEventArgs e)
        {
            this.HansotVideo.Stop();
            this.HansotVideo.Position = TimeSpan.FromSeconds(0);
            this.HansotVideo.Play();
        }
        private void btnMoveToOrder(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.ORDER);
        }

        private void btnMoveToManager(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.MANAGER);
        }
    }
}
