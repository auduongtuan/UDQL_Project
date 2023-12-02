using ShopManagement.Service;
using ShopManagement.View;

namespace ShopManagement.ViewModel
{
    public class ProductVM : BaseVM<Product>
    {

        public CategoryService CategoryService { get; set; }
        public ManufacturerService ManufacturerService { get; set; }
        public ProductVM(Product? product = null)
        {
            Service = new ProductService();
            CategoryService = new CategoryService();
            ManufacturerService = new ManufacturerService();
            if (product != null)
            {
                Record = (Product)product.Clone();
                RecordWindow = new ProductRecordWindow(this);
                RecordWindow.Title = "Edit Product";
                IsEditing = true;
            }
            else
            {
                Record = new Product();
                RecordWindow = new ProductRecordWindow(this);
                RecordWindow.Title = "New Product";
                IsEditing = false;
            }
        }
    }
}
