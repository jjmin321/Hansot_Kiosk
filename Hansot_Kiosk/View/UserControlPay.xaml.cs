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
        int TotalPrice = 0;
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
            FoodData data = new FoodData();
            List<FoodData> foodData = new List<FoodData>();

            foodData.Add(new FoodData() { FoodCount = 2, FoodMoney = 3000, FoodName = "few" });
            foodData.Add(new FoodData() { FoodCount = 3, FoodMoney = 1500, FoodName = "dmatlr" });
            foodData.Add(new FoodData() { FoodCount = 2, FoodMoney = 1000, FoodName = "fwjeiofjwe" });

            FoodListView.ItemsSource = foodData;

            for(int i = 0; i < foodData.Count; i++)
            {
                TotalPrice += (foodData[i].FoodMoney * foodData[i].FoodCount);
            }

            Console.WriteLine(TotalPrice);
            TotalAmountView.Text = "총금액 : " + TotalPrice.ToString();
        }

        private void btnMoveToSelectTable(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.TABLE);
        }
    }

    public class FoodData
    {
        public string FoodName { get; set; }
        public int FoodCount { get; set; }
        public int FoodMoney { get; set; }
    }


}
