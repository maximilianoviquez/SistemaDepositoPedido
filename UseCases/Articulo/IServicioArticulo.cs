using Obligatorio2_P3.DTO;

namespace Obligatorio2_P3.UseCases
{
    public interface IServicioArticulo
    {
        IEnumerable<ArticuloDTO> GetByName(string name);
    }
}
