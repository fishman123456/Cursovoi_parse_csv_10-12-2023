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

namespace Cursovoi_parse_csv_10_12_2023
{
    // открываем файл csv для чтения
    public class openFileCSV
    {
        public ObservableCollection<string> csv;
        public string filenameGO;
        public string openFileDialog(ListBox lbFiles)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    lbFiles.Items.Add(Path.GetFileName(filename));
                    filenameGO = filename;
                }
            }
            return filenameGO;
        }
    }
}
