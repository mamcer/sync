using Nostalgia.Core.Entities;

namespace Nostalgia.Core.Interfaces;

public interface IRecipeService 
{
    public int GetCosaCount(); 
    public IEnumerable<Cosa> GetAllCosas(); 
}