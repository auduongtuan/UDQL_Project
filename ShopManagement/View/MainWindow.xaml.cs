using ShopManagement.ViewModel;
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

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVM vm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            DataContext = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Db.IsConnected)
                {
                Close();
                var loginScreen = new LoginWindow();
                loginScreen.Show();
            }
             
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.SaveTabIndex();
        }
    }
}
