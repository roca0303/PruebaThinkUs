using Microsoft.EntityFrameworkCore;
using PruebaThinkUs.Datos;
using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public class ProfesorService: IProfesorService
    {
        private readonly ApplicationDbContext _context;

        public ProfesorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesor> GetAll()
        {
            return _context.Profesor.ToList();
        }

        public Profesor GetById(int id)
        {
            return _context.Profesor.Find(id);
        }

        public void Add(Profesor profesor)
        {
            profesor.FechaCreacion = System.DateTime.Now;
            _context.Profesor.Add(profesor);
            _context.SaveChanges();
        }

        public void Update(Profesor profesor)
        {
            var existingEntity = _context.Profesor.Local.FirstOrDefault(e => e.Id == profesor.Id);

            if (existingEntity != null)
            {
                // Si ya hay una instancia, desvincúlala antes de adjuntar la nueva
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Profesor.Update(profesor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var profesor = _context.Profesor.Find(id);
            if (profesor != null)
            {
                _context.Profesor.Remove(profesor);
                _context.SaveChanges();
            }
        }
    }
}
