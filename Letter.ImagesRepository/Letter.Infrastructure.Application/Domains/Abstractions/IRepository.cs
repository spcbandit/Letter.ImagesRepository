using Letter.Infrastructure.Application.Domains.Entities;

namespace Letter.Infrastructure.Application.Domains.Abstractions;

public interface IRepository<TEntity> where TEntity:class
{
    int Create(TEntity item);
    
}