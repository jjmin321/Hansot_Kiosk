using Hansot_Kiosk.Model;
using Hansot_Kiosk.Database.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// UserControlPayResult.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlPayResult : CustomControlModel, INotifyPropertyChanged
    {
        public string User;

        OrderMenuRepository orderMenuRepository = new OrderMenuRepository();

        UserControlSelectTable ucSelectTable = new UserControlSelectTable();
        public UserControlPayResult()
        {
            InitializeComponent();
            Loaded += UserControlPayResult_Loaded;
            OnPropertyChanged("");
        }

        private void UserControlPayResult_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.payViewModel;
        }

        private void btnMoveToHome(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(UserControlSelectTable.CurButton);
            int useridx = orderMenuRepository.GetIdx();
            orderMenuRepository.InsertMneu(App.orderViewModel.orderMenu, useridx);
            for(int i = 0;  App.orderViewModel.orderMenu.Count > i; i++)
            {
                App.orderViewModel.orderMenu[i].count = 0;
            }
            App.orderViewModel.orderMenu.Clear();
            App.payViewModel.TotalMoney = 0;
            
            
            SelectedTableCountDown();
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        void SelectedTableCountDown()
        {
            string TableNum = "";
            if (UserControlSelectTable.CurButton == null)
                return;
            if (UserControlSelectTable.CurButton.Name == "Num1") TableNum = "1번";
            else if (UserControlSelectTable.CurButton.Name == "Num2") TableNum = "2번";
            else if (UserControlSelectTable.CurButton.Name == "Num3") TableNum = "3번";
            else if (UserControlSelectTable.CurButton.Name == "Num4") TableNum = "4번";
            else if (UserControlSelectTable.CurButton.Name == "Num5") TableNum = "5번";
            else if (UserControlSelectTable.CurButton.Name == "Num6") TableNum = "6번";
            else if (UserControlSelectTable.CurButton.Name == "Num7") TableNum = "7번";
            else if (UserControlSelectTable.CurButton.Name == "Num8") TableNum = "8번";
            else if (UserControlSelectTable.CurButton.Name == "Num9") TableNum = "9번";

            ucSelectTable.CountDown(UserControlSelectTable.CurButton, TableNum);
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
