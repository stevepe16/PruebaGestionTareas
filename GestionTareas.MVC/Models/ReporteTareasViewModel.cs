using System;
using System.Collections.Generic;
using Gestion.Modelos; 

namespace GestionTareas.MVC.Models
{
    public class ReporteTareasViewModel
    {
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public List<Tarea> Tareas { get; set; }
        public int? ProyectoId { get; set; }
        public int? UsuarioId { get; set; }
    }
}
