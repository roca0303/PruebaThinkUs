using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public interface IProfesorService
    {
        IEnumerable<Profesor> GetAll();
        Profesor GetById(int id);
        void Add(Profesor profesor);
        void Update(Profesor profesor);
        void Delete(int id);
    }
}
