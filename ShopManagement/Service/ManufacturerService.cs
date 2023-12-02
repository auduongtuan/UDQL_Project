using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Service
{
    public class ManufacturerService : BaseService<Manufacturer>, IService<Manufacturer>
    {
        public override DbSet<Manufacturer> GetDbSet(UdqlInventoryContext context)
        {
            return context.Manufacturers;
        }
        public PagedResult<Manufacturer> GetListWithPagination(int page, int pageSize, string keyword = "")
        {
            using (var context = new UdqlInventoryContext())
            {
                var baseResult = GetDbSet(context)
                    .Include(b => b.Products);
                if (keyword.IsNullOrEmpty()) return baseResult.GetPaged(page, pageSize);
                string k = keyword.ToLower();
                return baseResult.Where(p => p.Name.ToLower().Contains(k))
                                 .GetPaged(page, pageSize);

            }
        }
        public List<Manufacturer> GetListWithProductCount()
        {
            using (var context = new UdqlInventoryContext())
            {
                // context.SetLogging();
                // Lấy danh sách các sản phẩm trong bảng 
                var records = GetDbSet(context).Include(b => b.Products).ToList();

                return records;
            }
        }
    }
}
