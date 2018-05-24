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

using EnSharpSignUpProgram.UI;
using EnSharpSignUpProgram.API;

namespace EnSharpSignUpProgram
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainUserInterface mainUserInterface = new MainUserInterface();
        private UsingAPI usingAPI = new UsingAPI();

        public MainWindow()
        {
            InitializeComponent();

            // MainUserInterface 클래스와 연결
            mainUserInterface.PassMainWindow(this);
            MainGrid.Children.Add(mainUserInterface);
        }
    }
}
