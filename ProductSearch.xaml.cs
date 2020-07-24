using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CtrlX
{
    /// <summary>
    /// Interaction logic for ProductSearch.xaml
    /// </summary>
    public partial class ProductSearch : Window
    {
        public ProductSearch()
        {
            InitializeComponent();
        }
        public void ReadBD(string sqlExpression)
        {
            string ProductInfo = TextBox1.Text;
            string connectionString = @"server = localhost; port = 3306; user = root; password = root; database = ctrlxxx";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                command.Parameters.Add("@PInfo", MySqlDbType.VarChar).Value = ProductInfo;
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string id = (string)reader.GetValue(0);
                        string Name = (string)reader.GetValue(1);
                        string Category = (string)reader.GetValue(2);
                        string ReleaseYear = (string)reader.GetValue(3);
                        string Warranty = (string)reader.GetValue(4);
                        string Count = (string)reader.GetValue(5);
                        string Price = (string)reader.GetValue(6);
                        string Provider = (string)reader.GetValue(7);
                        string Phone = (string)reader.GetValue(8);
                        string DateArrived = (string)reader.GetValue(9);
                        string WarehouseNumber = (string)reader.GetValue(10);
                        string Info = (string)reader.GetValue(11);
                        string Notes = (string)reader.GetValue(12);

                        SearchBox.Text = " ID: " + id + "\n Назва: " + Name + "\n Категорія: " + Category + "\n Рік випуску: " + ReleaseYear + "\n Гарантія: " + Warranty +
                        "\n Кількість одиниць: " + Count + "\n Ціна: " + Price + "\n Постачальник: " + Provider + "\n Номер постачальника: " + Phone +
                         "\n Дата поставки: " + DateArrived + "\n Номер складу: " + WarehouseNumber + "\n Опис: " + Info + "\n Примітки: " + Notes;
                    }
                }
                else
                {
                    SearchBox.Visibility = Visibility.Hidden;
                    imageNotebook.Visibility = Visibility.Visible;
                    ButtonEdit.Visibility = Visibility.Hidden;
                    ButtonDelete.Visibility = Visibility.Hidden;

                    Error dialog = new Error();
                    dialog.ErrorText.Text = "Товар не знайдено";
                    dialog.Title = "Пошук товару";
                    dialog.Show();
                }

                reader.Close();

                connection.Close();
            }
        }
        private void TextBox1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox1.Text = "";
            TextBox1.Foreground = Brushes.Black;
        }

        private void Back3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu window = new MainMenu();
            window.Show();
        }

        private void ClickDelete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте удалити цей товар?", "Видалення", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.OK)
            {                
                if (NameCheck.IsChecked == true)
                {
                    String Name = TextBox1.Text;
                    DataBase DB = new DataBase();
                    MySqlCommand command1 = new MySqlCommand("DELETE FROM `products` WHERE `products`.`Name` = @Na", DB.getConnection());
                    command1.Parameters.Add("@Na", MySqlDbType.VarChar).Value = Name;
                    DB.openConnection();
                    if (command1.ExecuteNonQuery() > 0)
                    {
                        Error dialog = new Error();
                        dialog.ErrorText.Text = "Товар було видалено";
                        dialog.Title = "Видалення товару";
                        dialog.Show();
                    }
                    else
                    {
                        Error dialog = new Error();
                        dialog.ErrorText.Text = "Товар не видалено";
                        dialog.Title = "Видалення товару";
                        dialog.Show();
                    }    
                    DB.closeConnection();
                }
                else if (IdCheck.IsChecked == true)
                {
                    String ID = TextBox1.Text;
                    DataBase DB = new DataBase();
                    MySqlCommand command1 = new MySqlCommand("DELETE FROM `products` WHERE `products`.`ID` = @I", DB.getConnection());
                    command1.Parameters.Add("@I", MySqlDbType.VarChar).Value = ID;
                    DB.openConnection();
                    if (command1.ExecuteNonQuery() > 0)
                    {
                        Error dialog = new Error();
                        dialog.ErrorText.Text = "Товар було видалено";
                        dialog.Title = "Видалення товару";
                        dialog.Show();
                    }
                    else
                    {
                        Error dialog = new Error();
                        dialog.ErrorText.Text = "Товар не видалено";
                        dialog.Title = "Видалення товару";
                        dialog.Show();
                    }
                    DB.closeConnection();
                }
                SearchBox.Visibility = Visibility.Hidden;
                imageNotebook.Visibility = Visibility.Visible;
                ButtonEdit.Visibility = Visibility.Hidden;
                ButtonDelete.Visibility = Visibility.Hidden;
            }

        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ID_Checked(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = String.Empty;
            TextBox1.Foreground = Brushes.LightGray;
            TextBox1.FontSize = 24;
            TextBox1.Text = "Введіть ID...";

        }

        private void Name_Checked(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = String.Empty;
            TextBox1.Foreground = Brushes.LightGray;
            TextBox1.FontSize = 24;
            TextBox1.Text = "Введіть назву...";
        }
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            SearchBox.Visibility = Visibility.Visible;
            imageNotebook.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Visible;
            ButtonDelete.Visibility = Visibility.Visible;

            if (NameCheck.IsChecked == true)
                ReadBD("SELECT * FROM products WHERE Name = @PInfo");
            if (IdCheck.IsChecked == true)
                ReadBD("SELECT * FROM products WHERE ID = @PInfo");

        }
        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
           SearchBox.Visibility = Visibility.Visible;
            imageNotebook.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Visible;
            ButtonDelete.Visibility = Visibility.Visible;

                if (NameCheck.IsChecked == true)
                    ReadBD("SELECT * FROM products WHERE Name = @PInfo");
                if (IdCheck.IsChecked == true)
                    ReadBD("SELECT * FROM products WHERE ID = @PInfo");
            }
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {            
         SearchBox.Visibility = Visibility.Hidden;
         imageNotebook.Visibility = Visibility.Visible;
         ButtonEdit.Visibility = Visibility.Hidden;
         ButtonDelete.Visibility = Visibility.Hidden;
                    bool NameID = (bool)NameCheck.IsChecked;
                    ProductEdit window = new ProductEdit(TextBox1.Text, NameID);
                    window.Show();

        }

    }
}
