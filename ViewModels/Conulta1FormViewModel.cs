using Obligatorio2_P3.DTO;

namespace Obligatorio2_P3.ViewModels
{
    public class Conulta1FormViewModel
    {
        public IEnumerable<TipoMovimientoDTO> posiblesTipos { get; set; }
        public IEnumerable<ArticuloDTO> posiblesArticulos { get; set; }

        public Conulta1FormViewModel() { }
    }
}
