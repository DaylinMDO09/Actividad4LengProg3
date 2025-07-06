using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models;

public partial class BdMdoContext : DbContext
{
    public BdMdoContext(DbContextOptions options) : base(options) { }
    
    //public DbSet<Calificacione> Calificaciones { get; set; }

    public DbSet<EstudianteViewModel> Estudiantes { get; set; }

    //public DbSet<Materia> Materias { get; set; }

}
