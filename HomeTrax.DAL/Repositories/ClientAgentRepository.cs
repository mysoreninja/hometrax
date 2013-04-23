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
    public class ClientAgentRepository : IClientAgentRepository
    {
        private EFContext _context;
        public ClientAgentRepository()
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

        public ClientAgent Find(Expression<Func<ClientAgent, bool>> query)
        {
            return _context.ClientAgents.FirstOrDefault(query);
        }

        public IPagedList<ClientAgent> FindAll(int pageIndex)
        {
            return _context.ClientAgents.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<ClientAgent> FindAll(Expression<Func<ClientAgent, bool>> query)
        {
            return _context.ClientAgents.Where(query);
        }

        public IEnumerable<ClientAgent> FindAll()
        {
            return _context.ClientAgents;
        }

        public void Save(ClientAgent entity)
        {
            if (entity.ClientAgentId > 0)
            {
                _context.ClientAgents.Attach(entity);
                _context.Entry<ClientAgent>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.ClientAgents.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(ClientAgent entity)
        {
            _context.ClientAgents.Attach(entity);
            _context.Entry<ClientAgent>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
