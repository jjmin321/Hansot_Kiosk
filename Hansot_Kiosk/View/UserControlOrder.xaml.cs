using Hansot_Kiosk.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIStateManagerLibrary;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlOrder : CustomControlModel
    {
        private int totalPrice = 0;

        private List<Food> calcaulation = new List<Food>()
        {

        };

        private List<Food> lstFood = new List<Food>()
        {
            new Food(){ category = Category.lunchBox, name = "불고기도시락", count=1 ,price=3000, imagePath = @"/Static/불고기도시락.jpg" },
            new Food(){ category = Category.lunchBox, name = "새우튀김도시락", price=4000, count=1, imagePath = @"/Static/새우튀김도시락.png" },
            new Food(){ category = Category.lunchBox, name = "세우튀김스테이크도시락", price=5000,count=1, imagePath = @"/Static/새우튀김스테이크도시락.png" },
            
            new Food(){ category = Category.RiceBowl, name = "참치마요덮밥", price=3500, count=1,imagePath = @"/Static/참치마요덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "참치비빔덮밥",count=1, price=3200,imagePath = @"/Static/참치비빔덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "치킨마요덮밥",count=1, price=3700, imagePath = @"/Static/치킨마요덮밥.jpg" },

            new Food(){ category = Category.juice, name = "콜라", price=1500, count=1,imagePath = @"/Static/콜라.jpg" },
            new Food(){ category = Category.juice, name = "사이다",price=1500, count=1,imagePath = @"/Static/칠성사이다.jpg" },
        };

        public UserControlOrder()
        {
            InitializeComponent();

            this.FontFamily = new System.Windows.Media.FontFamily("배달의민족 도현");
            this.Loaded += MainWindow_Loaded;
            this.listView.ItemsSource = calcaulation;
            tbTotalPrice.Text = totalPrice + "";
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbCategory.SelectedIndex = 0;
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbMenus.ItemsSource = lstFood.Where(x => x.category == category).ToList();
        }

        private void lbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food food = (Food)lbMenus.SelectedItem;
            if (food != null)
            {
                calcaulation.Add(food);
                int selectMenuPrice = 0;
                for (int i = 0; i < calcaulation.Count; i++)
                {
                    selectMenuPrice = calcaulation[i].price;//지금 가져온 메뉴
                    
                }
                int intTbTotalPrice = int.Parse(tbTotalPrice.Text);//원래 있던 메뉴
                tbTotalPrice.Text = intTbTotalPrice + selectMenuPrice + "";
                listView.Items.Refresh();
            }
        }
        private void plusThisMenu(object sender, RoutedEventArgs e)
        {
            
        }
        private void MinusThisMenu(object sender, RoutedEventArgs e)
        {

        }
        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void btnMoveToPlace(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            totalPrice = 0;
            calcaulation.Clear();
            listView.Items.Refresh();
        }
        
    }
}
    