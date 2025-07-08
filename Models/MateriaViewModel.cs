using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Debe introducir un código de identificación para registrar esta materia.")]
        [StringLength(20)]
        [Column("CODIGOMATERIA")]
        [Display(Name = "Código de la materia")]
        public string codMateria { get; set; }

        [Required(ErrorMessage = "Ingresar nombre para esta materia.")]
        [StringLength(100)]
        [Column("NOMBREMATERIA")]
        [Display(Name = "Nombre de la materia")]
        public string nombreMateria { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "El credito debe estar entre 1 y 4.")]
        [Column("CREDITOS")]
        [Display(Name = "Créditos de la materia")]
        public int? creditoMateria { get; set; }

        [Required(ErrorMessage = "Debes elegir una carrera para esta materia.")]
        [StringLength(100)]
        [Column("CARRERA")]
        [Display(Name = "Carreras")]
        public string carreraMateria { get; set; }
    }
}
