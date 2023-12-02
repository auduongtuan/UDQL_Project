using ShopManagement.Service;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class CustomerListVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public CustomerService CustomerService;
        public PagedResult<Customer> PagedResult { get; set; }
        public string Keyword { get; set; }
        public Visibility ShowResults { get; set; } = Visibility.Collapsed;
        public Visibility ShowLoader { get; set; } = Visibility.Collapsed;
        public CustomerListVM()
        {
            CustomerService = new CustomerService();
            PagedResult = new PagedResult<Customer>()
            {
                CurrentPage = 1,
                PageSize = 10
            };
        }
        public async void LoadList()
        {
            ShowLoader = Visibility.Visible;
            ShowResults = Visibility.Hidden;
            await Task.Run(() =>
            {
                PagedResult = CustomerService.GetListWithPagination(PagedResult.CurrentPage, PagedResult.PageSize, Keyword);
                ShowLoader = Visibility.Collapsed;
                ShowResults = Visibility.Visible;
            });

        }

    }
}
