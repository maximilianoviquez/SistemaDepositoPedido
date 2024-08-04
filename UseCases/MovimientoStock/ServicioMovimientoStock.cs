using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;

namespace Obligatorio2_P3.UseCases
{
    public class ServicioMovimientoStock : IServicioMovimientoStock
    {
        private IContextHttpMovimiento _repositorio;

        public ServicioMovimientoStock(IContextHttpMovimiento repositorio) 
        {
            _repositorio = repositorio;
        }


        public MovimientoStockDTO Add (MovimientoStockDTO dto)
        {
            dto.Validar();
            MovimientoStockDTO newMovimiento = _repositorio.Add(dto).GetAwaiter().GetResult();
            return newMovimiento;
        }

        public MovimientoStockResponseDTO GetAll(int skip, int take)
        {
            string filters = "?";
            filters += "skip=" + skip;
            filters += "&take=" + take;

            MovimientoStockResponseDTO movimiento = _repositorio.GetAll(filters).GetAwaiter().GetResult();
            return movimiento;
        }

        public MovimientoStockResponseDTO GetArticulosConMovimientosEntre(DateTime desde, DateTime hasta, int skip, int take)
        {
            string filters = "?";
            filters += "desde=" + desde;
            filters += "&hasta=" + hasta;
            filters += "&skip=" + skip;
            filters += "&take=" + take;
            MovimientoStockResponseDTO articulo = _repositorio.GetArticulosConMovimientosEntre(filters).GetAwaiter().GetResult();
            return articulo;
        }

        public MovimientoStockResponseDTO GetMovimientosRealizadosSobre(int articuloId, string tipoMovimiento, int skip, int take)
        {
            string filters = "?";
            filters += "articuloId=" + articuloId;
            filters += "&tipoMovimiento=" + tipoMovimiento;
            filters += "&skip=" + skip;
            filters += "&take=" + take;
            MovimientoStockResponseDTO movimiento = _repositorio.GetMovimientosRealizadosSobre(filters).GetAwaiter().GetResult();
            return movimiento;
        }

        public ResponseConsulta3DTO GetResumenDeMovimientosPorAño()
        {
     
            ResponseConsulta3DTO resumenes = _repositorio.GetResumenDeMovimientosPorAño().GetAwaiter().GetResult();
            return resumenes;
        }
    }
}
