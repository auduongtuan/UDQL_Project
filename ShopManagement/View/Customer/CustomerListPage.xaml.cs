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
    /// Interaction logic for CustomerListPage.xaml
    /// </summary>
    public partial class CustomerListPage : Page
    {
        public CustomerListVM vm { get; set; }
        public CustomerListPage()
        {
            InitializeComponent();
            vm = new CustomerListVM();
            DataContext = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Customer? obj = ((FrameworkElement)sender).DataContext as Customer;
            if (obj == null) return;
            var cvm = new CustomerVM(obj);
            cvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            cvm.RecordWindow.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var cvm = new CustomerVM();
            cvm.OnDone += (r) => vm.LoadList();
            cvm.RecordWindow.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Customer? obj = ((FrameworkElement)sender).DataContext as Customer;
            if (obj == null) return;
            var cvm = new CustomerVM(obj);
            cvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            cvm.Delete();
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
