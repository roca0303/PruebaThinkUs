using PruebaThinkUs.Models;

namespace PruebaThinkUs.Services
{
    public interface IGradoService
    {
        IEnumerable<GradoDTO> GetAll();
        Grado GetById(int id);
        void Add(Grado grado);
        void Update(Grado grado);
        void Delete(int id);
    }
}
