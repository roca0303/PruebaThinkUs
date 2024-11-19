using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public interface IAlumnoGradoService
    {
        IEnumerable<AlumnoGradoDTO> GetAll();
        AlumnoGrado GetById(int id);
        void Add(AlumnoGrado alumnogrado);
        void Update(AlumnoGrado alumnogrado);
        void Delete(int id);
    }
}
