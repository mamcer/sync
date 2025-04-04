using Nostalgia.Core.Entities;

namespace Nostalgia.Core.Interfaces;

public interface ICosaService 
{
    public int GetCosaCount(); 
    public IEnumerable<Cosa> GetAllCosas(); 
}