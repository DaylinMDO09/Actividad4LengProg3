using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Debe ingresar su Nombre")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        [Column("nombreEstudiante")]
        public string NombreCompleto { get; set; }

        [Key]
        [Required(ErrorMessage = "Debe ingresar su Matricula")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres.")]
        [Column("matriculaEstudiante")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una carrera")]
        [Column("carreraEstudiante")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Debe ingresar su Correo Institucional")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido.")]
        [Column("correoEstudiante")]
        public string CorreoInstitucional { get; set; }

        [Phone(ErrorMessage = "Debe ingresar un número de teléfono válido.")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener al menos 10 dígitos.")]
        [Column("telefonoEstudiante")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar su Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Column("fechaEstudiante")]
        public DateTime FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Debe seleccionar un género.")]
        [Column("generoEstudiante")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "Debe seleccionar un turno.")]
        [Column("turnoEstudiante")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de ingreso.")]
        [Column("ingresoEstudiante")]
        public string TipoIngreso { get; set; }


        [Column("becaEstudiante")]
        public bool EstaBecado { get; set; }


        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        [Column("porcentajebecaEstudiante")]
        public int? PorcentajeBeca { get; set; }

        //[Required(ErrorMessage = "Debe aceptar los términos y condiciones.")]
        //[Range(typeof(bool), "true", "true")]
        //public string TerminosYCondiciones { get; set; }

        [Required(ErrorMessage = "Debe aceptar los términos y condiciones.")]
        [Column("tcEstudiante")]
        public bool TerminosYCondiciones { get; set; }
    }
}