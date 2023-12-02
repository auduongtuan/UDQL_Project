using ShopManagement.ViewModel;
using System.Windows;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for ManufacturerEditWindow.xaml
    /// </summary>
    public partial class ManufacturerRecordWindow : Window
    {
        private ManufacturerVM manuManufacturerVM;
        public ManufacturerRecordWindow(ManufacturerVM _manuManufacturerVM)
        {
            InitializeComponent();
            manuManufacturerVM = _manuManufacturerVM;
            DataContext = manuManufacturerVM.Record;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            manuManufacturerVM.UpdateOrAdd();
            this.Close();
        }
    }
}
