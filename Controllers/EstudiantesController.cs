using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Models;
using Actividad4LengProg3.Data;
using Microsoft.AspNetCore.Mvc;
using System;


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
        public IActionResult Registrar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ESTUDIANTES.Add(model);
                _context.SaveChanges();
                TempData["Mensaje"] = "Estudiante registrado correctamente.";
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                EstudianteViewModel estudianteActual = _context.ESTUDIANTES.FirstOrDefault(e => e.matriculaEstudiante.Equals(model.matriculaEstudiante));

                if (estudianteActual == null)
                {
                    TempData["MensajeError"] = "No existe el estudiante indicado.";

                    return RedirectToAction("Lista");
                }

                if (estudianteActual != null)
                {
                    estudianteActual.matriculaEstudiante = model.matriculaEstudiante;
                    estudianteActual.nombreEstudiante = model.nombreEstudiante;
                    estudianteActual.carreraEstudiante = model.carreraEstudiante;
                    estudianteActual.correoEstudiante = model.correoEstudiante;
                    estudianteActual.telefonoEstudiante = model.telefonoEstudiante;
                    estudianteActual.fechaEstudiante = model.fechaEstudiante;
                    estudianteActual.generoEstudiante = model.generoEstudiante;
                    estudianteActual.turnoEstudiante = model.turnoEstudiante.ToString();
                    estudianteActual.ingresoEstudiante = model.ingresoEstudiante;
                    estudianteActual.becaEstudiante = model.becaEstudiante;
                    estudianteActual.porcentajebecaEstudiante = model.porcentajebecaEstudiante;

                    _context.SaveChanges();
                    TempData["Mensaje"] = "Los datos del estudiante han sido editados satisfactoriamente.";
                    return RedirectToAction("Lista");
                }
            }

            return View(model);
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.ESTUDIANTES.FirstOrDefault(e => e.matriculaEstudiante == matricula);
            if (estudiante == null)
            {
                _context.ESTUDIANTES.Remove(estudiante);
                _context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }

            [HttpGet]
            public IActionResult Lista()
            {
                var estudiantes = _context.ESTUDIANTES.ToList();
                return View(estudiantes);
            }

            [HttpGet]
            public IActionResult Editar(string matricula)
            {
                if (string.IsNullOrEmpty(matricula))
                {
                    TempData["MensajeError"] = "La matricula es invalida";
                    return RedirectToAction("Lista");
                }
                var estudiante = _context.ESTUDIANTES.FirstOrDefault(e => e.matriculaEstudiante == matricula);
                if (estudiante == null)
                {
                    TempData["MensajeError"] = "El estudiante no fue encontrado";
                    return RedirectToAction("Lista");
                }

                return View(estudiante);
            }
        }
    }
