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
            //담겨지는 리스트
        };

        private List<Food> seeList = new List<Food>()
        {
            //메뉴 정보가 담겨져있는 리스트
        };

        private List<Food> lstFood = new List<Food>()
        {
            new Food(){ category = Category.lunchBox, name = "불고기도시락", count=0 ,price=3000, imagePath = @"/Static/불고기도시락.jpg" },
            new Food(){ category = Category.lunchBox, name = "새우튀김도시락", price=4000, count=0, imagePath = @"/Static/새우튀김도시락.png" },
            new Food(){ category = Category.lunchBox, name = "세우튀김스테이크도시락", price=5000,count=0, imagePath = @"/Static/새우튀김스테이크도시락.png" },

            new Food(){ category = Category.RiceBowl, name = "참치마요덮밥", price=3500, count=0,imagePath = @"/Static/참치마요덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "참치비빔덮밥",count=0, price=3200,imagePath = @"/Static/참치비빔덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "치킨마요덮밥",count=0, price=3700, imagePath = @"/Static/치킨마요덮밥.jpg" },
            new Food(){ category = Category.juice, name = "콜라", price=1500, count=0,imagePath = @"/Static/콜라.jpg" },
            new Food(){ category = Category.juice, name = "사이다",price=1500, count=0,imagePath = @"/Static/칠성사이다.jpg" },
        };
        public UserControlOrder()
        {
            InitializeComponent();
            this.FontFamily = new System.Windows.Media.FontFamily("배달의민족 도현");
            this.Loaded += MainWindow_Loaded;
            this.listView.ItemsSource = calcaulation; // listView 담겨지는 calcaulation 담겨지는 리스트 

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
            int flag = 0; // 이미 그 메뉴가 있으면 더이상 추가 안되게 
            if (food != null)
            {
                for (int i = 0; i< calcaulation.Count; i++)
                {
                    if(food.name == calcaulation[i].name)
                    {
                        calcaulation[i].count++;
                        flag = 1;
                        break;
                    }
                }
            
                if (flag == 0)
                {
                    calcaulation.Add(food);
                    for (int i = 0; i < calcaulation.Count; i++)
                    {
                        if (food.name == calcaulation[i].name)
                        {
                            calcaulation[i].count++;
                        }
                    }
                }
            }
            calculationPrice();
            listView.Items.Refresh();
        }
        private void plusMinusThisMenu(object sender, RoutedEventArgs e)
        {
            var name = (sender as System.Windows.Controls.Button).Name;
            var food = ((System.Windows.Controls.ListViewItem)listView.ContainerFromElement(sender as System.Windows.Controls.Button)).Content as Food;
            if (name == "plus")
            {
                for (int i = 0; i < calcaulation.Count; i++)
                {
                    if (food.name == calcaulation[i].name)
                    {
                        calcaulation[i].count++;
                        calculationPrice();
                    }
                }
            }
            else
            {
                for(int i = 0; i < calcaulation.Count; i++)
                {
                    if (food.name == calcaulation[i].name)
                    {
                        if (food.count == 1)
                        {
                            calcaulation[i].count = 0;
                            calculationPrice();
                            calcaulation.Remove(food);
                            listView.Items.Refresh();
                        }
                        else
                        {
                            calcaulation[i].count--;
                            calculationPrice();
                        }
                    }
                }
            }
            listView.Items.Refresh();
        }
        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }
        private void btnMoveToPlace(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }
        private void calculationPrice()
        {
            totalPrice = 0;
            for (int i = 0; i < calcaulation.Count; i++)
            {
                    totalPrice += calcaulation[i].price * calcaulation[i].count;
            }
            tbTotalPrice.Text = totalPrice + "";
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var food = ((System.Windows.Controls.ListViewItem)listView.ContainerFromElement(sender as System.Windows.Controls.Button)).Content as Food;
            food.count = 0;
            calcaulation.Remove(food);
            listView.Items.Refresh();
        }
        private void RemoveAll(object sender, RoutedEventArgs e)
        {
            if(System.Windows.MessageBox.Show("선택한 메뉴를 모두 삭제하시겠습니까?", "안내", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < calcaulation.Count; i++)
                {
                    calcaulation[i].count = 0;
                }
                calcaulation.Clear();
                totalPrice = 0;
                
                calculationPrice();
                listView.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("취소되었습니다, 안내");
            }
        }
    }
}
