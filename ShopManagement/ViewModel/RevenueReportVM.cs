using FluentDateTime;
using ShopManagement.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace ShopManagement.ViewModel
{
    public class RevenueReportVM : INotifyPropertyChanged
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public BindingList<ProductWithRevenue> Products { get; set; }
        public ProductService ProductService { get; set; }
        public Visibility ShowResults { get; set; } = Visibility.Collapsed;
        public Visibility ShowLoader { get; set; } = Visibility.Collapsed;
        public bool IsLoading { get; set; }
        public double TotalRevenue { get; set; }
        public RevenueReportVM()
        {
            From = DateTime.Today.FirstDayOfMonth();
            To = DateTime.Today.LastDayOfMonth();
            ProductService = new ProductService();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async void LoadList()
        {
            ShowLoader = Visibility.Visible;
            await Task.Run(() =>
            {
                var products = ProductService.GetListBetweenTimeRange(From, To);
                TotalRevenue = products.Aggregate((double)0, (acc, x) => acc + x.Revenue);
                Products = new BindingList<ProductWithRevenue>(products);
                ShowLoader = Visibility.Collapsed;
                ShowResults = Visibility.Visible;
            });

        }

    }
}
