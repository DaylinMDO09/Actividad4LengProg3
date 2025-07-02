using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Carrera
{
    public int Idcarrera { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
