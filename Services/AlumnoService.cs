using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Datos;
using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public class AlumnoService: IAlumnoService
    {
        private readonly ApplicationDbContext _context;

        public AlumnoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Alumno> GetAll()
        {
            return _context.Alumno.ToList();
        }

        public Alumno GetById(int id)
        {
            return _context.Alumno.Find(id);
        }

        public void Add(Alumno alumno)
        {
            alumno.FechaCreacion = System.DateTime.Now;
            _context.Alumno.Add(alumno);
            _context.SaveChanges();
        }

        public void Update(Alumno alumno)
        {
            var existingEntity = _context.Alumno.Local.FirstOrDefault(e => e.Id == alumno.Id);

            if (existingEntity != null)
            {
                // Si ya hay una instancia, desvincúlala antes de adjuntar la nueva
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Alumno.Update(alumno);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var alumno = _context.Alumno.Find(id);
            if (alumno != null)
            {
                _context.Alumno.Remove(alumno);
                _context.SaveChanges();
            }
        }
    }
}
