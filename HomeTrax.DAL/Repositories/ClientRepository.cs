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
    public class ClientRepository : IClientRepository
    {
        private EFContext _context;
        public ClientRepository()
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

        public Client Find(Expression<Func<Client, bool>> query)
        {
            return _context.Clients.FirstOrDefault(query);
        }

        public IPagedList<Client> FindAll(int pageIndex)
        {
            return _context.Clients.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Client> FindAll(Expression<Func<Client, bool>> query)
        {
            return _context.Clients.Where(query);
        }

        public IEnumerable<Client> FindAll()
        {
            return _context.Clients;
        }

        public void Save(Client entity)
        {
            if (entity.ClientId > 0)
            {
                _context.Clients.Attach(entity);
                _context.Entry<Client>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Clients.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Client entity)
        {
            _context.Clients.Attach(entity);
            _context.Entry<Client>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
