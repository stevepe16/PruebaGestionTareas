using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Modelos
{
    public class Tarea
    {
        [Key] public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } // Ejemplo: "Pendiente", "En Progreso", "Completada"

        //Foring Keys
        public int UsuarioId { get; set; }
        public int ProyectoId { get; set; }

        //Navegation Properties
        public Usuario? Usuario { get; set; }
        public Proyecto? Proyecto { get; set; }

    }
}
