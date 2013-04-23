using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;
using HomeTrax.BLL.Interfaces;
using HomeTrax.BLL;


namespace HomeTrax.DAL.Repositories
{
    public class ClientPropertyRepository : IClientPropertyRepository
    {
        private EFContext _context;
        public ClientPropertyRepository()
        {
            _context = new EFContext();
        }

        public int RecordsPerPage
        {
            get { return 10; }
        }

        public int RowsPerSection
        {
            get { return 5; }
        }

        public ClientProperty Find(Expression<Func<ClientProperty, bool>> query)
        {
            return _context.ClientProperties.FirstOrDefault(query);
        }

        public IPagedList<ClientProperty> FindAll(int pageIndex)
        {
            return _context.ClientProperties.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<ClientProperty> FindAll(Expression<Func<ClientProperty, bool>> query)
        {
            return _context.ClientProperties.Where(query);
        }

        public IEnumerable<ClientProperty> FindAll()
        {
            return _context.ClientProperties;
        }

        public void Save(ClientProperty entity)
        {
            if (entity.ClientPropertyId > 0)
            {
                _context.ClientProperties.Attach(entity);
                _context.Entry<ClientProperty>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.ClientProperties.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(ClientProperty entity)
        {
            _context.ClientProperties.Attach(entity);
            _context.Entry<ClientProperty>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
