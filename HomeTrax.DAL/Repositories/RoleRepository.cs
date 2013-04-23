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
    public class RoleRepository : IRoleRepository
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

        public RoleRepository()
        {
            _context = new EFContext();
        }

        public Role Find(Expression<Func<Role, bool>> query)
        {
            return _context.Roles.FirstOrDefault(query);
        }

        public IPagedList<Role> FindAll(int pageIndex)
        {
            return _context.Roles.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Role> FindAll(Expression<Func<Role, bool>> query)
        {
            return _context.Roles.Where(query);
        }

        public IEnumerable<Role> FindAll()
        {
            return _context.Roles;
        }

        public void Save(Role entity)
        {
            if (entity.RoleId > 0)
            {
                _context.Roles.Attach(entity);
                _context.Entry<Role>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Roles.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _context.Roles.Attach(entity);
            _context.Entry<Role>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
