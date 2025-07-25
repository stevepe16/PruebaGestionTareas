using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Modelos
{
    public class Usuario
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 

        //Foring Keys
        public int ProyectoId { get; set; }

        //Navegation Properties
        public List<Tarea>? Tareas { get; set; }
        public Proyecto? Proyecto { get; set; }
    }
}
