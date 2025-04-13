using Nostalgia.Core.Entities;

namespace Nostalgia.Core.Interfaces;

public interface ICosaService 
{
    public Cosa AddCosa(Cosa cosa);
    public int GetCosaCount(); 
    public IEnumerable<Cosa> GetAllCosas(); 
}