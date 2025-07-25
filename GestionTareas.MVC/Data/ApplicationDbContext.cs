using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gestion.Modelos;

namespace GestionTareas.MVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<Gestion.Modelos.Proyecto> Proyecto { get; set; } = default!;

public DbSet<Gestion.Modelos.Tarea> Tarea { get; set; } = default!;
}
