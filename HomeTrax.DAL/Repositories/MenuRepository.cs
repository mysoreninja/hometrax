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
    public class MenuRepository : IMenuRepository
    {
        private EFContext _context;
        public MenuRepository()
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

        public Menu Find(Expression<Func<Menu, bool>> query)
        {
            return _context.Menus.FirstOrDefault(query);
        }

        public IPagedList<Menu> FindAll(int pageIndex)
        {
            return _context.Menus.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Menu> FindAll(Expression<Func<Menu, bool>> query)
        {
            return _context.Menus.Where(query);
        }

        public IEnumerable<Menu> FindAll()
        {
            return _context.Menus;
        }

        public void Save(Menu entity)
        {
            if (entity.MenuId > 0)
            {
                _context.Menus.Attach(entity);
                _context.Entry<Menu>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Menus.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Menu entity)
        {
            _context.Menus.Attach(entity);
            _context.Entry<Menu>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
