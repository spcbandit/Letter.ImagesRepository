using System.Linq.Expressions;
using Letter.Infrastructure.Application.Domains.Entities;

namespace Letter.Infrastructure.Application.Domains.Abstractions;

public interface IRepository<TEntity> where TEntity:class
{
    int Create(TEntity item);
    TEntity FindById(Guid id);
    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    int Remove(TEntity item);
    int Update(TEntity item);

    IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);

}