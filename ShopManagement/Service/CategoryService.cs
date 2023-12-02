using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Service
{
    public class CategoryService : BaseService<Category>, IService<Category>
    {
        public override DbSet<Category> GetDbSet(UdqlInventoryContext context)
        {
            return context.Categories;
        }
        public List<Category> GetListWithCount()
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context).Include(b => b.Products).ToList();

                return records;
            }
        }
        public Dictionary<int, int> TotalSalesInMonth()
        {
            using (var context = new UdqlInventoryContext())
            {
                var date = DateTime.Today;
                var ordersInMonth = context.Orders
                    .Where(o => o.CreatedDate.Year == date.Year
    && o.CreatedDate.Month == date.Month)
                    .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                    .ToList();
                Dictionary<int, int> statistics = new Dictionary<int, int>();
                foreach (var order in ordersInMonth)
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        if (orderDetail.Product.CategoryId != null)
                        {
                            var catId = (int)orderDetail.Product.CategoryId;
                            if (!statistics.ContainsKey(catId))
                            {
                                statistics.Add(catId, 0);
                            }
                            statistics[catId] += orderDetail.Quantity;
                        }
                    }
                }
                return statistics;
            }
        }
    }
}
