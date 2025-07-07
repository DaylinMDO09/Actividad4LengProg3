using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EstudianteViewModel> Estudiantes { get; set; }
    }
}
