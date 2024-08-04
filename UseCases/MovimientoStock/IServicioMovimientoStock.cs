using Obligatorio2_P3.DTO;

namespace Obligatorio2_P3.UseCases
{
    public interface IServicioMovimientoStock
    {
        public MovimientoStockDTO Add( MovimientoStockDTO dto );
        public MovimientoStockResponseDTO GetAll(int skip, int take);
        public MovimientoStockResponseDTO GetMovimientosRealizadosSobre(int articuloId, string tipoMovimiento, int skip, int take);
        public MovimientoStockResponseDTO GetArticulosConMovimientosEntre(DateTime desde, DateTime hasta, int skip, int take);
        public ResponseConsulta3DTO GetResumenDeMovimientosPorAño();
    }
}
