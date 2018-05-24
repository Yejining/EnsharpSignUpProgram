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

namespace EnSharpSignUpProgram.UI
{
    /// <summary>
    /// MainUserInterface.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainUserInterface : UserControl
    {
        private MainWindow mainWindow;
        private TitleBar titleBar = new TitleBar();
        private SignUp signUp = new SignUp();

        public MainUserInterface()
        {
            InitializeComponent();

            // MainUserInterface 클래스와 연결
            MainGrid.Children.Add(titleBar);
            Grid.SetRow(titleBar, 0);

            // MainUserInterface 클래스와 연결
            MainGrid.Children.Add(signUp);
            Grid.SetRow(signUp, 1);
        }

        public void PassMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            titleBar.PassMainWindow(mainWindow);
        }
    }
}
