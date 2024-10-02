using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Models;

namespace PruebaThinkUs.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Agregar los modelos aquí (Cada modelo corresponde a una tabla en la BD)
        public DbSet<Empleado> Empleado { get; set; }

    }
}
