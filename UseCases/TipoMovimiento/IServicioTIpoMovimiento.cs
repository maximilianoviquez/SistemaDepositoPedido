using Obligatorio2_P3.DTO;

namespace Obligatorio2_P3.UseCases
{
    public interface IServicioTIpoMovimiento
    {
        IEnumerable<TipoMovimientoDTO> GetByName(string name);
    }
}
