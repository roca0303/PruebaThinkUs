using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public interface IAlumnoService
    {
        IEnumerable<Alumno> GetAll();
        Alumno GetById(int id);
        void Add(Alumno alumno);
        void Update(Alumno alumno);
        void Delete(int id);
    }
}
