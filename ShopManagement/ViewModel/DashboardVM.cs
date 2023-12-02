using LiveCharts;
using LiveCharts.Wpf;
using ShopManagement.Service;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ShopManagement.ViewModel
{
    public struct MonthRevenue
    {
        public DateTime Month;
        public double Revenue;
    }

    public class DashboardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ProductService ProductService { get; set; }
        private OrderService OrderService { get; set; }
        private CategoryService CategoryService { get; set; }
        private CustomerService CustomerService { get; set; }
        private ManufacturerService ManufacturerService { get; set; }
        public int TotalProductCount { get; set; }
        public int TotalCategoryCount { get; set; }
        public int TotalManufacturerCount { get; set; }
        public int TotalCustomerCount { get; set; }
        public int TotalOrderCount { get; set; }
        public int ActiveOrderCount { get; set; }
        public BindingList<Order> NewestOrders { get; set; }

        public SeriesCollection SalesInMonthByCategory { get; set; }
        public SeriesCollection RevenuesInRecentMonths { get; set; }
        public string[] RevenuesInRecentMonths_Labels { get; set; }
        public DashboardVM()
        {
            ProductService = new ProductService();
            OrderService = new OrderService();
            CategoryService = new CategoryService();
            ManufacturerService = new ManufacturerService();
            CustomerService = new CustomerService();
            InitTotalStatistics();
            InitNewestOrders();
            InitCategoryStatistics();
            InitRevenuesInRecentMonths();
        }
        public void InitTotalStatistics()
        {
            TotalProductCount = ProductService.CountAll();
            TotalCategoryCount = CategoryService.CountAll();
            TotalManufacturerCount = ManufacturerService.CountAll();
            TotalCustomerCount = CustomerService.CountAll();
            TotalOrderCount = OrderService.CountAll();
            ActiveOrderCount = OrderService.CountActive();
        }
        public void InitNewestOrders()
        {
            NewestOrders = new BindingList<Order>(OrderService.GetNewestWithDetails(10));
        }
        private void InitCategoryStatistics()
        {
            CategoryService = new CategoryService();
            var categories = CategoryService.GetList().ToDictionary(x => x.Id, x => x);
            var CategoryStatistics = CategoryService.TotalSalesInMonth();
            SalesInMonthByCategory = new SeriesCollection();
            foreach (var cat in CategoryStatistics)
            {
                SalesInMonthByCategory.Add(new PieSeries
                {
                    Title = categories[cat.Key].Name,
                    Values = new ChartValues<int> { cat.Value }
                });
            }
        }
        private void InitRevenuesInRecentMonths()
        {
            RevenuesInRecentMonths = new SeriesCollection();
            var monthRevenues = GetRecentMonthRevenues(3);
            Func<double, string> formatFunc = (x) =>
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                return x.ToString("#,###", cul.NumberFormat);
            };
            RevenuesInRecentMonths.Add(new LineSeries
            {
                Title = "Revenue",
                Values = new ChartValues<double>(monthRevenues.Select(mr => mr.Revenue)),
                LineSmoothness = 0,
            });
            RevenuesInRecentMonths_Labels = monthRevenues.Select(mr => mr.Month.ToString("M/yyyy")).ToArray();
        }
        private MonthRevenue[] GetRecentMonthRevenues(int quantityOfMonth)
        {
            DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            MonthRevenue[] monthRevenues = new MonthRevenue[quantityOfMonth];
            for (int i = 0; i < quantityOfMonth; i++)
            {
                var m = currentMonth.AddMonths(-i);
                monthRevenues[quantityOfMonth - 1 - i].Month = m;
                monthRevenues[quantityOfMonth - 1 - i].Revenue = OrderService.GetRevenueByMonth(m);
            }
            return monthRevenues;
        }
    }
}
