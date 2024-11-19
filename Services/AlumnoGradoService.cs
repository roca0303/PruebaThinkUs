using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Datos;
using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public class AlumnoGradoService: IAlumnoGradoService
    {
        private readonly ApplicationDbContext _context;

        public AlumnoGradoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AlumnoGradoDTO> GetAll()
        {
            var alumnoGrados = _context.AlumnoGrado
                .Include(ag => ag.Alumno)
                .Include(ag => ag.Grado)
                .Select(ag => new AlumnoGradoDTO
                {
                    Id = ag.Id,
                    Grupo = ag.Grupo,
                    Alumno = new AlumnoDTO
                    {
                        Id = ag.Alumno.Id,
                        Nombre = ag.Alumno.Nombre,
                        Apellidos = ag.Alumno.Apellidos
                    },
                    Grado = new GradoDTO
                    {
                        Id = ag.Grado.Id,
                        Nombre = ag.Grado.Nombre,
                        Profesor = new ProfesorDTO
                        {
                            Id = ag.Grado.Profesor.Id,
                            Nombre = ag.Grado.Profesor.Nombre,
                            Apellidos = ag.Grado.Profesor.Apellidos
                        }
                    }
                })
                .ToList();

            return alumnoGrados;
        }

        public AlumnoGrado GetById(int id)
        {
            return _context.AlumnoGrado.Find(id);
        }

        public void Add(AlumnoGrado alumnoGrado)
        {
            _context.AlumnoGrado.Add(alumnoGrado);
            _context.SaveChanges();
        }

        public void Update(AlumnoGrado alumnoGrado)
        {
            var existingEntity = _context.AlumnoGrado
                .Include(ag => ag.Alumno) // Incluir las relaciones si es necesario
                .Include(ag => ag.Grado)
                .FirstOrDefault(e => e.Id == alumnoGrado.Id);

            if (existingEntity == null)
            {
                throw new Exception($"AlumnoGrado con ID {alumnoGrado.Id} no encontrado.");
            }

            // Actualizar los campos necesarios
            existingEntity.AlumnoId = alumnoGrado.AlumnoId;
            existingEntity.GradoId = alumnoGrado.GradoId;
            existingEntity.Grupo = alumnoGrado.Grupo;

            // Marcar solo los campos que cambiaron como modificados
            _context.Entry(existingEntity).Property(e => e.AlumnoId).IsModified = true;
            _context.Entry(existingEntity).Property(e => e.Grupo).IsModified = true;
            _context.Entry(existingEntity).Property(e => e.GradoId).IsModified = true;

            _context.SaveChanges();


        }

        public void Delete(int id)
        {
            var alumnoGrado = _context.AlumnoGrado.Find(id);
            if (alumnoGrado != null)
            {
                _context.AlumnoGrado.Remove(alumnoGrado);
                _context.SaveChanges();
            }
        }
    }
}
