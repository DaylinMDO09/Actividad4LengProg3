using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
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
                TempData["Mensaje"] = "Estudiante registrado satisfactoriamente.";
                return RedirectToAction("Lista");
            }   
            return View("Index", estudiante);
        }


        public IActionResult Lista()
        {

            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);

        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.matriculaEstudiante == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el estudiante indicado";
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }



        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var estudianteActual = _context.Estudiantes.FirstOrDefault(e => e.matriculaEstudiante == estudiante.matriculaEstudiante);

                if (estudianteActual == null)
                {
                    TempData["Mensaje"] = "No existe el estudiante indicado";
                    return RedirectToAction("Lista");
                }

                
                estudianteActual.nombreEstudiante = estudiante.nombreEstudiante;
                estudianteActual.carreraEstudiante = estudiante.carreraEstudiante;
                estudianteActual.correoEstudiante = estudiante.correoEstudiante;
                estudianteActual.telefonoEstudiante = estudiante.telefonoEstudiante;
                estudianteActual.fechaEstudiante = estudiante.fechaEstudiante;
                estudianteActual.generoEstudiante = estudiante.generoEstudiante;
                estudianteActual.turnoEstudiante = estudiante.turnoEstudiante;
                estudianteActual.ingresoEstudiante = estudiante.ingresoEstudiante;
                estudianteActual.porcentajebecaEstudiante = estudiante.porcentajebecaEstudiante;
                estudianteActual.becaEstudiante = estudiante.becaEstudiante;
                estudianteActual.tcEstudiante = estudiante.tcEstudiante;

                _context.Update(estudianteActual);
                _context.SaveChanges();    

                TempData["Mensaje"] = "Los datos del estudiante han sido actualizados correctamente.";
                return RedirectToAction("Lista");
            }

            return View(estudiante);
        }



        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.matriculaEstudiante == matricula);
            if (estudiante != null) 
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "Estudiante eliminado satisfactoriamente.";
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }
    }
}