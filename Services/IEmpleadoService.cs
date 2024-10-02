using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public interface IEmpleadoService
    {
        IEnumerable<Empleado> GetAll();
        Empleado GetById(int id);
        void Add(Empleado empleado);
        void Update(Empleado empleado);
        void Delete(int id);
    }
}
