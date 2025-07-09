using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly AppDbContext _context;

        public CalificacionesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Estudiantes = _context.Estudiantes
            .Select(e => new SelectListItem
            {
                Value = e.matriculaEstudiante,
                Text = e.matriculaEstudiante + " - " + e.nombreEstudiante + " - " + e.carreraEstudiante
            }).ToList();

            ViewBag.Materias = _context.Materias
            .Select(m => new SelectListItem
            {
                Value = m.codMateria,
                Text = m.codMateria + " - " + m.nombreMateria
            }).ToList();

            return View(new CalificacionViewModel());
        }


        [HttpPost]
        public IActionResult Calificar(CalificacionViewModel calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Estudiante calificado correctamente.";
                return RedirectToAction("Lista");
            }
            return View("Index", calificacion);
        }

        public IActionResult Lista()
        {
            var calificacion = _context.Calificaciones.ToList();
            return View(calificacion);
        }

        [HttpGet]
        public IActionResult Editar(string idcalificacion)
        {
            var calificacion = _context.Calificaciones.FirstOrDefault(c => c.idCalificacion.ToString() == idcalificacion);
            if (calificacion == null)
            {
                TempData["Mensaje"] = "No existe la nota indicada";
                return RedirectToAction("Lista");
            }
            return View(calificacion);
        }

        [HttpPost]
        public IActionResult Editar(CalificacionViewModel calificacion)
        {
            if (!ModelState.IsValid)
            {
                return View(calificacion);
            }
                var calificacionActual = _context.Calificaciones.FirstOrDefault(c => c.idCalificacion == calificacion.idCalificacion);
                if (calificacionActual == null)
                {
                    TempData["Mensaje"] = "No existe la calificación indicada.";
                    return RedirectToAction("Lista");
                }               
                
                calificacionActual.notaEstudiante = calificacion.notaEstudiante;
                
                _context.Update(calificacionActual);
                _context.SaveChanges();

                TempData["Mensaje"] = "La nota ha sido cambiada correctamente.";
                return RedirectToAction("Lista");            
        }

        public IActionResult Eliminar(int idcalificacion)
        {
            var calificacion = _context.Calificaciones.FirstOrDefault(c => c.idCalificacion == idcalificacion);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "La calificación ha sido eliminada correctamente.";
                return RedirectToAction("Lista");
            }
            return View(calificacion);
        }
    }
}
