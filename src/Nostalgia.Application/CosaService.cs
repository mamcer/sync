using System.Threading.Tasks;
using Nostalgia.Core.Entities;
using Nostalgia.Core.Interfaces;

namespace Nostalgia.Application;

public class CosaService : ICosaService
{
    public CosaService(IUnitOfWork unitOfWork, ICosaRepository cosaRepository)
    {
        UnitOfWork = unitOfWork;
        CosaRepository = cosaRepository;
    }

    public IUnitOfWork UnitOfWork { get; }
    
    public ICosaRepository CosaRepository { get; }

    public Cosa AddCosa(Cosa cosa)
    {
        if (cosa == null)
        {
            throw new ArgumentNullException(nameof(cosa));
        }

        CosaRepository.Add(cosa);
        UnitOfWork.SaveChanges();
        return cosa;
    }

    public IEnumerable<Cosa> GetAllCosas()
    {
        return CosaRepository.GetAll();
    }

    public int GetCosaCount()
    {
        return CosaRepository.GetCount();
    }
}