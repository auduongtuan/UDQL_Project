using System.ComponentModel;

namespace ShopManagement.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int TabIndex { get; set; }
        public MainWindowVM()
        {
            AppConfig.LoadInfo();
            if (AppConfig.LastTabIndex != -1)
            {
                TabIndex = AppConfig.LastTabIndex;
            }
            else
            {
                TabIndex = 0;
            }
        }
        public void SaveTabIndex()
        {
            AppConfig.LastTabIndex = TabIndex;
            AppConfig.SaveInfo();
        }
    }
}
