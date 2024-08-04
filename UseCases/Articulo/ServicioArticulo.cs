using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;

namespace Obligatorio2_P3.UseCases
{
    public class ServicioArticulo : IServicioArticulo
    {
        private readonly IContextHttpArticulo _repositorio;

        public ServicioArticulo(IContextHttpArticulo repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ArticuloDTO> GetByName(string name)
        {
            string filtros = "?";
            filtros += "name=" + name;

            IEnumerable<ArticuloDTO> articulos = _repositorio.GetAll(filtros).GetAwaiter().GetResult();
            return articulos;
        } 
    }
}
