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
    /// UserControlPay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPay : CustomControlModel
    {
        public static List<Model.Menu> FoodData = new List<Model.Menu>();
        public UserControlPay()
        {
            InitializeComponent();
            ShowTotalPrice();
        }

        private void btnMoveToPlace(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }

        private void btnMoveToPayByMoney(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAYBYMONEY);
        }

        private void btnMoveToPayByQR(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAYBYQR);
        }

        private void ShowTotalPrice()
        {
            FoodListView.ItemsSource = FoodData;
            Database.Repository.ManageRepository manageRepository = new Database.Repository.ManageRepository();
            manageRepository.GetTotalTime();
            this.DataContext = App.payViewModel;
        }

        private void btnMoveToSelectTable(object sender, RoutedEventArgs e)
        {            
            App.uIStateManager.SwitchCustomControl(CustomControlType.TABLE);
        }
    }

}
