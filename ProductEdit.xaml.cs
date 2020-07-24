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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace CtrlX
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        public ProductEdit(string NameOrID, bool Check)
        {
            InitializeComponent();
            if (Check == true)
            {
                string a = NameOrID;
                ReadBD("SELECT * FROM products WHERE Name = @PInfo", a);
            }
            else if (Check == false)
            {
                string a = NameOrID;
                ReadBD("SELECT * FROM products WHERE ID = @PInfo", a);
            }
        }

        private void ReadBD(string SqlRequest, string NameOrID)
        {
            using (MySqlConnection connection = new MySqlConnection("server = localhost; port = 3306; user = root; password = root; database = ctrlxxx"))
            {
                DataBase DB = new DataBase();
                MySqlCommand command = new MySqlCommand(SqlRequest, DB.getConnection());
                command.Parameters.Add("@PInfo", MySqlDbType.VarChar).Value = NameOrID;
                DB.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NewId.Text = (string)reader.GetValue(0);
                    NewName.Text = (string)reader.GetValue(1);
                    NewCategory.Text = (string)reader.GetValue(2);
                    NewReleaseYear.Text = (string)reader.GetValue(3);
                    NewWarranty.Text = (string)reader.GetValue(4);
                    NewCount.Text = (string)reader.GetValue(5);
                    NewPrice.Text = (string)reader.GetValue(6);
                    NewProvider.Text = (string)reader.GetValue(7);
                    NewPhone.Text = (string)reader.GetValue(8);
                    NewArrived.Text = (string)reader.GetValue(9);
                    NewWarehouseNumber.Text = (string)reader.GetValue(10);
                    NewInfo.Text = (string)reader.GetValue(11);
                    NewNotes.Text = (string)reader.GetValue(12);
                }
                reader.Close();
                connection.Close();
                DB.closeConnection();
            }
        }
        private void EditBD()
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

            Regex regPhone = new Regex(@"(^\+380\d{9}$)");
            Regex regData = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\.(0[1-9]|1[0-2])\.(20\d\d))$");
            Regex regYear = new Regex(@"((20[0-1][0-9])|(20[0-2]0)|(19[5-9][0-9]))$");
            Regex regCount = new Regex(@"(^\d{0,3}$)");
            Regex regPrice = new Regex(@"(^\d{0,7}$)");
            Regex regWarehouse = new Regex(@"(^\d{0,3}$)");

            bool verifyDate = regData.IsMatch(DateArrived);
            bool verifyPhone = regPhone.IsMatch(Phone);
            bool verifyYear = regYear.IsMatch(ReleaseYear);
            bool verifyCount = regCount.IsMatch(Count);
            bool verifyPrice = regPrice.IsMatch(Price);
            bool verifyWarehouse = regWarehouse.IsMatch(WarehouseNumber);

            if (Name == "" || Category == "" || Warranty == "" || Count == "" || Price == "" || Provider == "" || WarehouseNumber == "")
            {
                Error dialog = new Error();
                dialog.ErrorText.Text = "Заповніть всі обов'язкові поля";
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
                DataBase DB = new DataBase();
                MySqlCommand command1 = new MySqlCommand("UPDATE `products` SET `Name` = @Na, `Category` = @Ca, " +
                    "`ReleaseYear` = @Re, `Warranty` = @War, `Count` = @Co, `Price` = @Pri, `Provider` = @Pr, " +
                    "`Phone` = @Ph, `DateArrived` = @Da, `WarehouseNumber` = @Wa,`Info` = @In, `Notes` = @No  WHERE `products`.`ID` = @OldName", DB.getConnection());
                command1.Parameters.Add("@OldName", MySqlDbType.VarChar).Value = ID;
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
                    dialog.ErrorText.Text = "Товар було змінено";
                    dialog.Title = "Зміна товару";
                    dialog.Show();
                }
                else
                {
                    Error dialog = new Error();
                    dialog.ErrorText.Text = "Товар не змінено";
                    dialog.Title = "Зміна товару";
                    dialog.Show();
                }
                DB.closeConnection();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditBD();                     
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {  
            this.Hide();


        }
    }
}
