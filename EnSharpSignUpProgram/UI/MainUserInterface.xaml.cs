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

namespace EnSharpSignUpProgram.UI
{
    /// <summary>
    /// MainUserInterface.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainUserInterface : UserControl
    {
        private string userID = "";
        private MainWindow mainWindow;
        private TitleBar titleBar = new TitleBar();
        private Home home;
        private LogIn logIn;

        public MainUserInterface()
        {
            InitializeComponent();

            Database.ConnectToMySQL();
            logIn = new LogIn(userID);

            // titleBar 클래스와 연결
            MainGrid.Children.Add(titleBar);
            Grid.SetRow(titleBar, 0);

            // Home 클래스와 연결
            home = new Home(userID);
            MainGrid.Children.Add(home);
            Grid.SetRow(home, 1);

            home.first.Click += new RoutedEventHandler(first_Click);
            home.second.Click += new RoutedEventHandler(second_Click);
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {
            if (userID.Length == 0)
            {
                MainGrid.Children.Remove(home);
                MainGrid.Children.Add(logIn);
                Grid.SetRow(logIn, 1);
                logIn.In(this, home);
            }
            else
            {
                userID = "";
                home.UpdateButtonName(userID);
            }
        }

        private void second_Click(object sender, RoutedEventArgs e)
        {
            if (userID.Length == 0)
            {

            }
            else
            {

            }
        }

        public void PassMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            titleBar.PassMainWindow(mainWindow);
        }

        public string UserID
        {
            set { userID = value; }
        }
    }
}
