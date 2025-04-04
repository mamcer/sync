using Nostalgia.Core.Entities;

namespace Nostalgia.Core.Interfaces;

public interface IRecipeRepository : IRepository<Cosa, int>
{
    IEnumerable<Cosa> GetAll();
    int GetCount();
}