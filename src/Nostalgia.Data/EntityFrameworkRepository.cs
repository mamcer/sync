namespace Cookbook.Data;

using Nostalgia.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbContext _context;
 
    public EntityFrameworkRepository(DbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
 
    protected DbContext DbContext => _context;
 
    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        DbContext.Set<TEntity>().Add(entity);
    }
 
    public virtual TEntity GetById(TKey id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Entity of type {typeof(TEntity).Name} with key {id} was not found.");
        }

        return entity;
    }
 
    public void Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        DbContext.Set<TEntity>().Attach(entity);
        DbContext.Set<TEntity>().Remove(entity);
    }
 
    public void Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        DbContext.Set<TEntity>().Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
    }
}