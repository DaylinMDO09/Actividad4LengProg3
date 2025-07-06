using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly BdMdoContext _context;

        public EstudiantesController(BdMdoContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);

                _context.SaveChanges();

                TempData["Mensaje"] = "Estudiante registrado correctamente.";
                
                 return RedirectToAction("Index");
            }

            return View(estudiante);
        }
    }
    //    [HttpPost]
    //    public IActionResult Editar(EstudianteViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.matriculaEstudiante.Equals(model.matriculaEstudiante));

    //            if (estudianteActual == null)
    //            {
    //                TempData["MensajeError"] = "No existe el estudiante indicado.";

    //                return RedirectToAction("Lista");
    //            }

    //            if (estudianteActual != null)
    //            {
    //                estudianteActual.matriculaEstudiante = model.matriculaEstudiante;
    //                estudianteActual.nombreEstudiante = model.nombreEstudiante;
    //                estudianteActual.carreraEstudiante = model.carreraEstudiante;
    //                estudianteActual.correoEstudiante = model.correoEstudiante;
    //                estudianteActual.telefonoEstudiante = model.telefonoEstudiante;
    //                estudianteActual.fechaEstudiante = model.fechaEstudiante;
    //                estudianteActual.generoEstudiante = model.generoEstudiante;
    //                estudianteActual.turnoEstudiante = model.turnoEstudiante.ToString();
    //                estudianteActual.ingresoEstudiante = model.ingresoEstudiante;
    //                estudianteActual.becaEstudiante = model.becaEstudiante;
    //                estudianteActual.porcentajebecaEstudiante = model.porcentajebecaEstudiante;

    //                TempData["Mensaje"] = "Los datos del estudiante han sido editados satisfactoriamente.";
    //                return RedirectToAction("Lista");
    //            }
    //        }

    //        return View(model);
    //    }

    //    public IActionResult Eliminar(string matricula)
    //    {
    //        var estudiante = estudiantes.FirstOrDefault(e => e.matriculaEstudiante == matricula);
    //        if (estudiante != null) estudiantes.Remove(estudiante);
    //        TempData["Mensaje"] = "Estudiante eliminado satisfactoriamente.";
    //        return RedirectToAction("Lista");
    //    }

    //    [HttpGet]
    //    public IActionResult Lista()
    //    {
    //        return View(estudiantes);
    //    }

    //    [HttpGet]
    //    public IActionResult Editar(string matricula)
    //    {
    //        if (string.IsNullOrEmpty(matricula))
    //        {
    //            TempData["MensajeError"] = "La matricula de este estudiante no existe.";
    //            return RedirectToAction("Lista");
    //        }

    //        EstudianteViewModel estudianteActual = estudiantes.FirstOrDefault(e => e.matriculaEstudiante.Equals(matricula));

    //        if (estudianteActual == null)
    //        {
    //            TempData["MensajeError"] = "El estudiante indicado no existe.";
    //            return RedirectToAction("Lista");
    //        }

    //        return View(estudianteActual);
    //    }
    //}
}
