using System.ComponentModel.DataAnnotations;

namespace Gestion.Modelos
{
    public class Proyecto
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        //navegation properties
        public List<Tarea>? Tareas { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}
