using Actividad4LengProg3.Models;
using Actividad4LengProg3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly BdMdoContext _context;

        public EstudiantesController(BdMdoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var efvm = new EstudianteFormViewModel
            {
                Estudiante = new Estudiante(),
                carreras = new SelectList(new[] { "INGENIERÍA EN SOFTWARE", "ODONTOLOGIA", "ADMINISTRACIÓN DE EMPRESAS", "INGENIERÍA INDUSTRIAL", "ENFERMERÍA" }),
                turnos = new SelectList(new[] { "MATUTINO", "VESPERTINO", "NOCTURNO" }),
                ingresos = new SelectList(new[] { "NUEVO", "REINGRESO", "TRANSFERENCIA", "DOCTORADO O MAESTRÍA" })
            };

            return View(efvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(EstudianteFormViewModel efvm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(efvm.Estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "¡Estudiante registrado exitosamente!";
                return RedirectToAction(nameof(Index));
            }

            efvm.carreras = new SelectList(new[] { "INGENIERÍA EN SOFTWARE", "ODONTOLOGIA", "ADMINISTRACIÓN DE EMPRESAS", "INGENIERÍA INDUSTRIAL", "ENFERMERÍA" }, efvm.Estudiante.Carrera);
            efvm.turnos = new SelectList(new[] { "MATUTINO", "VESPERTINO", "NOCTURNO" }, efvm.Estudiante.Turno);
            efvm.ingresos = new SelectList(new[] { "NUEVO", "REINGRESO", "TRANSFERENCIA", "DOCTORADO O MAESTRÍA" }, efvm.Estudiante.Tipoingreso);

            return View("Index", efvm);
        }


    }
}
