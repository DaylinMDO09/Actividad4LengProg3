using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models;

public partial class Estudiante
{
    public int Idestudiante { get; set; }
    [Required(ErrorMessage = "El nombre del estudiante es obligatorio")]
    [StringLength(100)]
    [Display(Name = "Nombre Completo")]
    public string Nombrecompleto { get; set; } = null!;
    [Required(ErrorMessage = "La matrícula es obligatoria")]
    [StringLength(15, MinimumLength = 6)]
    public string Matricula { get; set; } = null!;
    [Required(ErrorMessage ="Debe seleccionar una carrera")]
    public string Carrera { get; set; } = null!;
    [Required(ErrorMessage = "El correo institucional es obligatorio")]
    [EmailAddress (ErrorMessage = "Correo no valido")]
    [Display (Name = "Correo institucional")]
    public string Correoinstitucional { get; set; } = null!;
    [Phone]
    [MinLength (10)]
    public string Telefono { get; set; }
    [Required (ErrorMessage = "Debe indicar su fecha de nacimiento")]
    [DataType (DataType.Date)]
    public DateTime Fechanac { get; set; }
    [Required]
    public string Genero { get; set; } = null!;
    [Required]
    public string Turno { get; set; } = null!;
    [Required(ErrorMessage = "Elige el tipo de ingreso")]
    [Display (Name = "Tipo de ingreso")]
    public string Tipoingreso { get; set; } = null!;
    
    public bool Estabecado { get; set; }
    [Range (0,100)]
    public int? Porcentajebeca { get; set; }
    [Range(typeof(bool), "true", "true", ErrorMessage = "Debes aceptar los terminos y condiciones de esta institucion.")]
    public bool Terminosycondiciones { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Carrera IdcarreraNavigation { get; set; } = null!;
}
