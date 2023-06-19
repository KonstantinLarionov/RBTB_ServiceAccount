using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Database.Entities;

namespace RBTB_ServiceAccount.Database.Repositories;

public class PositionsRepository : IRepository<PositionEntity>
{
    private readonly DbSet<PositionEntity> _dbSet;
    private readonly ServiceAccountContext _context;

    public PositionsRepository( ServiceAccountContext context )
    {
        _context = context;
        _dbSet = context.Set<PositionEntity>();
    }

    public IEnumerable<PositionEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<PositionEntity> Get( Func<PositionEntity, bool> predicate )
    {
        return _dbSet.AsNoTracking().Where( predicate ).ToList();
    }

    public bool Any( Func<PositionEntity, bool> predicate )
    {
        throw new NotImplementedException();
    }

    public PositionEntity FindById( Guid? id )
    {
        return _dbSet.Find( id );
    }

    public int Create( PositionEntity item )
    {
        _dbSet.Add( item );
        return _context.SaveChanges();
    }
    public int Update( PositionEntity item )
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

    public IEnumerable<PositionEntity> GetWithInclude( params Expression<Func<PositionEntity, object>>[] includeProperties )
    {
        return Include( includeProperties ).ToList();
    }

    public IEnumerable<PositionEntity> GetWithInclude( Func<PositionEntity, bool> predicate,
        params Expression<Func<PositionEntity, object>>[] includeProperties )
    {
        var query = Include( includeProperties );
        return query.Where( predicate ).ToList();
    }

    public PositionEntity GetWithIncludeWithoutRelatedEntities( Guid Id )
    {
        throw new NotImplementedException();
    }

    private IQueryable<PositionEntity> Include( params Expression<Func<PositionEntity, object>>[] includeProperties )
    {
        IQueryable<PositionEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
    }
}