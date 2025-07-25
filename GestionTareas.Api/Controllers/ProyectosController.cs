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
    public class ProyectosController : ControllerBase
    {
        private readonly DbConnection connection;
        public ProyectosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }
        // GET: api/<ProyectosController>
        [HttpGet]
        public IEnumerable<Proyecto> Get()
        {
            var proyecto = connection.Query<Proyecto>("SELECT * FROM Proyectos").ToList();
            return proyecto;
        }

        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public Proyecto Get(int id)
        {
            var proyecto = connection.QueryFirstOrDefault<Proyecto>("SELECT * FROM Proyectos WHERE Id = @Id", new { Id = id });
            return proyecto;
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public Proyecto Post([FromBody] Proyecto proyecto)
        {
            connection.Execute(@"INSERT INTO Proyectos (Nombre, FechaCreacion, FechaVencimiento) 
                                VALUES (@Nombre, @FechaCreacion, @FechaVencimiento)",
                                new
                                {
                                    Nombre = proyecto.Nombre,
                                    FechaCreacion = proyecto.FechaCreacion,
                                    FechaVencimiento = proyecto.FechaVencimiento
                                });
            return proyecto;
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Proyecto proyecto)
        {
            connection.Execute(@"UPDATE Proyectos SET Nombre=@Nombre, FechaCreacion=@FechaCreacion, FechaVencimiento=@FechaVencimiento WHERE Id=@Id",
                            new
                            {
                                Nombre = proyecto.Nombre,
                                FechaCreacion = proyecto.FechaCreacion,
                                FechaVencimiento = proyecto.FechaVencimiento,
                                id
                            });
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Proyectos WHERE Id = @Id", new { Id = id });
        }
    }
}
