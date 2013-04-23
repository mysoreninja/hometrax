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
    public class UserRoleRepository : IUserRoleRepository
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

        public UserRoleRepository()
        {
            _context = new EFContext();
        }

        public UserRole Find(Expression<Func<UserRole, bool>> query)
        {
            return _context.UserRoles.FirstOrDefault(query);
        }

        public IPagedList<UserRole> FindAll(int pageIndex)
        {
            return _context.UserRoles.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<UserRole> FindAll(Expression<Func<UserRole, bool>> query)
        {
            return _context.UserRoles.Where(query);
        }

        public IEnumerable<UserRole> FindAll()
        {
            return _context.UserRoles;
        }

        public void Save(UserRole entity)
        {
            if (entity.UserRoleId > 0)
            {
                _context.UserRoles.Attach(entity);
                _context.Entry<UserRole>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.UserRoles.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(UserRole entity)
        {
            _context.UserRoles.Attach(entity);
            _context.Entry<UserRole>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
