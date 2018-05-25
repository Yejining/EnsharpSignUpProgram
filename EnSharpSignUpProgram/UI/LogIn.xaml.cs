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
using EnSharpSignUpProgram.Controller;

namespace EnSharpSignUpProgram.UI
{
    /// <summary>
    /// LogIn.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogIn : UserControl
    {
        private string userID;
        private string userInputPassword = "";
        private InputProcessor inputProcessor = new InputProcessor();
        private MainUserInterface mainUserInterface;
        private Home home;

        public LogIn(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        public void In(MainUserInterface mainUserInterface, Home home)
        {
            this.mainUserInterface = mainUserInterface;
            this.home = home;

            log_in.IsEnabled = false;

            SetPlaceHolder(id);
            SetPlaceHolder(password);

            id.GotFocus += (object sndr, RoutedEventArgs args) => btn_GotFocus(sndr, args, id);
            id.LostFocus += (object sndr, RoutedEventArgs args) => btn_LostFocus(sndr, args, id);
            password.GotFocus += (object sndr, RoutedEventArgs args) => btn_GotFocus(sndr, args, password);
            password.LostFocus += (object sndr, RoutedEventArgs args) => btn_LostFocus(sndr, args, password);

            log_in.Click += new RoutedEventHandler(log_in_Click);
        }

        private void btn_GotFocus(object sender, RoutedEventArgs e, TextBox textBox)
        {
            int limit = 0;

            RemovePlaceHolder(textBox);

            if (textBox.Name == "id") limit = 20;
            else if (textBox.Name == "password") limit = 16;

            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler((object sndr, KeyEventArgs args) => CheckValidate(sndr, args, textBox, limit)), true);
        }

        private void CheckValidate(object sender, KeyEventArgs e, TextBox textBox, int limit)
        {
            if (textBox.Tag.ToString() == "비밀번호")
            {
                if (textBox.Text.Length == 0)
                {
                    userInputPassword = "";
                }
                else if (e.Key == Key.Back)
                {
                    userInputPassword = userInputPassword.Remove(userInputPassword.Length - 1);
                }
                else
                {
                    userInputPassword += password.Text[password.Text.Length - 1];
                }
            }

            if (id.Text.Length > 5 && password.Text.Length > 6)
                log_in.IsEnabled = true;
            else
                log_in.IsEnabled = false;

            inputProcessor.LogInProcess(sender, e, textBox, limit);
        }

        private void btn_LostFocus(object sender, RoutedEventArgs e, TextBox textBox)
        {
            SetPlaceHolder(textBox);
        }

        public void SetPlaceHolder(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.Foreground = new SolidColorBrush(Constant.PLACEHOLDER_COLOR);
                textBox.Text = textBox.Tag.ToString();
            }
        }

        public void RemovePlaceHolder(TextBox textBox)
        {
            if (string.Compare(textBox.Text, textBox.Tag.ToString()) == 0)
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Constant.TEXT_COLOR);
            }
        }

        private void log_in_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = Database.CheckIDAndPassword(id.Text, password.Text);

            if (isValid)
            {
                userID = id.Text;

                mainUserInterface.UserID = id.Text;
                mainUserInterface.MainGrid.Children.Remove(this);
                mainUserInterface.MainGrid.Children.Insert(1, home);
                home.UpdateButtonName(userID);

                id.Text = "";
                password.Text = "";
            }
            else
            {
                MessageBox.Show(Constant.WRONG_LOG_IN);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainUserInterface.UserID = id.Text;
            mainUserInterface.MainGrid.Children.Remove(this);
            mainUserInterface.MainGrid.Children.Insert(1, home);
            home.UpdateButtonName(userID);

            id.Text = "";
            password.Text = "";
        }
    }
}
