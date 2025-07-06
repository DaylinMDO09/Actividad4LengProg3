using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Estudiante
{
    public int Idestudiante { get; set; }

    public string Nombrecompleto { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public string Correoinstitucional { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime Fechanac { get; set; }

    public string Genero { get; set; } = null!;

    public string Turno { get; set; } = null!;

    public string Tipoingreso { get; set; } = null!;

    public bool Estabecado { get; set; }

    public int? Porcentajebeca { get; set; }

    public bool Terminosycondiciones { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
