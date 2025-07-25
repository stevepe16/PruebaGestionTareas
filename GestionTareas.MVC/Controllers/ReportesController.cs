using Gestion.Modelos;
using GestionTareas.MVC.Models;  
using Api.Consumer;  
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.MVC.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult Index()
        {
            var reporte = new ReporteTareasViewModel
            {
                Tareas = new List<Tarea>(),
                Estado = "Pendiente",
                Prioridad = "Alta",
            };

            return View(reporte);
        }

        [HttpPost]
        public ActionResult ObtenerReporte(ReporteTareasViewModel model)
        {
            var tareasFiltradas = Crud<Tarea>.GetAll(); //Lo usamos para traer todas las tareas

            if (!string.IsNullOrEmpty(model.Estado)) //Aqui filtramos las tareas segun su estado
            {
                tareasFiltradas = tareasFiltradas.Where(t => t.Estado == model.Estado).ToList();
            }

            if (!string.IsNullOrEmpty(model.Prioridad))//Aqui filtramos las tareas segun su prioridad
            {
                tareasFiltradas = tareasFiltradas.Where(t => t.Prioridad == model.Prioridad).ToList();
            }

            model.Tareas = tareasFiltradas;

            return View("Index", model);//Hacemos que regrese a la pagina pero para que se recargue y salgan las tareas con los filtros
        }
    }

}
