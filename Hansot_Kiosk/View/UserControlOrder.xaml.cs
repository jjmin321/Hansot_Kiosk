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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// Order.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlOrder : UserControl
    {
        private List<Food> lstFood = new List<Food>()
        {
            new Food(){ category = Category.lunchBox, name = "불고기도시락", imagePath = @"/Static/불고기도시락.jpg" },
            new Food(){ category = Category.lunchBox, name = "새우튀김도시락", imagePath = @"/Static/새우튀김도시락.png" },
            new Food(){ category = Category.lunchBox, name = "세우튀김스테이크도시락", imagePath = @"/Static/새우튀김스테이크도시락.png" },

            new Food(){ category = Category.RiceBowl, name = "참치마요덮밥", imagePath = @"/Static/참치마요덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "참치비빔덮밥", imagePath = @"/Static/참치비빔덮밥.jpg" },
            new Food(){ category = Category.RiceBowl, name = "치킨마요덮밥", imagePath = @"/Static/치킨마요덮밥.jpg" },

            new Food(){ category = Category.juice, name = "콜라", imagePath = @"/Static/콜라.jpg" },
            new Food(){ category = Category.juice, name = "사이다", imagePath = @"/Static/칠성사이다.jpg" },
        };

        public UserControlOrder()
        {
            InitializeComponent();

            this.FontFamily = new System.Windows.Media.FontFamily("배달의민족 도현");

            this.Loaded += MainWindow_Loaded;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbCategory.SelectedIndex = 0; //처음 실행 시 첫번째 카테고리가 선택되도록 
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;

            Category category = (Category)lbCategory.SelectedIndex;
            lbMenus.ItemsSource = lstFood.Where(x => x.category == category).ToList();
        }
        private void MoveToHome(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).MoveToHome(sender, e);
        }
    }
}
