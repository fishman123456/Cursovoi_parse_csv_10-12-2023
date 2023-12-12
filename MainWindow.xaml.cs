using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Cursovoi_parse_csv_10_12_2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddToDataBase addToData = new AddToDataBase();
        ListBox list = new ListBox();
        string strings = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            CheckDateWork.CheckDate();


        }
        ObservableCollection<string> m_osstrProgress;  // To attach to the listbox.  
        private void buttOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            openFileCSV openFilecsv = new openFileCSV();
            openFilecsv.openFileDialogAsync(list);
            lbFiles.Text = openFilecsv.filenameGO;
            lbTextFiles.Text = openFilecsv.line;
            strings = openFilecsv.line;
            addToData.metodAddDB(strings);
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttAddStrDB_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
