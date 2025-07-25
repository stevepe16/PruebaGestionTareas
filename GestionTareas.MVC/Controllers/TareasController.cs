using Api.Consumer;
using Gestion.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GestionTareas.MVC.Controllers;

public class TareasController : Controller
    {
        // GET: TareasController
        public ActionResult Index()
        {
            var data = Crud<Tarea>.GetAll();
            ViewBag.Proyectos = GetProyectos(); //Traemos todos los Proyectos relacionados con las tareas
            ViewBag.TotalTareas = data.Count; //Tenemos un contador de tareas para el index
            return View(data);
        }

        // GET: TareasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Tarea>.GetById(id);
            return View(data);
        }

        // GET: TareasController/Create
        public ActionResult Create()
        {
            ViewBag.Usuarios = GetUsuarios();
            ViewBag.Proyectos = GetProyectos();
            return View();
        }

        // POST: TareasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarea data)
        {
            try
            {
                Crud<Tarea>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: TareasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Tarea>.GetById(id);
            ViewBag.Usuarios = GetUsuarios();
            ViewBag.Proyectos = GetProyectos();
            return View(data);
        }

        // POST: TareasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tarea data)
        {
            try
            {
                Crud<Tarea>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: TareasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Tarea>.GetById(id);
            return View(data);
        }

        // POST: TareasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tarea data)
        {
            try
            {
                Crud<Tarea>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        private List<SelectListItem> GetUsuarios()
        {
            var usuarios = Crud<Usuario>.GetAll();
            return usuarios.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
        }
        private List<SelectListItem> GetProyectos()
        {
            var proyectos = Crud<Proyecto>.GetAll();
            return proyectos.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
        }
    }

