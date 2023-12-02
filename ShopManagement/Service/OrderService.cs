using FluentDateTime;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShopManagement.Service
{
    public class OrderService : BaseService<Order>, IService<Order>
    {
        public override DbSet<Order> GetDbSet(UdqlInventoryContext context)
        {
            return context.Orders;
        }
        public PagedResult<Order> GetListWithPagination(int page, int pageSize, string keyword = "")
        {
            using (var context = new UdqlInventoryContext())
            {
                var baseResult = GetDbSet(context)
                    .Include(b => b.Customer)
                    .Include(d => d.OrderDetails);
                if (keyword.IsNullOrEmpty()) return baseResult.GetPaged(page, pageSize);
                string k = keyword.ToLower();
                return baseResult.Where(p => p.Customer.Name.ToLower().Contains(k) || p.Customer.Address.ToLower().Contains(k))
                                 .GetPaged(page, pageSize);

            }
        }

        public List<Order> GetNewestWithDetails(int limit = 10)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context)
                    .OrderBy(c => c.CreatedDate)
                    .Include(b => b.Customer)
                    .Include(d => d.OrderDetails)
                    .Take(limit)
                    .ToList();
                return records;
            }
        }

        public List<Order> GetActiveListWithDetails()
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context)
                    .Where(o => o.ShippedDate == null)
                    .Include(b => b.Customer)
                    .Include(d => d.OrderDetails)
                    .ToList();

                return records;
            }
        }

        public double GetRevenueByMonth(DateTime month)
        {
            DateTime from = month.FirstDayOfMonth();
            DateTime to = month.LastDayOfMonth();
            var records = GetListByTimeRange(from, to);
            return GetRevenueOfOrders(records);
        }

        public double GetRevenueOfOrders(List<Order> orders)
        {
            double r = 0;
            foreach (var order in orders)
            {
                foreach (var detail in order.OrderDetails)
                {
                    r += detail.Price * detail.Quantity;
                }
            }
            return r;
        }
        public List<Order> GetListByTimeRange(DateTime from, DateTime to)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context)
                    .Where(o => o.CreatedDate > from && o.CreatedDate < to)
                    .Include(d => d.OrderDetails)
                    .ToList();
                return records;
            }
        }

        public bool UpdateOrAddWithDetails(Order record, IList<OrderDetail>? details = null)
        {
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    var entity = context.Orders.Include(s => s.OrderDetails).FirstOrDefault(s => s.Id == record.Id);
                    if (entity == null)
                    {
                        entity = (Order)record.Clone();
                        context.Orders.Add(entity);
                    }
                    else
                    {
                        context.Entry(entity).CurrentValues.SetValues(record);
                        entity.OrderDetails.Clear();
                    }
                    if (details != null)
                    {
                        foreach (var detail in details)
                        {
                            entity.OrderDetails.Add(detail);
                        }
                    }
                    context.SaveChanges();
                    ProductService productService = new ProductService();
                    foreach (var detail in entity.OrderDetails)
                    {
                        productService.UpdateSoldById(detail.ProductId);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return false;
            }
        }
        public int CountActive()
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context).Where(o => o.ShippedDate == null).Count();
                return records;
            }
        }

    }


}
