using ShopManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManagement.View.Report
{
    /// <summary>
    /// Interaction logic for BestSellerReport.xaml
    /// </summary>
    public partial class BestSellerReportPage : Page
    {
        public BestSellerReportVM vm { get; set; }
        public BestSellerReportPage()
        {
            InitializeComponent();
            vm = new BestSellerReportVM();
            DataContext = vm;
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button clicked");
            vm.LoadList();
        }

        private void ModeChanged(object sender, RoutedEventArgs e)
        {
            vm.UpdateTimeRange();
            vm.LoadList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vm.UpdateTimeRange();
            vm.LoadList();
        }
    }
}
