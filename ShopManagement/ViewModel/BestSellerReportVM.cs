using FluentDateTime;
using ShopManagement.Service;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopManagement.ViewModel
{
    public class BestSellerReportVM: INotifyPropertyChanged
    {

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public BindingList<ProductWithSold> BestSellers { get; set; }
        public ProductService ProductService { get; set; }
        public Visibility ShowResults { get; set; } = Visibility.Collapsed;
        public Visibility ShowLoader { get; set; } = Visibility.Collapsed;
        public bool IsLoading { get; set; }
        public double TotalRevenue { get; set; }
        // https://stackoverflow.com/questions/1317891/simple-wpf-radiobutton-binding
        private bool[] _modeArray = new bool[] { true, false, false };
        public bool[] ModeArray
        {
            get { return _modeArray; }
        }
        public int SelectedMode
        {
            get { return Array.IndexOf(_modeArray, true); }
        }
        public BestSellerReportVM()
        {
            
            ProductService = new ProductService();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void UpdateTimeRange()
        {
            Debug.WriteLine("Selected mode is " + SelectedMode);
            if (SelectedMode == 0)
            {
                From = DateTime.Today.FirstDayOfWeek();
                To = DateTime.Today.LastDayOfWeek();
            }
            else if (SelectedMode == 1)
            {
                From = DateTime.Today.FirstDayOfMonth();
                To = DateTime.Today.LastDayOfMonth();
            }
            else
            {
                From = DateTime.Today.FirstDayOfYear();
                To = DateTime.Today.LastDayOfYear();
            }
        }
        public async void LoadList()
        {
            ShowLoader = Visibility.Visible;
            await Task.Run(() =>
            {
                BestSellers = new BindingList<ProductWithSold>(ProductService.GetBestSellers(From, To));
                ShowLoader = Visibility.Collapsed;
                ShowResults = Visibility.Visible;
            });
        }
    }
   
}
