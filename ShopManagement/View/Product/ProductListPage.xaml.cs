using ShopManagement.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagement.View
{
    public partial class ProductListPage : Page
    {
        public ProductListVM vm { get; set; }
        public ProductListPage()
        {
            InitializeComponent();
            vm = new ProductListVM();
            DataContext = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var pvm = new ProductVM();
            pvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            pvm.RecordWindow?.Show();
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Product? obj = ((FrameworkElement)sender).DataContext as Product;
            if (obj == null) return;
            var pvm = new ProductVM(obj);
            pvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            pvm.RecordWindow?.Show();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Product? obj = ((FrameworkElement)sender).DataContext as Product;
            if (obj == null) return;
            var pvm = new ProductVM(obj);
            pvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            pvm.Delete();
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
