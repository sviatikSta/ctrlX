using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            String ID = NewId.Text;
            String Name = NewName.Text;
            String Category = NewCategory.Text;
            String ReleaseYear = NewReleaseYear.Text;
            String Warranty = NewWarranty.Text;
            String Count = NewCount.Text;
            String Price = NewPrice.Text;
            String Provider = NewProvider.Text;
            String Phone = NewPhone.Text;
            String DateArrived = NewArrived.Text;
            String WarehouseNumber = NewWarehouseNumber.Text;
            String Info = NewInfo.Text;
            String Notes = NewNotes.Text;

            DataBase DB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `products` WHERE `ID` = @sL", DB.getConnection());
            command.Parameters.Add("@sL", MySqlDbType.VarChar).Value = ID;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            Regex regPhone = new Regex(@"(^\+380\d{9}$)");
            Regex regData = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\.(0[1-9]|1[0-2])\.(20\d\d))$");
            Regex regYear = new Regex(@"((20[0-2][0-9])|(19[5-9][0-9]))$");
            Regex regID = new Regex(@"\d{6}$");
            Regex regCount = new Regex(@"(^\d{0,3}$)");
            Regex regPrice = new Regex(@"(^\d{0,7}$)");
            Regex regWarehouse = new Regex(@"(^\d{0,3}$)");

            bool verifyDate = regData.IsMatch(DateArrived);
            bool verifyPhone = regPhone.IsMatch(Phone);
            bool verifyYear = regYear.IsMatch(ReleaseYear);
            bool verifyID = regID.IsMatch(ID);
            bool verifyCount = regCount.IsMatch(Count);
            bool verifyPrice = regPrice.IsMatch(Price);
            bool verifyWarehouse = regWarehouse.IsMatch(WarehouseNumber);

            if ( Name == "" || Category == "" || Warranty == "" || Count == "" || Price == "" || Provider == "" || WarehouseNumber == "")
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Заповніть всі обов'язкові поля";
                dialog.Show();
            }
            else if (!verifyID)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Введіть коректний ID!";
                dialog.Show();
            }            
            else if (table.Rows.Count > 0)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Данний ID уже використовується";
                dialog.Show();
            }            
            else if (!verifyYear)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Введіть коректний рік випуску";
                dialog.Show();
            }            
            else if (!verifyCount)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Кількість товару не може містити символи";
                dialog.Show();
            }
            else if (!verifyPrice)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Ціна не може містити символи";
                dialog.Show();
            }            
            else if (!verifyPhone)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Введіть коректний номер телефону!";
                dialog.Show();
            }            
            else if (!verifyDate)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Введіть дату у форматі дд.мм.рррр";
                dialog.Show();
            }
            else if (!verifyWarehouse)
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Номер складу не може містити символи";
                dialog.Show();
            }
            else
            {
                MySqlCommand command1 = new MySqlCommand("INSERT INTO `products` (`ID`, `Name`,`Category`,`ReleaseYear`,`Warranty`,`Count`,`Price`,`Provider`,`Phone`,`DateArrived`,`WarehouseNumber`,`Info`,`Notes`) " +
                "VALUES (@I,@Na,@Ca,@Re,@War,@Co,@Pri,@Pr,@Ph,@Da,@Wa,@In,@No)", DB.getConnection());
                command1.Parameters.Add("@I", MySqlDbType.VarChar).Value = ID;
                command1.Parameters.Add("@Na", MySqlDbType.VarChar).Value = Name;
                command1.Parameters.Add("@Ca", MySqlDbType.VarChar).Value = Category;
                command1.Parameters.Add("@Re", MySqlDbType.VarChar).Value = ReleaseYear;
                command1.Parameters.Add("@War", MySqlDbType.VarChar).Value = Warranty;
                command1.Parameters.Add("@Co", MySqlDbType.VarChar).Value = Count;
                command1.Parameters.Add("@Pri", MySqlDbType.VarChar).Value = Price;
                command1.Parameters.Add("@Pr", MySqlDbType.VarChar).Value = Provider;
                command1.Parameters.Add("@Ph", MySqlDbType.VarChar).Value = Phone;
                command1.Parameters.Add("@Da", MySqlDbType.VarChar).Value = DateArrived;
                command1.Parameters.Add("@Wa", MySqlDbType.VarChar).Value = WarehouseNumber;
                command1.Parameters.Add("@In", MySqlDbType.VarChar).Value = Info;
                command1.Parameters.Add("@No", MySqlDbType.VarChar).Value = Notes;
                DB.openConnection();
                if (command1.ExecuteNonQuery() > 0)
                {
                    Error dialog = new Error();
                    dialog.ErrorText.Text = "Ви додали новий товар";
                    dialog.Title = "Новий товар";
                    dialog.Show();
                }    
                else
                {
                    Error dialog = new Error();
                    dialog.ErrorText.Text = "Введіть коректний номер телефону!";
                    dialog.Title = "Введіть коректний номер телефону!";
                    dialog.Show();
                }
                DB.closeConnection();
            }
        }

    }
}
