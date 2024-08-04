using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;

namespace Obligatorio2_P3.UseCases.Usuario
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IContextHttpUsuario _repositorio;

        public ServicioUsuario(IContextHttpUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<UsuarioDTOread> GetEncargados(string name)
        {
            string filtros = "?";
            filtros += "name=" + name;

            IEnumerable<UsuarioDTOread> encargados = _repositorio.GetEncargados(filtros).GetAwaiter().GetResult();
            return encargados;
        }
    }
}
