using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El nombre del estudiante es necesario")]
        [StringLength(100)]
        [Column("nombreEstudiante")]
        [Display(Name = "Nombre completo")]
        public string nombreEstudiante { get; set; }

        [Key]
        [Required(ErrorMessage = "Debe ingresar su Matricula")]
        [StringLength(15, MinimumLength = 6)]
        [Column("matriculaEstudiante")]
        [Display(Name = "Matricula")]
        public string matriculaEstudiante { get; set; }

        [Required(ErrorMessage = "Debe elegir una carrera")]
        [Column("carreraEstudiante")]
        [Display(Name = "Carrera")]
        public string carreraEstudiante { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        [Column("correoEstudiante")]
        [Display(Name = "Correo institucional")]
        public string correoEstudiante { get; set; }

        [Phone(ErrorMessage = "El número telefónico es obligatorio")]
        [MinLength(10)]
        [Column("telefonoEstudiante")]
        [Display(Name = "Número telefónico")]
        public string telefonoEstudiante { get; set; }

        [Required(ErrorMessage = "Debe indicar su fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Column("fechaEstudiante")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? fechaEstudiante { get; set; }


        [Required]
        [Column("generoEstudiante")]
        [Display(Name = "Género")]
        public string generoEstudiante { get; set; }


        [Required(ErrorMessage = "Debes elegir un turno.")]
        [Column("turnoEstudiante")]
        [Display(Name = "Turnos")]
        public string turnoEstudiante { get; set; }

        [Required(ErrorMessage = "Elige tu tipo de ingreso.")]
        [Column("ingresoEstudiante")]
        [Display(Name = "Tipo de ingreso")]
        public string ingresoEstudiante { get; set; }


        [Column("becaEstudiante")]
        [Display(Name = "¿Eres becado?")]
        public bool becaEstudiante { get; set; }


        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        [Column("porcentajebecaEstudiante")]
        [Display(Name = "Porcentaje de la beca (en caso de tener beca): ")]        
        public int? porcentajebecaEstudiante { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Debes aceptar los términos y condiciones de la institución.")]
        [Column("tcEstudiante")]
        [Display(Name = "Acepto los terminos y condiciones.")]
        public bool tcEstudiante { get; set; }
    }
}