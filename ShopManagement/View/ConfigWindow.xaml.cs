using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ShopManagement
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {

        public string Server { get; set; }
        public string Database { get; set; }
        public ConfigWindow()
        {
            Server = "";
            Database = "";
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppConfig.LoadAuthentication();
            Debug.WriteLine(AppConfig.Server);
            Debug.WriteLine(AppConfig.Database);
            Server = AppConfig.Server;
            Database = AppConfig.Database;
            DataContext = this;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConfig.Server = Server;
                AppConfig.Database = Database;
                AppConfig.SaveAuthentication();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
