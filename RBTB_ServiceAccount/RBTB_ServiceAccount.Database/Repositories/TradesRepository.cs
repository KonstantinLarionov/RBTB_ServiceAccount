using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Database.Repositories;

public class TradesRepository:IRepository<Trades>
{
    private readonly DbSet<Trades> _dbSet;
    private readonly RBTB_Context _context;
        public TradesRepository(RBTB_Context context)
        {
            _context = context;
            _dbSet = context.Set<Trades>();
        }

        public IEnumerable<Trades> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Trades> Get(Func<Trades, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<Trades, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Trades FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(Trades item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(Trades item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(Trades item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<Trades> GetWithInclude(params Expression<Func<Trades, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Trades> GetWithInclude(Func<Trades, bool> predicate,
            params Expression<Func<Trades, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public Trades GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Trades> Include(params Expression<Func<Trades, object>>[] includeProperties)
        {
            IQueryable<Trades> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
}