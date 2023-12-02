using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Utils
{
    public interface IPagedResult
    {
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int PageSize { get; set; }
        int RowCount { get; set; }
        int FirstRowOnPage { get; }
        int LastRowOnPage { get; }
        bool FirstButtonEnabled { get; }
        bool LastButtonEnabled { get; }
        bool PreviousButtonEnabled { get; }
        bool NextButtonEnabled { get; }
    }
    public abstract class PagedResultBase: IPagedResult
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }

        public bool FirstButtonEnabled
        {
            get
            {
                return CurrentPage != 1;
            }
        }

        public bool LastButtonEnabled
        {
            get
            {
                return CurrentPage != PageCount;
            }
        }

        public bool PreviousButtonEnabled
        {
            get
            {
                return CurrentPage > 1;
            }
        }

        public bool NextButtonEnabled
        {
            get
            {
                return CurrentPage < PageCount;
            }
        }
    }

    public class PagedResult<T> : PagedResultBase, IPagedResult, INotifyPropertyChanged where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
    public static class PageExtension
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
