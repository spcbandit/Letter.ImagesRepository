using System.Linq.Expressions;
using Letter.Infrastructure.Application.Domains.Abstractions;
using Letter.Infrastructure.Application.Domains.Entities;
using Letter.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Letter.Infrastructure.Database.Repositories;

public class ImagesRepository:IRepository<Image>
{
    private readonly DbSet<Image> _db;
    private readonly ImageContext _context;

    public ImagesRepository(ImageContext context)
    {
        _context = context;
        _db = context.Set<Image>();
    }

    public int Create(Image item)
    {
        _db.Add(item);
        return _context.SaveChanges();
    }

    public Image FindById(Guid id)
    {
        return _db.Find(id);
    }

    public IEnumerable<Image> Get()
    {
        return _db.AsNoTracking().ToList();
    }

    public IEnumerable<Image> Get(Func<Image, bool> predicate)
    {
        return _db.AsNoTracking().Where(predicate).ToList();
    }

    public int Remove(Image item)
    {
        _db.Remove(item);
        return _context.SaveChanges();
    }

    public int Update(Image item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public IEnumerable<Image> GetWithInclude(Func<Image, bool> predicate, params Expression<Func<Image, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    public IQueryable<Image> Include(params Expression<Func<Image, object>>[] includeProperties)
    {
        IQueryable<Image> query = _db.AsNoTracking();
        return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }

    public IEnumerable<Image> GetWithInclude(object includeProperty,
        params Expression<Func<Image, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }
}