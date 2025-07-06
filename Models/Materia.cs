using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Materia
{
    public string Codigomateria { get; set; } = null!;

    public string Nombremateria { get; set; } = null!;

    public int Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
