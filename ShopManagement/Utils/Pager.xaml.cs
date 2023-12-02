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

namespace ShopManagement.Utils
{
    /// <summary>
    /// Interaction logic for Pager.xaml
    /// </summary>
    public partial class Pager : UserControl 
    {
        public event EventHandler PageChanged;
        public static readonly DependencyProperty PagedResultProperty =
                   DependencyProperty.Register(
                         "PagedResult",
                          typeof(IPagedResult),
                          typeof(Pager));

        public IPagedResult PagedResult
        {
            get { return (IPagedResult) GetValue(PagedResultProperty); }
            set { SetValue(PagedResultProperty, value); }
        }
        
        public Pager()
        {
            InitializeComponent();
        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            PagedResult.CurrentPage = PagedResult.PageCount;
            if (PageChanged != null) PageChanged(this, EventArgs.Empty);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PagedResult.CurrentPage = PagedResult.CurrentPage + 1;
            if (PageChanged != null) PageChanged(this, EventArgs.Empty);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            PagedResult.CurrentPage = PagedResult.CurrentPage - 1;
            if (PageChanged != null) PageChanged(this, EventArgs.Empty);
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            PagedResult.CurrentPage = 1;
            if (PageChanged != null) PageChanged(this, EventArgs.Empty);
        }
    }
}
