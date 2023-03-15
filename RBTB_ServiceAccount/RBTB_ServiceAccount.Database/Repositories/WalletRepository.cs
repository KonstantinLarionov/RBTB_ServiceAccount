using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Database.Repositories;

public class WalletRepository:IRepository<Wallet>
{
    private readonly DbSet<Wallet> _dbSet;
        private readonly RBTB_Context _context;
        public WalletRepository(RBTB_Context context)
        {
            _context = context;
            _dbSet = context.Set<Wallet>();
        }

        public IEnumerable<Wallet> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Wallet> Get(Func<Wallet, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public bool Any(Func<Wallet, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Wallet FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }

        public int Create(Wallet item)
        {
            _dbSet.Add(item);
            return _context.SaveChanges();
        }
        public int Update(Wallet item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Remove(Wallet item)
        {
            _dbSet.Remove(item);
            return _context.SaveChanges();
        }

        public IEnumerable<Wallet> GetWithInclude(params Expression <Func<Wallet, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Wallet> GetWithInclude(Func<Wallet, bool> predicate,
            params Expression<Func<Wallet, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public Wallet GetWithIncludeWithoutRelatedEntities(Guid Id)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Wallet> Include(params Expression<Func<Wallet, object>>[] includeProperties)
        {
            IQueryable<Wallet> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
}