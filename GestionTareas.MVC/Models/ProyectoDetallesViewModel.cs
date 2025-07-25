using Gestion.Modelos;

namespace GestionTareas.MVC.Models
{
    public class ProyectoDetallesViewModel
    {
        public Proyecto Proyecto { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
