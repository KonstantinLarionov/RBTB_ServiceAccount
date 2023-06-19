using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Database.Entities;

namespace RBTB_ServiceAccount.Database.Repositories;

public class UsersRepository : IRepository<UserEntity>
{
    private readonly DbSet<UserEntity> _dbSet;
    private readonly ServiceAccountContext _context;
    public UsersRepository( ServiceAccountContext context )
    {
        _context = context;
        _dbSet = context.Set<UserEntity>();
    }

    public IEnumerable<UserEntity> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public IEnumerable<UserEntity> Get( Func<UserEntity, bool> predicate )
    {
        return _dbSet.AsNoTracking().Where( predicate ).ToList();
    }

    public bool Any( Func<UserEntity, bool> predicate )
    {
        throw new NotImplementedException();
    }

    public UserEntity FindById( Guid? id )
    {
        return _dbSet.Find( id );
    }

    public int Create( UserEntity item )
    {
        _dbSet.Add( item );
        return _context.SaveChanges();
    }
    public int Update( UserEntity item )
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

    public IEnumerable<UserEntity> GetWithInclude( params Expression<Func<UserEntity, object>>[] includeProperties )
    {
        return Include( includeProperties ).ToList();
    }

    public IEnumerable<UserEntity> GetWithInclude( Func<UserEntity, bool> predicate,
        params Expression<Func<UserEntity, object>>[] includeProperties )
    {
        var query = Include( includeProperties );
        return query.Where( predicate ).ToList();
    }

    public UserEntity GetWithIncludeWithoutRelatedEntities( Guid Id )
    {
        throw new NotImplementedException();
    }

    private IQueryable<UserEntity> Include( params Expression<Func<UserEntity, object>>[] includeProperties )
    {
        IQueryable<UserEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
    }
}