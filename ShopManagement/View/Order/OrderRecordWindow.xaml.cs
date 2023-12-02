using MaterialDesignThemes.Wpf;
using ShopManagement.ViewModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShopManagement.View
{
    /// <summary>
    /// Interaction logic for OrderEditWindow.xaml
    /// </summary>
    public partial class OrderRecordWindow : Window
    {
        private OrderVM orderVM;
        public OrderRecordWindow(OrderVM _orderVM)
        {
            InitializeComponent();
            orderVM = _orderVM;
            DataContext = orderVM;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            orderVM.UpdateOrAddWithDetails();
            Debug.WriteLine(orderVM.Record.CustomerId);
            Debug.WriteLine(orderVM.Record.ReceiptAddress);
            Debug.WriteLine(orderVM.Record.CreatedDate);
            Debug.WriteLine(orderVM.Record.ShippedDate);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            customerComboBox.ItemsSource = orderVM.CustomerService.GetList();
            productCombobox.ItemsSource = new BindingList<Product>(orderVM.ProductService.GetList());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddItem(object sender, RoutedEventArgs e)
        {
            orderVM.AddNewDetail();
        }
        private void ProductComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var orderDetail =  ((FrameworkElement)sender).DataContext as OrderDetail;
            Debug.WriteLine("orderDetail " + orderDetail?.ProductId);
            var comboBox = sender as ComboBox;
            Debug.WriteLine(comboBox?.SelectedIndex);
            if (orderDetail == null || comboBox == null)
            {
                Debug.WriteLine("Null order detail or combobox");
            }
            Product? selected = comboBox?.SelectedItem as Product;
            if (selected != null)
            {
                var orderDetailR = orderVM.OrderDetails.First(o => o.ProductId == orderDetail?.ProductId);
                if (orderDetailR != null)
                {
                    Debug.WriteLine("Order ne " + orderDetailR.ProductId);
                    orderDetailR.Price = (double) selected.Price;
                }
            } else
            {
                Debug.WriteLine("Selected is null");
            }
        }
    }
}
