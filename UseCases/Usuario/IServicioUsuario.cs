using Obligatorio2_P3.DTO;

namespace Obligatorio2_P3.UseCases.Usuario
{
    public interface IServicioUsuario
    {
        public IEnumerable<UsuarioDTOread> GetEncargados(string name);
    }
}
