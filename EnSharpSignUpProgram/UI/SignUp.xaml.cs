using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : UserControl
    {
        private InputProcessor inputProcessor = new InputProcessor();
        private MainUserInterface mainUserInterface;
        private Home home;
        private string name = "";

        public SignUp(MainUserInterface mainUserInterface, Home home)
        {
            InitializeComponent();
            this.mainUserInterface = mainUserInterface;
            this.home = home;
        }

        public void keyUp(object sender, KeyEventArgs e, int mode)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                NextQuestion(mode);
            }

            switch (mode)
            {
                case Constant.NAME:
                    inputProcessor.UserName(nameBox, warning);
                    break;
                case Constant.ID:
                    inputProcessor.UserID(idBox, warning);
                    break;
                case Constant.PASSWORD:
                    break;
            }
        }

        public bool NextQuestion(int mode)
        {
            bool isValid = true;

            switch (mode)
            {
                case Constant.NAME:
                    if (inputProcessor.IsValidName(nameBox, warning))
                    {
                        name = nameBox.Text;
                        idBox.Visibility = Visibility.Visible;
                        idBox.Focus();
                    }
                    break;
                case Constant.ID:
                    break;
                case Constant.PASSWORD:
                    break;
            }

            return isValid;
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int mode = Int32.Parse(textBox.Tag.ToString());

            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler((object sndr, KeyEventArgs args) => keyUp(sndr, args, mode)), true);
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Length == 0)
            {
                nameBox.Foreground = new SolidColorBrush(Constant.PLACEHOLDER_COLOR);
                nameBox.Text = "이름";
                name = "";
            }
            else
            {
                name = nameBox.Text;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainUserInterface.MainGrid.Children.Remove(this);
            mainUserInterface.MainGrid.Children.Insert(1, home);
        }
    }
}
