using Obligatorio2_P3.DTO;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio2_P3.ViewModels
{
    public class MovimientoStockFormViewModel
    {
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int TipoMovimientoId { get; set; }
        public string MailEncargado { get; set; }

        public IEnumerable<TipoMovimientoDTO> posiblesTipos {  get; set; }
        public IEnumerable<ArticuloDTO> posiblesArticulos { get; set; }
        public IEnumerable<UsuarioDTOread> posiblesEncargados { get; set; }


        public MovimientoStockFormViewModel() { }


        public MovimientoStockDTO ToMovimientoStockDTO()
        {
            MovimientoStockDTO movimientoDto = new MovimientoStockDTO
            {
                ArticuloId = this.ArticuloId,
                Cantidad = this.Cantidad,
                FechaMovimiento = this.FechaMovimiento,
                TipoMovimientoId = this.TipoMovimientoId,
                MailEncargado = this.MailEncargado,
            };
            return movimientoDto;
        }
    }
}
