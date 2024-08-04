using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;
using Obligatorio2_P3.UseCases;

namespace Obligatorio2_P3.UseCases
{
    public class ServicioLogin : IServicioLogin<LoginDTO, UsuarioDTOread>
    {
        private IContextHttpLogin _repositorio;


        public ServicioLogin(IContextHttpLogin repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioDTOread Login(LoginDTO loginDto)
        {
            UsuarioDTOread logueado = _repositorio.Login(loginDto).GetAwaiter().GetResult();
            
            return logueado;
        }
    }
}
