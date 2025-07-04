﻿using Actividad4LengProg3.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiante> ESTUDIANTES { get; set; }
        //public DbSet<Materia> MATERIAS { get; set; }
        //public DbSet<Calificacion> CALIFICACIONES { get; set; }
    }
}