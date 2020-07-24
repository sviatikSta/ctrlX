using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace CtrlX
{
    class Excel
    {
        public Excel()
        {

        }
        string path = "";
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[Sheet];
        }
        public void Write()
        {
            string connectionString = @"server = localhost; port = 3306; user = root; password = root; database = ctrlxxx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;

            excel.Visible = true;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM products", connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ws.Cells[1, 1] = "ID";
                    ws.Cells[1, 2] = "Назва";
                    ws.Cells[1, 3] = "Категорія";
                    ws.Cells[1, 4] = "Рік випуску";
                    ws.Cells[1, 5] = "Гарантія";
                    ws.Cells[1, 6] = "К-сть одиниць";
                    ws.Cells[1, 7] = "Ціна";
                    ws.Cells[1, 8] = "Постачальник";
                    ws.Cells[1, 9] = "Номер постачальника";
                    ws.Cells[1, 10] = "Дата поставки";
                    ws.Cells[1, 11] = "Номер складу";
                    ws.Cells[1, 12] = "Опис" ;
                    ws.Cells[1, 13] = "Примітки";
                    ws.Columns[1].ColumnWidth = 7;
                    ws.Rows[1].RowHeight = 21;
                    ws.Columns[2].ColumnWidth = 15;
                    ws.Columns[3].ColumnWidth = 15;
                    ws.Columns[4].ColumnWidth = 15;
                    ws.Columns[5].ColumnWidth = 18;
                    ws.Columns[6].ColumnWidth = 20;
                    ws.Columns[7].ColumnWidth = 13;
                    ws.Columns[8].ColumnWidth = 17;
                    ws.Columns[9].ColumnWidth = 21;
                    ws.Columns[10].ColumnWidth = 17;
                    ws.Columns[11].ColumnWidth = 21;
                    ws.Columns[12].ColumnWidth = 17;
                    ws.Columns[13].ColumnWidth = 21;
                    ws.ClearArrows();
                    ws.get_Range("A2", "M100").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    ws.get_Range("A1", "M1").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    ws.get_Range("A1", "M1").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    ws.get_Range("A1", "M1").Interior.Color = XlRgbColor.rgbLightBlue;
                    ws.get_Range("A1", "M1").Cells.Font.Bold = true;
                   

                    int i = 2;
                    while (reader.Read())
                    {
                        ws.Cells[i, 1] = (string)reader.GetValue(0);
                        ws.Cells[i, 2] = (string)reader.GetValue(1);
                        ws.Cells[i, 3] = (string)reader.GetValue(2);
                        ws.Cells[i, 4] = (string)reader.GetValue(3);
                        ws.Cells[i, 5] = (string)reader.GetValue(4);
                        ws.Cells[i, 6] = (string)reader.GetValue(5);
                        ws.Cells[i, 7] = (string)reader.GetValue(6);
                        ws.Cells[i, 8] = (string)reader.GetValue(7);
                        ws.Cells[i, 9] = "моб. " + reader.GetValue(8).ToString();
                        ws.Cells[i, 10] = (string)reader.GetValue(9);
                        ws.Cells[i, 11] = (string)reader.GetValue(10);
                        ws.Cells[i, 12] = (string)reader.GetValue(11);
                        ws.Cells[i, 13] = (string)reader.GetValue(12);
                        var cells = ws.get_Range("A1", "M" + i); 
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // внутренние вертикальные
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // внутренние горизонтальные            
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // правая внешняя
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // левая внешняя
                    cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        i++;

                    }
                }
                else
                { }


                reader.Close();

                connection.Close();
            }
        }
            public void Create()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }
    }
}