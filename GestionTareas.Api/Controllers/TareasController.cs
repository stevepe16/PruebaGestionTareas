using System.Data.Common;
using Dapper;
using Gestion.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTareas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly DbConnection connection;
        public TareasController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }
        // GET: api/<TareasController>
        [HttpGet]
        public IEnumerable<Tarea> Get()
        {
            var tarea = connection.Query<Tarea>("SELECT * FROM Tareas").ToList();
            return tarea;
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public Tarea Get(int id)
        {
            var tarea = connection.QueryFirstOrDefault<Tarea>("SELECT * FROM Tareas WHERE Id = @Id", new { Id = id });
            return tarea;
        }

        // POST api/<TareasController>
        [HttpPost]
        public Tarea Post([FromBody]Tarea tarea)
        {
            connection.Execute("INSERT INTO Tareas (Titulo, Descripcion, FechaCreacion, FechaVencimiento, Estado, Prioridad, UsuarioId, ProyectoId) " +
                               "VALUES (@Titulo, @Descripcion, @FechaCreacion, @FechaVencimiento, @Estado, @Prioridad, @UsuarioId, @ProyectoId)",
                               new
                               {
                                   Titulo = tarea.Titulo,
                                   Descripcion = tarea.Descripcion,
                                   FechaCreacion = tarea.FechaCreacion,
                                   FechaVencimiento = tarea.FechaVencimiento,
                                   Estado = tarea.Estado,
                                   Prioridad = tarea.Prioridad,
                                   UsuarioId = tarea.UsuarioId,
                                   ProyectoId = tarea.ProyectoId
                               });
            return tarea;
        }

        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Tarea tarea)
        {
            connection.Execute(@"UPDATE Tareas SET Titulo=@Titulo, Descripcion=@Descripcion, FechaCreacion=@FechaCreacion, 
                                FechaVencimiento=@FechaVencimiento, Estado=@Estado, Prioridad=@Prioridad,  UsuarioId=@UsuarioId, ProyectoId=@ProyectoId 
                                WHERE Id=@Id",
                                new
                                {
                                    Titulo = tarea.Titulo,
                                    Descripcion = tarea.Descripcion,
                                    FechaCreacion = tarea.FechaCreacion,
                                    FechaVencimiento = tarea.FechaVencimiento,
                                    Estado = tarea.Estado,
                                    Prioridad = tarea.Prioridad,
                                    UsuarioId = tarea.UsuarioId,
                                    ProyectoId = tarea.ProyectoId,
                                    id
                                });
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Tareas WHERE Id = @Id", new { Id = id });
        }

        // GET api/Tareas/ProyectoId/1
        [HttpGet("ProyectoId/{id}")]
        public IEnumerable<Tarea> GetByProyectoId(int id)
        {
            var tareas = connection.Query<Tarea>(
                "SELECT * FROM Tareas WHERE ProyectoId = @ProyectoId",
                new { ProyectoId = id }
            ).ToList();

            return tareas;
        }
    }
}
