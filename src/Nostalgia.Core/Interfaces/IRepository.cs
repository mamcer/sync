namespace Nostalgia.Core.Interfaces;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    TEntity GetById(TKey id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}