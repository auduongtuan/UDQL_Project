using ShopManagement.Service;
using ShopManagement.View;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class CustomerVM : BaseVM<Customer>
    {

        //public CustomerAddWindow addWindow { get; set; }
        public CustomerVM(Customer? customer = null)
        {
            if (customer != null)
            {
                Record = (Customer) customer.Clone();
                RecordWindow = new CustomerRecordWindow(this);
                RecordWindow.Title = "Edit Customer";
                IsEditing = true;
            }
            else
            {
                Record = new Customer();
                RecordWindow = new CustomerRecordWindow(this);
                RecordWindow.Title = "New Customer";
                IsEditing = false;
            }
            Service = new CustomerService();
        }
    }
}
