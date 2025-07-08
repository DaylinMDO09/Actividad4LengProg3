using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(MateriaViewModel materia)
        {
            if(ModelState.IsValid)
            {
                _context.Materias.Add(materia);
                _context.SaveChanges();
                TempData["Mensaje"] = "Materia registrada satisfactoriamente.";
                return RedirectToAction("Lista");
            }
            return View(materia);
        }

        public IActionResult Lista()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        public IActionResult Editar(string codmateria)
        {
            var materias = _context.Materias.FirstOrDefault(m => m.codMateria == codmateria);
            if(materias == null)
            {
                TempData["Mensaje"] = "No existe la materia indicada.";
                    return RedirectToAction("Lista");

            }

            return View(materias);
        }
        public IActionResult Editar(MateriaViewModel materia)
        {
            if (ModelState.IsValid) {
                var materiaActual = _context.Materias.FirstOrDefault(m => m.codMateria == materia.codMateria);

                if (materiaActual == null)
                {
                    TempData["Mensaje"] = "No existe la materia indicada";
                    return RedirectToAction("Lista");
                }

                materiaActual.nombreMateria = materia.nombreMateria;
                materiaActual.creditoMateria = materia.creditoMateria;
                materiaActual.carreraMateria = materia.carreraMateria;

                _context.Update(materiaActual);
                _context.SaveChanges();

                TempData["Mensaje"] = "Los datos de la materia han sido editados correctamente.";
                return RedirectToAction("Lista");
            
            }
            return View(materia);
        }

        public IActionResult Eliminar(string codmateria)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.codMateria == codmateria);
            if (materia == null)
            {
                _context.Materias.Remove(materia);
                _context.SaveChanges();
                TempData["Mensaje"] = "Materia eliminada satisfactoriamente.";
                return RedirectToAction("Lista");
            }
            return View(materia);
        }

    }
}
