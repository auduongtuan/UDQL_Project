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
    public class CustomerService : BaseService<Customer>, IService<Customer>
    {
        public override DbSet<Customer> GetDbSet(UdqlInventoryContext context)
        {
            return context.Customers;
        }
        public PagedResult<Customer> GetListWithPagination(int page, int pageSize, string keyword = "")
        {
            using (var context = new UdqlInventoryContext())
            {
                var baseResult = GetDbSet(context)
                    .Include(b => b.Orders);
                if (keyword.IsNullOrEmpty()) return baseResult.GetPaged(page, pageSize);
                string k = keyword.ToLower();
                return baseResult.Where(c => 
                    c.Name.ToLower().Contains(k) ||
                    c.Address.ToLower().Contains(k) ||
                    c.Phone.ToLower().Contains(k)
                ).GetPaged(page, pageSize);
            }
        }
    }
}
