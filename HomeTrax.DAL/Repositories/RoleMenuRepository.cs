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
    public class RoleMenuRepository : IRoleMenuRepository
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

        public RoleMenuRepository()
        {
            _context = new EFContext();
        }

        public RoleMenu Find(Expression<Func<RoleMenu, bool>> query)
        {
            return _context.RoleMenus.FirstOrDefault(query);
        }

        public IPagedList<RoleMenu> FindAll(int pageIndex)
        {
            return _context.RoleMenus.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<RoleMenu> FindAll(Expression<Func<RoleMenu, bool>> query)
        {
            return _context.RoleMenus.Where(query);
        }

        public IEnumerable<RoleMenu> FindAll()
        {
            return _context.RoleMenus;
        }

        public void Save(RoleMenu entity)
        {
            if (entity.RoleMenuId > 0)
            {
                _context.RoleMenus.Attach(entity);
                _context.Entry<RoleMenu>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.RoleMenus.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(RoleMenu entity)
        {
            _context.RoleMenus.Attach(entity);
            _context.Entry<RoleMenu>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
