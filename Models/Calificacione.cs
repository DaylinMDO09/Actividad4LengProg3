using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Calificacione
{
    public int Idcalificacion { get; set; }

    public string Matriculaestudiante { get; set; } = null!;

    public string Codigomateria { get; set; } = null!;

    public decimal Nota { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual Materia CodigomateriaNavigation { get; set; } = null!;

    public virtual Estudiante MatriculaestudianteNavigation { get; set; } = null!;
}
