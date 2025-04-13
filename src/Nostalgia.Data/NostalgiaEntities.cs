using Nostalgia.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nostalgia.Data;

public class NostalgiaEntities : DbContext
{
    public DbSet<Cosa> Cosas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
                    "Server=localhost;Database=nostalgia;User=root;Password=dev;Port=3366",
                    new MySqlServerVersion(new Version(8, 4, 4))
                );
    }
}