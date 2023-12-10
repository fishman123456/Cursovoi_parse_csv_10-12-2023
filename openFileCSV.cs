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

namespace Cursovoi_parse_csv_10_12_2023
{
    // открываем файл csv для чтения
    public class openFileCSV
    {
        public List<string> csv;
        public string filenameGO;
        public string line;
        public async Task<string> openFileDialogAsync(ListBox lbFiles)
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
                reader.Close();
            }

            return filenameGO;
        }
    }
}
