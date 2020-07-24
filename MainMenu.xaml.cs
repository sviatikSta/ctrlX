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
using System.Windows.Shapes;

namespace CtrlX
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Back1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void ClickAdd(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProductAdd add = new ProductAdd();
            add.Show();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProductSearch add = new ProductSearch();
            add.Show();
        }

        private void ClickReport_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar report = new ProgressBar();
            report.Show();
        }
    }
}
