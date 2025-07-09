using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengProg3.Models
{
    public class CalificacionViewModel
    {
        [Key]
        [Column("IDCALIFICACION")]
        public int idCalificacion { get; set; }

        [Required(ErrorMessage = "Debe indicar la matricula para calificar al estudiante.")]
        [Column("MATRICULAESTUDIANTE")]
        [Display(Name = "Matricula del estudiante")]
        public string matriculaEstudiante { get; set; }

        [Required(ErrorMessage ="Debe indicar el código de la materia para calificar al estudiante.")]
        [Column ("CODIGOMATERIA")]
        [Display(Name = "Código de la materia")]
        public string codMateria { get; set; }

        [Required(ErrorMessage = "Debes introducir una nota para calificar el estudiante.")]
        [Range (0, 100, ErrorMessage = "La nota debe estar en un rango de 0 a 100 puntos.")]
        [Column("NOTA")]
        [Display (Name = "Nota del estudiante")]
        public decimal? notaEstudiante { get; set; }

        [Required(ErrorMessage = "Debes seleccionar el periodo")]
        [Column("PERIODO")]
        [Display(Name = "Periodo")]
        public string periodoEstudiante { get; set; }
    }
}
