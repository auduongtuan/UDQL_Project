using ShopManagement.ViewModel;
using System.Windows;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for CustomerEditWindow.xaml
    /// </summary>
    public partial class CustomerRecordWindow : Window
    {
        private CustomerVM customerVM;
        public CustomerRecordWindow(CustomerVM _customerVM)
        {
            InitializeComponent();
            customerVM = _customerVM;
            DataContext = customerVM.Record;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            customerVM.UpdateOrAdd();
            this.Close();
        }
    }
}
