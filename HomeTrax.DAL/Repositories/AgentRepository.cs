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
    public class AgentRepository : IAgentRepository
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

        public AgentRepository()
        {
            _context = new EFContext();
        }

        public Agent Find(Expression<Func<Agent, bool>> query)
        {
            return _context.Agents.FirstOrDefault(query);
        }

        public IPagedList<Agent> FindAll(int pageIndex)
        {
            return _context.Agents.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Agent> FindAll(Expression<Func<Agent, bool>> query)
        {
            return _context.Agents.Where(query);
        }

        public IEnumerable<Agent> FindAll()
        {
            return _context.Agents;
        }

        public void Save(Agent entity)
        {
            if (entity.AgentId > 0)
            {
                _context.Agents.Attach(entity);
                _context.Entry<Agent>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Agents.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Agent entity)
        {
            _context.Agents.Attach(entity);
            _context.Entry<Agent>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
