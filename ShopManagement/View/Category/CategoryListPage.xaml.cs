using ShopManagement.Service;
using ShopManagement.ViewModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace ShopManagement
{
    /// <summary>
    /// Interaction logic for CategoryListPage.xaml
    /// </summary>
    public partial class CategoryListPage : Page
    {
        public BindingList<Category> Categories { get; set; } = new BindingList<Category>();
        private CategoryService categoryService { get; set; }
        public CategoryListPage()
        {
            InitializeComponent();
            categoryService = new CategoryService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
            DataContext = this;
        }

        public void LoadList()
        {
            Categories = new BindingList<Category>(categoryService.GetListWithCount());
            Categories.ResetBindings();
            //Categories.Count.ResetBinding();
            dataGrid.ItemsSource = Categories;
            listCounter.Text = Categories.Count.ToString();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Category? obj = ((FrameworkElement)sender).DataContext as Category;
            if (obj == null) return;
            var vm = new CategoryVM(obj);
            vm.OnDone += (r) =>
            {
                LoadList();
            };
            vm.RecordWindow?.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = new CategoryVM();
            vm.OnDone += (r) => LoadList();
            vm.RecordWindow?.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Category? obj = ((FrameworkElement)sender).DataContext as Category;
            if (obj == null) return;
            var vm = new CategoryVM(obj);
            vm.OnDone += (r) =>
            {
                LoadList();
            };
            vm.Delete();
        }
    }
}
