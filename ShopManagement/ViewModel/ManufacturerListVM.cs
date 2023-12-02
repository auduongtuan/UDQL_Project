using ShopManagement.Service;
using ShopManagement.Utils;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class ManufacturerListVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public ManufacturerService ManufacturerService;
        public PagedResult<Manufacturer> PagedResult { get; set; }
        public string Keyword { get; set; }
        public Visibility ShowResults { get; set; } = Visibility.Collapsed;
        public Visibility ShowLoader { get; set; } = Visibility.Collapsed;
        public ManufacturerListVM()
        {
            ManufacturerService = new ManufacturerService();
            PagedResult = new PagedResult<Manufacturer>()
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
                PagedResult = ManufacturerService.GetListWithPagination(PagedResult.CurrentPage, PagedResult.PageSize, Keyword);
                ShowLoader = Visibility.Collapsed;
                ShowResults = Visibility.Visible;
            });

        }

    }
}
