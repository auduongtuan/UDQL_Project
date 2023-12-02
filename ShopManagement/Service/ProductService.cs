using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShopManagement.Service
{
    public struct ProductWithSold
    {
        public Product Product { get; set; }
        public int Sold { get; set; }
    }
    public struct ProductWithRevenue
    {
        public Product Product { get; set; }
        public double Revenue { get; set; }
        public int SoldInTimeRange { get; set; }
    }

    public class ProductService : BaseService<Product>, IService<Product>
    {
        public override DbSet<Product> GetDbSet(UdqlInventoryContext context)
        {
            return context.Products;
        }
        public PagedResult<Product> GetListWithPagination(int page, int pageSize, string keyword = "")
        {
            using (var context = new UdqlInventoryContext())
            {
                var baseResult = GetDbSet(context)
                    .Include(m => m.Manufacturer)
                    .Include(m => m.Category);
                if (keyword.IsNullOrEmpty()) return baseResult.GetPaged(page, pageSize);
                string k = keyword.ToLower();
                return baseResult.Where(p => p.Name.ToLower().Contains(k) || p.Manufacturer.Name.ToLower().Contains(k))
                                 .GetPaged(page, pageSize);
            }
        }
        public int GetSoldInTimeRange(Product product, DateTime from, DateTime to)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = context.OrderDetails.Include(od => od.Order).Where(od => od.ProductId == product.Id && od.Order.CreatedDate <= to && od.Order.CreatedDate >= from).ToList();
                int count = 0;
                foreach (var record in records)
                {
                    count += record.Quantity;
                }
                return count;
            }
        }
        public override bool Update(Product product)
        {
            using (var context = new UdqlInventoryContext())
            {
                int sold = 0;
                var details = context.OrderDetails.Where(od => od.ProductId == product.Id).ToList();
                foreach (var detail in details)
                {
                    sold += detail.Quantity;
                }
                product.Sold = sold;
                return base.Update(product);
            }
        }
        public bool UpdateSoldById(int productId)
        {
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    var entity = GetDbSet(context).FirstOrDefault(s => s.Id == productId);
                    if (entity == null) return false;
                    var details = context.OrderDetails.Where(od => od.ProductId == productId).ToList();
                    int sold = 0;
                    foreach (var detail in details)
                    {
                        sold += detail.Quantity;
                    }
                    entity.Sold = sold;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return false;
            }
        }
        public List<ProductWithRevenue> GetListBetweenTimeRange(DateTime from, DateTime to)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context)
                    .Include(m => m.Manufacturer)
                    .Include(m => m.Category)
                    .Include(m => m.OrderDetails.Where(od => od.Order.CreatedDate <= to))
                    .ToList();
                List<ProductWithRevenue> productWithRevenues = new List<ProductWithRevenue>();
                foreach (var record in records)
                {

                    int Sold = 0;
                    double Revenue = 0;
                    foreach (var detail in record.OrderDetails)
                    {
                        Sold += detail.Quantity;
                        Revenue += detail.Price * detail.Quantity;
                    }
                    productWithRevenues.Add(new ProductWithRevenue
                    {
                        Product = record,
                        Revenue = Revenue,
                        SoldInTimeRange = Sold
                    });
                }
                return productWithRevenues.OrderByDescending(x => x.Revenue).ThenByDescending(x => x.Product.CreatedDate).ToList(); ;
            }
        }
        public List<ProductWithSold> GetBestSellers(DateTime from, DateTime to, int limit = 10)
        {
            // https://stackoverflow.com/questions/36866596/group-by-and-select-with-models
            using (var context = new UdqlInventoryContext())
            {
                var topProducts = context.OrderDetails
                    .Include(od => od.Order)
                    .Include(od => od.Product)
                    .Where(od =>
                        od.Order.CreatedDate > from && od.Order.CreatedDate <= to
                    )
                    .GroupBy(x => x.ProductId)
                    .Select(x => new ProductWithSold
                    {
                        Product = x.First().Product,
                        Sold = x.Sum(y => y.Quantity),
                    })
                    .OrderByDescending(x => x.Sold)
                    .Take(limit).ToList();
                return topProducts;
            }
        }
    }
}
