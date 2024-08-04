using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;

namespace Obligatorio2_P3.UseCases
{
    public class ServicioTipoMovimiento : IServicioTIpoMovimiento
    {
        private readonly IContextHttpTipo _repositorio;

        public ServicioTipoMovimiento(IContextHttpTipo repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<TipoMovimientoDTO> GetByName(string name)
        {
            string filtros = "?";
            filtros += "name=" + name;

            IEnumerable<TipoMovimientoDTO> tipos = _repositorio.GetAll(filtros).GetAwaiter().GetResult();

            return tipos;   
        }
    }
}
