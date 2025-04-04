using Nostalgia.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nostalgia.Data;

public class NostalgiaEntities : DbContext
{
    public NostalgiaEntities(DbContextOptions<NostalgiaEntities> options) : base(options)
    {
    }

    public DbSet<Cosa> Cosas { get; set; }
}