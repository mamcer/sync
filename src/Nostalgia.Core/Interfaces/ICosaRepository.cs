namespace Nostalgia.Core.Interfaces;

using Nostalgia.Core.Entities;

public interface ICosaRepository : IRepository<Cosa, int>
{
    IEnumerable<Cosa> GetAll();
    int GetCount();
}