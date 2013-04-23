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
    public class AgentPropertyRepository : IAgentPropertyRepository
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

        public AgentPropertyRepository()
        {
            _context = new EFContext();
        }

        public AgentProperty Find(Expression<Func<AgentProperty, bool>> query)
        {
            return _context.AgentProperties.FirstOrDefault(query);
        }

        public IPagedList<AgentProperty> FindAll(int pageIndex)
        {
            return _context.AgentProperties.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<AgentProperty> FindAll(Expression<Func<AgentProperty, bool>> query)
        {
            return _context.AgentProperties.Where(query);
        }

        public IEnumerable<AgentProperty> FindAll()
        {
            return _context.AgentProperties;
        }

        public void Save(AgentProperty entity)
        {
            if (entity.AgentPropertyId > 0)
            {
                _context.AgentProperties.Attach(entity);
                _context.Entry<AgentProperty>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.AgentProperties.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(AgentProperty entity)
        {
            _context.AgentProperties.Attach(entity);
            _context.Entry<AgentProperty>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
