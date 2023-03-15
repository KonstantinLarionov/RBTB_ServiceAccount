using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Database.Repositories;

public class PositionsRepository:IRepository<Positions>
{
    private readonly DbSet<Positions> _dbSet;
    private readonly RBTB_Context _context;
    public PositionsRepository(RBTB_Context context)
        {
            _context = context;
            _dbSet = context.Set<Positions>();
        }

        public IEnumerable<Positions> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Positions> Get(Func<Positions, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<Positions, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Positions FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(Positions item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(Positions item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(Positions item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<Positions> GetWithInclude(params Expression<Func<Positions, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Positions> GetWithInclude(Func<Positions, bool> predicate,
            params Expression<Func<Positions, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public Positions GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Positions> Include(params Expression<Func<Positions, object>>[] includeProperties)
        {
            IQueryable<Positions> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
}