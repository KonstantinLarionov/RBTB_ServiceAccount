using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Database.Repositories;

public class TradesRepository : IRepository<TradeEntity>
{
    private readonly DbSet<TradeEntity> _dbSet;
    private readonly ServiceAccountContext _context;
    public TradesRepository( ServiceAccountContext context )
    {
        _context = context;
        _dbSet = context.Set<TradeEntity>();
    }

    public IEnumerable<TradeEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<TradeEntity> Get( Func<TradeEntity, bool> predicate )
    {
        return _dbSet.AsNoTracking().Where( predicate ).ToList();
    }

    public bool Any( Func<TradeEntity, bool> predicate )
    {
        throw new NotImplementedException();
    }

    public TradeEntity FindById( Guid? id )
    {
        return _dbSet.Find( id );
    }

    public int Create( TradeEntity item )
    {
        _dbSet.Add( item );
        return _context.SaveChanges();
    }
    public int Update( TradeEntity item )
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


    public IEnumerable<TradeEntity> GetWithInclude( params Expression<Func<TradeEntity, object>>[] includeProperties )
    {
        return Include( includeProperties ).ToList();
    }

    public IEnumerable<TradeEntity> GetWithInclude( Func<TradeEntity, bool> predicate,
        params Expression<Func<TradeEntity, object>>[] includeProperties )
    {
        var query = Include( includeProperties );
        return query.Where( predicate ).ToList();
    }

    public TradeEntity GetWithIncludeWithoutRelatedEntities( Guid Id )
    {
        throw new NotImplementedException();
    }

    private IQueryable<TradeEntity> Include( params Expression<Func<TradeEntity, object>>[] includeProperties )
    {
        IQueryable<TradeEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
    }
}