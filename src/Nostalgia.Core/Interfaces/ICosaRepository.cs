using Nostalgia.Core.Entities;

namespace Nostalgia.Core.Interfaces;

public interface ICosaRepository : IRepository<Cosa, int>
{
    IEnumerable<Cosa> GetAll();
    int GetCount();
}