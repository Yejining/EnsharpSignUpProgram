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

namespace EnSharpSignUpProgram.UI
{
    /// <summary>
    /// Home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : UserControl
    {
        public Home(string userID)
        {
            InitializeComponent();
            
            UpdateButtonName(userID);
        }

        public void UpdateButtonName(string userID)
        {
            if (userID.Length == 0)
            {
                first.Content = "로그인";
                second.Content = "회원가입";
            }
            else
            {
                first.Content = "로그아웃";
                second.Content = "내정보";
            }
        }
    }
}
