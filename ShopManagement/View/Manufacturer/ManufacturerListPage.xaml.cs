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
    /// Interaction logic for ManufacturerListPage.xaml
    /// </summary>
    public partial class ManufacturerListPage : Page
    {
        public ManufacturerListVM vm { get; set; }
        public ManufacturerListPage()
        {
            InitializeComponent();
            vm = new ManufacturerListVM();
            DataContext = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer? obj = ((FrameworkElement)sender).DataContext as Manufacturer;
            if (obj == null) return;
            var mvm = new ManufacturerVM(obj);
            mvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            mvm.RecordWindow?.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var mvm = new ManufacturerVM();
            mvm.OnDone += (r) => vm.LoadList();
            mvm.RecordWindow?.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer? obj = ((FrameworkElement)sender).DataContext as Manufacturer;
            if (obj == null) return;
            var mvm = new ManufacturerVM(obj);
            mvm.OnDone += (r) =>
            {
                vm.LoadList();
            };
            mvm.Delete();
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
