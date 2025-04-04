namespace Nostalgia.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
}
