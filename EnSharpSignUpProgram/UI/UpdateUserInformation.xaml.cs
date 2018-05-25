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

using EnSharpSignUpProgram.Data;

namespace EnSharpSignUpProgram.UI
{
    /// <summary>
    /// UpdateUserInformation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UpdateUserInformation : UserControl
    {
        private MainUserInterface mainUserInterface;
        private Home home;
        private string userID;

        public UpdateUserInformation(MainUserInterface mainUserInterface, Home home)
        {
            InitializeComponent();

            this.mainUserInterface = mainUserInterface;
            this.home = home;
        }

        public void SetUser(string userID)
        {
            this.userID = userID;
        }

        public void SetUserInformation()
        {
            string userPhone = Database.SelectFromDatabase("phone_number", "member", $" WHERE id=\"{userID}\"")[0];
            string userMail = Database.SelectFromDatabase("mail", "member", $" WHERE id=\"{userID}\"")[0];
            string userAddress = Database.SelectFromDatabase("address", "member", $" WHERE id=\"{userID}\"")[0];

            user_phone.Content = userPhone;
            user_mail.Content = userMail;
            user_address.Content = userAddress;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainUserInterface.MainGrid.Children.Remove(this);
            mainUserInterface.MainGrid.Children.Insert(1, home);
            home.UpdateButtonName(userID);
        }

        private void btn_out_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
