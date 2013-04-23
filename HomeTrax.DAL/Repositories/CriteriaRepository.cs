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
    public class CriteriaRepository : ICriteriaRepository
    {
        private EFContext _context;
        public CriteriaRepository()
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

        public Criteria Find(Expression<Func<Criteria, bool>> query)
        {
            return _context.Criterias.FirstOrDefault(query);
        }

        public IPagedList<Criteria> FindAll(int pageIndex)
        {
            return _context.Criterias.OrderByDescending(p => p.CreatedDate).ToPagedList(pageIndex, this.RecordsPerPage);
        }

        public IEnumerable<Criteria> FindAll(Expression<Func<Criteria, bool>> query)
        {
            return _context.Criterias.Where(query);
        }

        public IEnumerable<Criteria> FindAll()
        {
            return _context.Criterias;
        }

        public void Save(Criteria entity)
        {
            if (entity.CriteriaId > 0)
            {
                _context.Criterias.Attach(entity);
                _context.Entry<Criteria>(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                _context.Criterias.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(Criteria entity)
        {
            _context.Criterias.Attach(entity);
            _context.Entry<Criteria>(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
