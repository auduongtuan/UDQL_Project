using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Service
{
    public interface IService<T> where T: class, IBaseEntity
    {
        DbSet<T> GetDbSet(UdqlInventoryContext context);
        bool Delete(int id);
        bool Update(T record);

        int? Add(T record);
        List<T> GetList();
    }
    public abstract class BaseService<T>: IService<T> where T: class, IBaseEntity
    {
        public abstract DbSet<T> GetDbSet(UdqlInventoryContext context);
        public bool Delete(int id)
        {
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    var singleRec = GetDbSet(context).FirstOrDefault(x => x.Id == id);// object your want to delete
                    if (singleRec == null) return false;
                    GetDbSet(context).Remove(singleRec);
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
        public virtual bool Update(T record)
        {
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    var entity = GetDbSet(context).FirstOrDefault(s => s.Id == record.Id);
                    if (entity == null) return false;
                    context.Entry(entity).CurrentValues.SetValues(record);
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
        public int? Add(T record)
        {
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    GetDbSet(context).Add(record);
                    context.SaveChanges();
                    return record.Id;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public List<T> GetList()
        {
            using (var context = new UdqlInventoryContext())
            {
                // context.SetLogging();
                // Lấy danh sách các sản phẩm trong bảng 
                var records = GetDbSet(context).ToList();
                return records;
            }
        }

        public List<T> GetNewest(int limit = 10)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context)
                    .OrderBy(c => c.CreatedDate)
                    .Take(limit)
                    .ToList();
                return records;
            }
        }

        public int CountAll()
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context).Count();
                return records;
            }
        }

        public PagedResult<T> GetPage(int page, int pageSize)
        {
            using (var context = new UdqlInventoryContext())
            {
                var records = GetDbSet(context).GetPaged(page, pageSize);
                return records;
            }
        }
    }
}
