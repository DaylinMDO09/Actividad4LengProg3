using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengProg3.Models.ViewModels
{
    public class EstudianteFormViewModel
    {
        public Estudiante Estudiante { get; set; } = new();

        public SelectList carreras { get; set; } = default!;
        public SelectList turnos { get; set; } = default!;
        public SelectList ingresos { get; set; } = default!;


    }
}
