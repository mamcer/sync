namespace Cookbook.Data;

using Nostalgia.Core.Entities;
using Nostalgia.Core.Interfaces;
using Nostalgia.Data;

public class CosaRepository : EntityFrameworkRepository<Cosa, int>, ICosaRepository
{
    public CosaRepository(NostalgiaEntities context) : base(context)
    {
    }

    public IEnumerable<Cosa> GetAll()
    {
        return _context.Set<Cosa>();
    }

    public int GetCount()
    {
        return _context.Set<Cosa>().Count();
    }
}