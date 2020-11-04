using Hansot_Kiosk.Database.Repository;
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
using UIStateManagerLibrary;

namespace Hansot_Kiosk.View
{
    /// <summary>
    /// UserControlLogin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlLogin : CustomControlModel
    {
        UserRepository userRepository = new UserRepository();
        public UserControlLogin()
        {
            InitializeComponent();
            if (App.userViewModel.Auto == 1)
            {
               Debug.WriteLine("자동 로그인 되었습니다!");
            } // 이거 안 되는데 고치자 시부레 ㅋㅋ

        }

        public void btnLogin(object sender, RoutedEventArgs e)
        {
            App.userViewModel.Name = userRepository.GetUserName(tbId.Text, tbPw.Text);
            App.userViewModel.Barcode = userRepository.GetUserBarcode(tbId.Text, tbPw.Text);
            if (App.userViewModel.Name == null)
            {
                MessageBox.Show("유저를 찾을 수 없습니다");
            } else
            {
                MessageBox.Show("안녕하세요" + App.userViewModel.Name + "님");
                App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
                if (AutoLogin.IsChecked == true)
                {
                    userRepository.SetLogin(App.userViewModel.Name, App.userViewModel.Barcode);
                }
            }
        }
    }
}
