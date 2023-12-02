using ShopManagement.Service;
using ShopManagement.Utils;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class OrderListVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public OrderService OrderService;
        public PagedResult<Order> PagedResult { get; set; }
        public string Keyword { get; set; }
        public Visibility ShowResults { get; set; } = Visibility.Collapsed;
        public Visibility ShowLoader { get; set; } = Visibility.Collapsed;
        public OrderListVM()
        {
            OrderService = new OrderService();
            PagedResult = new PagedResult<Order>()
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
                PagedResult = OrderService.GetListWithPagination(PagedResult.CurrentPage, PagedResult.PageSize, Keyword);
                ShowLoader = Visibility.Collapsed;
                ShowResults = Visibility.Visible;
            });

        }

    }
}
