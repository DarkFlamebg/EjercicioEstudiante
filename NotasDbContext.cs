using Microsoft.EntityFrameworkCore;

namespace M12.NotasEf;

public class NotasDbContext : DbContext
{
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=notas.db");
    }
}
