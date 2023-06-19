using System.Linq.Expressions;

namespace RBTB_ServiceAccount.Database.Repositories;

public interface IRepository<BaseEntity>
{
    int Create( BaseEntity item );

    BaseEntity FindById( Guid? id );

    IEnumerable<BaseEntity> Get();

    IEnumerable<BaseEntity> Get( Func<BaseEntity, bool> predicate );

    public bool Any( Func<BaseEntity, bool> predicate );

    int Remove( Guid id );

    int Update( BaseEntity item );

    public IEnumerable<BaseEntity> GetWithInclude( params Expression<Func<BaseEntity, object>>[] includeProperties );

    public IEnumerable<BaseEntity> GetWithInclude( Func<BaseEntity, bool> predicate, params Expression<Func<BaseEntity, object>>[] includeProperties );
}