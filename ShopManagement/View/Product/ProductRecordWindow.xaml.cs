using ShopManagement.ViewModel;
using System.Windows;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductRecordWindow : Window
    {
        private ProductVM productVM;
        public ProductRecordWindow(ProductVM _productVM)
        {
            InitializeComponent();
            productVM = _productVM;
            DataContext = productVM.Record;
            manufacturerCombobox.ItemsSource = productVM?.ManufacturerService.GetList();
            categoryCombobox.ItemsSource = productVM?.CategoryService.GetList();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            productVM.UpdateOrAdd();
            this.Close();
        }
    }
}
