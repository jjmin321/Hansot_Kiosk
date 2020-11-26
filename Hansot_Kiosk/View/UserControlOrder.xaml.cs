using Hansot_Kiosk.Database.Repository;
using Hansot_Kiosk.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class UserControlOrder : CustomControlModel, INotifyPropertyChanged
    {
        int startNumber = 0;

        OrderMenuRepository orderMenuRepository = new OrderMenuRepository();

        //private List<Model.Menu> calcaulation = new List<Model.Menu>()
        //{
        //    //담겨지는 리스트
        //};

        private List<Model.Menu> seeSixList = new List<Model.Menu>()
        {
            //메뉴 정보가 담겨져있는 리스트
        };

        
        private List<Model.Menu> menus = new List<Model.Menu>();
        public UserControlOrder()
        {
            InitializeComponent();
            this.FontFamily = new System.Windows.Media.FontFamily("배달의민족 도현");
            this.Loaded += MainWindow_Loaded;
            // tbTotalPrice.Text = App.payViewModel.TotalMoney + "";
            tbTotalPrice.DataContext = App.payViewModel;
            this.listView.ItemsSource = App.orderViewModel.orderMenu; // listView 담겨지는 calcaulation 담겨지는 리스트 
            OnPropertyChanged("");
            BtnNotClick();
            MenuRepository repository = new MenuRepository();
            menus = repository.GetMenus();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            this.DataContext = App.payViewModel;
            lbCategory.SelectedIndex = 0;
        }
        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startNumber = 0;
            if (lbCategory.SelectedIndex == -1) return;
            divideMenu();
            Category category = (Category)lbCategory.SelectedIndex;
            lbMenus.ItemsSource = seeSixList.Where(x => x.category == category).ToList();
            
        }
        private void lbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnNotClick();
            Model.Menu food = (Model.Menu)lbMenus.SelectedItem;
            int flag = 0; // 이미 그 메뉴가 있으면 더이상 추가 안되게 
            if (food != null)
            {
                for (int i = 0; i< App.orderViewModel.orderMenu.Count; i++)
                {
                    if(food.name == App.orderViewModel.orderMenu[i].name)
                    {
                        App.orderViewModel.orderMenu[i].count++;
                        flag = 1;
                        break;
                    }
                }
            
                if (flag == 0)
                {
                    App.orderViewModel.orderMenu.Add(food);
                    for (int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
                    {
                        if (food.name == App.orderViewModel.orderMenu[i].name)
                        {
                            App.orderViewModel.orderMenu[i].count++;
                        }
                    }
                }
            }
            calculationPrice();
            lbMenus.SelectedItem = null;
            listView.Items.Refresh();
        }
        private void plusMinusThisMenu(object sender, RoutedEventArgs e)
        {
            var name = (sender as System.Windows.Controls.Button).Name;
            var food = ((System.Windows.Controls.ListViewItem)listView.ContainerFromElement(sender as System.Windows.Controls.Button)).Content as Model.Menu;
            if (name == "plus")
            {
                for (int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
                {
                    if (food.name == App.orderViewModel.orderMenu[i].name)
                    {
                        App.orderViewModel.orderMenu[i].count++;
                        calculationPrice();
                    }
                }
            }
            else
            {
                for(int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
                {
                    if (food.name == App.orderViewModel.orderMenu[i].name)
                    {
                        if (food.count == 1)
                        {
                            App.orderViewModel.orderMenu[i].count = 0;
                            calculationPrice();
                            App.orderViewModel.orderMenu.Remove(food);
                            listView.Items.Refresh();
                        }
                        else
                        {
                            App.orderViewModel.orderMenu[i].count--;
                            calculationPrice();
                        }
                    }
                }
                BtnNotClick();
            }
            listView.Items.Refresh();
        }
        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            calculationPrice();
            if (App.payViewModel.TotalMoney != 0)
            {
                if (System.Windows.MessageBox.Show("홈화면으로 이동하시겠습니까? 홈화면으로 이동시 주문하던 메뉴가 지워집니다.", "안내", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
                    {
                        App.orderViewModel.orderMenu[i].count = 0;
                    }
                    App.payViewModel.TotalMoney = 0;
                    App.orderViewModel.orderMenu.Clear();

                    calculationPrice();
                    listView.Items.Refresh();
                    App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
                }
                else
                {
                    System.Windows.MessageBox.Show("취소되었습니다, 안내");
                }
            }
            else
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
            }

        }
        private void btnMoveToPlace(object sender, RoutedEventArgs e)
        {
            BtnNotClick();
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }
        private void calculationPrice()
        {
            BtnNotClick();

            App.payViewModel.TotalMoney = 0;
            for (int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
            {
                App.payViewModel.TotalMoney += App.orderViewModel.orderMenu[i].price * App.orderViewModel.orderMenu[i].count;
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var food = ((System.Windows.Controls.ListViewItem)listView.ContainerFromElement(sender as System.Windows.Controls.Button)).Content as Model.Menu;
            food.count = 0;
            App.orderViewModel.orderMenu.Remove(food);
            listView.Items.Refresh();
            calculationPrice();
            BtnNotClick();
        }
        private void RemoveAll(object sender, RoutedEventArgs e)
        {
                if(System.Windows.MessageBox.Show("선택한 메뉴를 모두 삭제하시겠습니까?", "안내", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < App.orderViewModel.orderMenu.Count; i++)
                    {
                    App.orderViewModel.orderMenu[i].count = 0;
                    }
                    App.orderViewModel.orderMenu.Clear();
                    App.payViewModel.TotalMoney = 0;
                
                    calculationPrice();
                    listView.Items.Refresh();
                }
                else
                {
                    System.Windows.MessageBox.Show("취소되었습니다, 안내");
                }
        }

        private void BtnNotClick()
            
        {
            if(App.payViewModel.TotalMoney ==0)
            {
                AllRemove.IsEnabled = false;
                OrderBtn.IsEnabled = false;
            }
            else
            {
                AllRemove.IsEnabled = true;
                OrderBtn.IsEnabled = true;
            }
        }

        public void divideMenu()
        {
            seeSixList.Clear();
            Category category = (Category)lbCategory.SelectedIndex;
            if (lbCategory.SelectedIndex == -1)
            {
                category = Category.lunchBox;
            }
            
            
            for (int i = startNumber; i < menus.Count; i++)//전체 메뉴만큼 돌아서 그 안에서 카테고리가 선택된것에 리스트를 추가해주는것
            {
                if (menus[i].category == category)//카테고리 확인
                {
                    seeSixList.Add(menus[i]);
                    //카운터를 카테고리 메뉴 갯수를 세고 그 수에 /6 한다음에 남은것을 구함 -> 구한 값 만큼 for문을 돌려서
                }
                lbMenus.ItemsSource = null;
            }
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {
            var name = (sender as System.Windows.Controls.Button).Name;
            Category category = (Category)lbCategory.SelectedIndex;

            if (category== Category.lunchBox)
            {
                
            }
            if (name == "next")
            {
                if(category == Category.lunchBox && startNumber < 6 )
                {
                    startNumber += 6;
                }
                else if (category == Category.RiceBowl&& startNumber < 12)
                {
                    startNumber += 12;
                }
                else
                {
                    System.Windows.MessageBox.Show("다음페이지가 없습니다.");
                }
            }
            else
            {
                if (startNumber > 1&& category == Category.lunchBox)
                {
                        startNumber -= 6;
                }
                else if (category == Category.RiceBowl && startNumber > 7)
                {
                    startNumber -= 12;
                }
                else
                {
                    System.Windows.MessageBox.Show("이전페이지가 없습니다.");
                }
            }
            divideMenu();
            lbMenus.ItemsSource = seeSixList ;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
