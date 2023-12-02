using ShopManagement.Service;
using ShopManagement.View;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class ManufacturerVM : BaseVM<Manufacturer>
    {

        public ManufacturerVM(Manufacturer? manufacturer = null)
        {
            if (manufacturer != null)
            {
                Record = (Manufacturer) manufacturer.Clone();
                RecordWindow = new ManufacturerRecordWindow(this);
                RecordWindow.Title = "Edit Manufacturer";
                IsEditing = true;
            }
            else
            {
                Record = new Manufacturer();
                RecordWindow = new ManufacturerRecordWindow(this);
                RecordWindow.Title = "New Manufacturer";
                IsEditing = false;
            }
            Service = new ManufacturerService();
        }
    }
}
