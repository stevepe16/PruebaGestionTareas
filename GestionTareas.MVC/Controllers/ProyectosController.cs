using Api.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestion.Modelos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GestionTareas.MVC.Models;
namespace GestionTareas.MVC.Controllers;

public class ProyectosController : Controller
    {
        // GET: ProyectosController
        public ActionResult Index()
        {

        var data = Crud<Proyecto>.GetAll();
            ViewBag.TotalProyectos = data.Count;
            return View(data);
        }

        // GET: ProyectosController/Details/5
        public ActionResult Details(int id)
        {
        var proyecto = Crud<Proyecto>.GetById(id);
        if (proyecto == null)
        {
            return NotFound(); 
        }
        var tareas = Crud<Tarea>.GetBy("ProyectoId", id); 
        var model = new ProyectoDetallesViewModel
        {
            Proyecto = proyecto,
            Tareas = tareas
        };

        return View(model);
    }

        // GET: ProyectosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProyectosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto data)
        {
            try
            {
                Crud<Proyecto>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: ProyectosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Proyecto>.GetById(id);
            return View(data);
        }

        // POST: ProyectosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proyecto data)
        {
            try
            {
                Crud<Proyecto>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: ProyectosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Proyecto>.GetById(id);
            return View(data);
        }

        // POST: ProyectosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Proyecto data)
        {
            try
            {
                Crud<Proyecto>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }

