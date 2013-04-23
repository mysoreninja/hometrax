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
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private EFContext _context;
        public int RecordsPerPage
        {
            get { return 10; }
        }

        public int RowsPerSection
        {
            get { return 5; }
        }

        public PropertyTypeRepository()
        {
            _context = new EFContext();
        }

        public PropertyType Find(Expression<Func<PropertyType, bool>> query)
        {
            return _context.PropertyTypes.FirstOrDefault(query);
        }

        public IPagedList<PropertyType> FindAll(int pageIndex)
        {
            return _context.PropertyTypes.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<PropertyType> FindAll(Expression<Func<PropertyType, bool>> query)
        {
            return _context.PropertyTypes.Where(query);
        }

        public IEnumerable<PropertyType> FindAll()
        {
            return _context.PropertyTypes;
        }

        public void Save(PropertyType entity)
        {
            if (entity.PropertyTypeId > 0)
            {
                _context.PropertyTypes.Attach(entity);
                _context.Entry<PropertyType>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.PropertyTypes.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(PropertyType entity)
        {
            _context.PropertyTypes.Attach(entity);
            _context.Entry<PropertyType>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
