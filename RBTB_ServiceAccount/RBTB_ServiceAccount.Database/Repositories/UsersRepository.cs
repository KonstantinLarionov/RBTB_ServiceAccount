using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Database.Repositories;

public class UsersRepository : IRepository<Users>
{
    private readonly DbSet<Users> _dbSet;
        private readonly RBTB_Context _context;
        public UsersRepository(RBTB_Context context)
        {
            _context = context;
            _dbSet = context.Set<Users>();
        }

        public IEnumerable<Users> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Users> Get(Func<Users, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<Users, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Users FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(Users item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(Users item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(Users item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<Users> GetWithInclude(params Expression<Func<Users, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Users> GetWithInclude(Func<Users, bool> predicate,
            params Expression<Func<Users, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public Users GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Users> Include(params Expression<Func<Users, object>>[] includeProperties)
        {
            IQueryable<Users> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
}