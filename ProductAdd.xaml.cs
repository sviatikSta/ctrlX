using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CtrlX
{
    /// <summary>
    /// Interaction logic for ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window
    {
        public ProductAdd()
        {
            InitializeComponent();
        }

        private void Back2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu window = new MainMenu();
            window.Show();
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
            String ID = NewId.Text;
            String Name = NewName.Text;
            String Category = NewCategory.Text;
            int ReleaseYear = Convert.ToInt32(NewReleaseYear.Text);
            String Warranty = NewWarranty.Text;
            int Count = Convert.ToInt32(NewCount.Text);
            int Price = Convert.ToInt32(NewPrice.Text);
            String Provider = NewProvider.Text;
            String Phone = NewPhone.Text;
            String DateArrived = NewArrived.Text;
            int WarehouseNumber = Convert.ToInt32(NewWarehouseNumber.Text);
            String Info = NewInfo.Text;
            String Notes = NewNotes.Text;
            DataBase DB = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `products` (`ID`, `Name`,`Category`,`ReleaseYear`,`Warranty`,`Count`,`Price`,`Provider`,`Phone`,`DataArrived`,`WarehouseNumber`,`Info`,`Notes`) " +
                "VALUES (@I,@Na,@Ca,@Re,@War,@Co,@Pri,@Pr,@Ph,@Da,@Wa,@In,@No)", DB.getConnection());
            command.Parameters.Add("@I", MySqlDbType.VarChar).Value = ID;
            command.Parameters.Add("@Na", MySqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@Ca", MySqlDbType.VarChar).Value = Category;
            command.Parameters.Add("@Re", MySqlDbType.Int64).Value = ReleaseYear;
            command.Parameters.Add("@War", MySqlDbType.VarChar).Value = Warranty;
            command.Parameters.Add("@Co", MySqlDbType.Int64).Value = Count;
            command.Parameters.Add("@Pri", MySqlDbType.Int64).Value = Price;
            command.Parameters.Add("@Pr", MySqlDbType.VarChar).Value = Provider;
            command.Parameters.Add("@Ph", MySqlDbType.VarChar).Value = Phone;
            command.Parameters.Add("@Da", MySqlDbType.VarChar).Value = DateArrived;
            command.Parameters.Add("@Wa", MySqlDbType.Int64).Value = WarehouseNumber;
            command.Parameters.Add("@In", MySqlDbType.VarChar).Value = Info;
            command.Parameters.Add("@No", MySqlDbType.VarChar).Value = Notes;

            DB.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Товар додано");
            else
                MessageBox.Show("Товар не додано");
            DB.closeConnection();
        }
    }
}
