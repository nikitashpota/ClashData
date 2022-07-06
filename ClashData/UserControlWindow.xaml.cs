using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using static ClashExcelExport.TestExportToExcel;

namespace ClashData
{
    /// <summary>
    /// Логика взаимодействия для UserControlWindow.xaml
    /// </summary>
    public partial class UserControlWindow
    {
        public string NameZone { get; set; } = new string(new char[] { });
        public Dictionary<string, string> Returnpd { get; set; } = new Dictionary<string, string>();

        private static UserControlWindow _instance;
        public BackgroundWorker worker = new BackgroundWorker();
        public static UserControlWindow Get()
        {
            if (_instance == null)
                _instance = new UserControlWindow();
            
            return _instance;
        }

        private UserControlWindow()
        {
            InitializeComponent();
            
            btnZoneAccept.Click += (sender, args) =>
            {
                if(inputZoneName.Text.Length > 0)
                {
                    NameZone = inputZoneName.Text;
                    zoneNameResult.Text = "Имя зоны: " + NameZone;
                    inputZoneName.Text = "";
                }
            };

            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private void inputZoneName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextBox inputZoneName = (TextBox)sender;
            //NameZone = inputZoneName.Text;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                txtBoxEditor.Text = File.ReadAllText(openFileDialog.FileName);
                
                var discipline = File.ReadAllLines(openFileDialog.FileName);
                int i = 0;
                foreach (var line in discipline)
                {
                    if(line == "--")
                    {
                        var item1 = discipline[i + 1];
                        var item2 = discipline[i + 2];

                        Returnpd.Add(item1, item2);
                    }
                    i++;

                }

            }
                
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var testExport = new ClashExcelExport.TestExportToExcel();

            if (NameZone == "")
            {
                MessageBox.Show("Ввести наименование зоны");
                Close();
            }
            else if(Returnpd.Count == 0)
            {
                MessageBox.Show("Загрузити разделы");
                Close();
            }
            else testExport.Execute(new string[] { });

            Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }

    }
}
