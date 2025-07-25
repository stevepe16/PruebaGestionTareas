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
    public class UsuariosController : ControllerBase
    {
        private readonly DbConnection connection;
        public UsuariosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            var usuario = connection.Query<Usuario>("SELECT * FROM Usuarios").ToList();
            return usuario;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            var usuario = connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public Usuario Post([FromBody]Usuario usuario)
        {
            connection.Execute(@"INSERT INTO Usuarios (Nombre, Apellido, Correo, Contraseña, ProyectoId) 
                                VALUES (@Nombre, @Apellido, @Correo, @Contraseña, @ProyectoId)",
                                new
                                {
                                    Nombre = usuario.Nombre,
                                    Apellido = usuario.Apellido,
                                    Correo = usuario.Correo,
                                    Contraseña = usuario.Contraseña,
                                    ProyectoId = usuario.ProyectoId
                                });
            return usuario;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Usuario usuario)
        {
            connection.Execute(@"UPDATE Usuarios SET Nombre=@Nombre, Apellido=@Apellido, Correo=@Correo, Contraseña=@Contraseña, ProyectoId=@ProyectoId WHERE Id=@Id",
                            new
                            {
                                Nombre = usuario.Nombre,
                                Apellido = usuario.Apellido,
                                Correo = usuario.Correo,
                                Contraseña = usuario.Contraseña,
                                ProyectoId = usuario.ProyectoId,
                                id
                            });
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Usuarios WHERE Id = @Id", new { Id = id });
        }
    }
}
