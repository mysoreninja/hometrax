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
    public class PropertyRepository : IPropertyRepository
    {
        private EFContext _context;
        public PropertyRepository()
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

        public Property Find(Expression<Func<Property, bool>> query)
        {
            return _context.Properties.FirstOrDefault(query);
        }

        public IPagedList<Property> FindAll(int pageIndex)
        {
            return _context.Properties.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Property> FindAll(Expression<Func<Property, bool>> query)
        {
            return _context.Properties.Where(query);
        }

        public IEnumerable<Property> FindAll()
        {
            return _context.Properties;
        }

        public void Save(Property entity)
        {
            if (entity.PropertyId > 0)
            {
                _context.Properties.Attach(entity);
                _context.Entry<Property>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Properties.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Property entity)
        {
            _context.Properties.Attach(entity);
            _context.Entry<Property>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
