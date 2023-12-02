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
using ShopManagement.ViewModel;

namespace ShopManagement.View.Report
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RevenueReportPage : Page
    {
        public RevenueReportVM vm { get; set; }
        public RevenueReportPage()
        {
            InitializeComponent();
            vm = new RevenueReportVM();
            DataContext = vm;
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button clicked");
            vm.LoadList();
        }
    }
}
