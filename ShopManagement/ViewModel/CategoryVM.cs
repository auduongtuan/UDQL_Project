using ShopManagement.Service;
using ShopManagement.View;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class CategoryVM : BaseVM<Category>
    {
  
        //public CategoryAddWindow addWindow { get; set; }
        public CategoryVM(Category? category = null)
        {
            if (category != null)
            {
                Record = (Category) category.Clone();
                RecordWindow = new CategoryRecordWindow(this);
                RecordWindow.Title = "Edit Category";
                IsEditing = true;
            }
            else
            {
                Record = new Category();
                RecordWindow = new CategoryRecordWindow(this);
                RecordWindow.Title = "New Category";
                IsEditing = false;
            }
            Service = new CategoryService();
        }      
    }
}
