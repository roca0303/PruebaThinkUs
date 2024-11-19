using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Datos;
using PruebaThinkUs.Models;
using System.ComponentModel.DataAnnotations;

namespace PruebaThinkUs.Services
{
    public class GradoService: IGradoService
    {
        private readonly ApplicationDbContext _context;

        public GradoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GradoDTO> GetAll()
        {

            return _context.Grado
               .Include(g => g.Profesor)
               .Select(g => new GradoDTO
               {
                   Id = g.Id,
                   Nombre = g.Nombre,
                   Profesor = g.Profesor != null ? new ProfesorDTO
                   {
                       Id = g.Profesor.Id,
                       Nombre = g.Profesor.Nombre,
                       Apellidos = g.Profesor.Apellidos
                   } : null
               })
               .ToList();
        }

        public Grado GetById(int id)
        {
            return _context.Grado.Find(id);
        }

        public void Add(Grado grado)
        {
            _context.Grado.Add(grado);
            _context.SaveChanges();
        }

        public void Update(Grado grado)
        {
            var existingEntity = _context.Grado.Local.FirstOrDefault(e => e.Id == grado.Id);

            if (existingEntity != null)
            {
                // Si ya hay una instancia, desvincúlala antes de adjuntar la nueva
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Grado.Update(grado);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var grado = _context.Grado.Find(id);
            if (grado != null)
            {
                _context.Grado.Remove(grado);
                _context.SaveChanges();
            }
        }

    }

    public class GradoCreateDTO
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Profesor es obligatorio")]
        public int ProfesorId { get; set; }
    }

    public class GradoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ProfesorDTO? Profesor { get; set; }
    }

    public class AlumnoGradoDTO
    {
        public int Id { get; set; }
        public AlumnoDTO? Alumno { get; set; }
        public GradoDTO? Grado { get; set; }
        public string? Grupo { get; set; }
    }

    public class AlumnoGradoUpdateDto
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string Grupo { get; set; } = string.Empty;
    }

    public class ProfesorDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
    }

    public class AlumnoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
    }

}
