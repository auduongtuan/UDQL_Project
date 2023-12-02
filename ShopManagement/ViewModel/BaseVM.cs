using ShopManagement.Service;
using ShopManagement.View;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public abstract class BaseVM<T> where T: BaseEntity
    {
        public T Record { get; set; }
        public bool IsEditing { get; set; }
        public Window? RecordWindow { get; set; }
        //public BaseAddWindow addWindow { get; set; }
        public IService<T>? Service { get; set; }
        public delegate void OnDoneHandler(T record);
        public event OnDoneHandler? OnDone;
        //public BaseVM(T? _record = null)
        //{
        //    if (_record != null)
        //    {
        //        record = _record;
        //        recordWindow = GetRecordWindow(this);
        //        recordWindow.Title = "Edit Base";
        //        isEditing = true;
        //    }
        //    else
        //    {
        //        record = new T();
        //        recordWindow = new BaseRecordWindow(this);
        //        recordWindow.Title = "New Base";
        //        isEditing = false;
        //    }
        //    service = new BaseService();
        //}
        public void UpdateOrAdd()
        {
            if (IsEditing)
            {
                Update();
            }
            else
            {
                Add();
            }
        }
        public void Update()
        {
            if (Record != null && Record.Id > 0)
            {
                Service?.Update(Record);
                RecordWindow?.Close();
                OnDone?.Invoke(Record);
            }
        }
        public void RunOnDone()
        {
            OnDone?.Invoke(Record);
        }
        public void Add()
        {
            if (Record != null)
            {
                Service?.Add(Record);
                RecordWindow?.Close();
                RunOnDone();
            }
        }
        public void Delete()
        {
            // MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete {record?.Name}?", "Delete confirmation", MessageBoxButton.YesNo);
            MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete?", "Delete confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes && Service != null)
            {
                bool deleteSuccess = Service.Delete(Record.Id);
                if (deleteSuccess)
                {
                    OnDone?.Invoke(Record);
                }
                else
                {
                    MessageBox.Show("Error occured. Cannot delete.");
                }
            }
        }
    }
}
