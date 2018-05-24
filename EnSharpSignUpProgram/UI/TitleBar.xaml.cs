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
    /// TitleBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBar : System.Windows.Controls.UserControl
    {
        private MainWindow mainWindow;

        public TitleBar()
        {
            InitializeComponent();
        }

        public void PassMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        // 상단바 드래그
        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.DragMove();
        }

        // 닫기버튼
        private void close_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            close.Background = Brushes.Red;
            close.Foreground = Brushes.White;
        }

        // 닫기버튼
        private void close_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            close.Background = Brushes.Transparent;
            close.Opacity = 1;
            close.Foreground = Brushes.Gray;
        }

        // 닫기버튼
        private void close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            close.Opacity = 0.5;
        }

        // 닫기버튼
        private void close_MouseLeftButtonUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Database.CloseConnectMySQL();
            mainWindow.Close();
        }
    }
}
