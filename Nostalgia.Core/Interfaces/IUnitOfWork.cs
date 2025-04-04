namespace Cookbook.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
}
