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
    public class UserRepository : IUserRepository
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

        public UserRepository()
        {
            _context = new EFContext();
        }

        public User Find(Expression<Func<User, bool>> query)
        {
            return _context.Users.FirstOrDefault(query);
        }

        public IPagedList<User> FindAll(int pageIndex)
        {
            return _context.Users.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<User> FindAll(Expression<Func<User, bool>> query)
        {
            return _context.Users.Where(query);
        }

        public IEnumerable<User> FindAll()
        {
            return _context.Users;
        }

        public void Save(User entity)
        {
            if (entity.UserId > 0)
            {
                _context.Users.Attach(entity);
                _context.Entry<User>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Users.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Attach(entity);
            _context.Entry<User>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
