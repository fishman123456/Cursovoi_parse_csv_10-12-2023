using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Cursovoi_parse_csv_10_12_2023
{
    // открываем файл csv для чтения
    public class openFileCSV
    {
        public List<string> csv = new List<string>();
        public string filenameGO;
        public string line;
        public void openFileDialogAsync(ListBox lbFiles)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string s = String.Empty;
            if (openFileDialog.ShowDialog() == true)
            {
                lbFiles.Items.Add(System.IO.Path.GetFileName(openFileDialog.FileName));
                filenameGO = openFileDialog.FileName;
                StreamReader reader = new StreamReader(filenameGO);
                line = reader.ReadToEnd();
                // разделитель по строкам для заполнения списка
                string[] separator = { "\n" };
                // добавляем данные в список из текстбокса TextBox_Lay_name 
                string[] stringFile = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    // цикл для заполнения списка
                    foreach (var item in stringFile)
                    {
                        // добавляем данные из строки в список. Список потом п разделителя ";"
                        // будем добавлять в базу данных
                        csv.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { }
            }
        }
    }
}
