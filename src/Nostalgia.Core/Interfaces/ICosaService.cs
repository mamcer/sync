namespace Nostalgia.Core.Interfaces;

using Nostalgia.Core.Entities;

public interface ICosaService 
{
    public Cosa AddCosa(Cosa cosa);
    public int GetCosaCount(); 
    public IEnumerable<Cosa> GetAllCosas(); 
}