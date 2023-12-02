using ShopManagement.ViewModel;
using System.Windows;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for CategoryEditWindow.xaml
    /// </summary>
    public partial class CategoryRecordWindow : Window
    {
        private CategoryVM categoryVM;
        public CategoryRecordWindow(CategoryVM _categoryVM)
        {
            InitializeComponent();
            categoryVM = _categoryVM;
            DataContext = categoryVM.Record;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            categoryVM.UpdateOrAdd();
            this.Close();
        }
    }
}
