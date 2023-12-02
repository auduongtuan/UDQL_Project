using ShopManagement.Service;
using ShopManagement.ViewModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace ShopManagement
{
    /// <summary>
    /// Interaction logic for OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        private OrderService OrderService { get; set; }
        public OrderListVM vm { get; set; }
        public OrderListPage()
        {
            InitializeComponent();
            OrderService = new OrderService();
            vm = new OrderListVM();
            DataContext = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Order? obj = ((FrameworkElement)sender).DataContext as Order;
            if (obj == null) return;
            var ovm = new OrderVM(obj);
            ovm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            ovm?.RecordWindow.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var ovm = new OrderVM();
            ovm.OnDone += (r) => vm.LoadList();
            ovm?.RecordWindow.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Order? obj = ((FrameworkElement)sender).DataContext as Order;
            if (obj == null) return;
            var ovm = new OrderVM(obj);
            ovm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            ovm.Delete();
        }
        private void CurrentPage_Changed(object sender, System.EventArgs e)
        {
            vm.LoadList();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            vm.PagedResult.CurrentPage = 1;
            vm.LoadList();
        }
    }
}
