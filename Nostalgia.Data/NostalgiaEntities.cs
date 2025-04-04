using Nostalgia.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nostalgia.Data;

public class NostalgiaEntities : DbContext
{
    public DbSet<Cosa> Cosas { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Nostalgia;User Id=sa;Password=Cosa@2025;");
     }
}