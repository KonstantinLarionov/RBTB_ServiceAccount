using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Database.Repositories;

public class WalletRepository : IRepository<WalletEntity>
{
    private readonly DbSet<WalletEntity> _dbSet;
    private readonly ServiceAccountContext _context;
    public WalletRepository( ServiceAccountContext context )
    {
        _context = context;
        _dbSet = context.Set<WalletEntity>();
    }

    public IEnumerable<WalletEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<WalletEntity> Get( Func<WalletEntity, bool> predicate )
    {
        return _dbSet.AsNoTracking().Where( predicate ).ToList();
    }

    public bool Any( Func<WalletEntity, bool> predicate )
    {
        throw new NotImplementedException();
    }

    public WalletEntity FindById( Guid? id )
    {
        return _dbSet.Find( id );
    }

    public int Create( WalletEntity item )
    {
        _dbSet.Add( item );
        return _context.SaveChanges();
    }

    public int Update( WalletEntity item )
    {
        _context.Entry( item ).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Remove( Guid id )
    {
        var item = _dbSet.Find( id );
        if ( item != null )
        {
            _dbSet.Remove( item );
            return _context.SaveChanges();
        }

        return 0;
    }

    public IEnumerable<WalletEntity> GetWithInclude( params Expression<Func<WalletEntity, object>>[] includeProperties )
    {
        return Include( includeProperties ).ToList();
    }

    public IEnumerable<WalletEntity> GetWithInclude( Func<WalletEntity, bool> predicate,
        params Expression<Func<WalletEntity, object>>[] includeProperties )
    {
        var query = Include( includeProperties );
        return query.Where( predicate ).ToList();
    }

    public WalletEntity GetWithIncludeWithoutRelatedEntities( Guid Id )
    {
        throw new NotImplementedException();
    }

    private IQueryable<WalletEntity> Include( params Expression<Func<WalletEntity, object>>[] includeProperties )
    {
        IQueryable<WalletEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
    }
}