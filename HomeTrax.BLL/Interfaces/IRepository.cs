using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace HomeTrax.BLL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        int RecordsPerPage { get; }
        int RowsPerSection { get; }
        T Find(Expression<Func<T, bool>> query);
        IPagedList<T> FindAll(int pageIndex);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> query);
        void Save(T entity);
        void Delete(T entity);
    }
}
