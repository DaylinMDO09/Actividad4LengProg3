﻿using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EstudianteViewModel> Estudiantes { get; set; }
        public DbSet<MateriaViewModel> Materias { get; set; }
        public DbSet<CalificacionViewModel> Calificaciones { get; set; }
    }
}
