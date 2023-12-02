using ShopManagement.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public DashboardVM vm;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new DashboardVM();
            DataContext = vm;
        }

      

        private void OrderItem_Clicked(object sender, MouseButtonEventArgs e)
        {

            Order? obj = ((FrameworkElement)sender).DataContext as Order;
            if (obj == null) return;
            var ovm = new OrderVM(obj);
            ovm.OnDone += (r) =>
            {
                //LoadList();
                Debug.WriteLine("Load newest orders");
                vm.InitNewestOrders();
            };
            ovm?.RecordWindow.Show();
        }
    }
}
