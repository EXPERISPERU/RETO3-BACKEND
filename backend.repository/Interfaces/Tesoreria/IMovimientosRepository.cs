using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Tesoreria
{
    public interface IMovimientosRepository
    {
        Task<IList<MovimientosDTO>> getAllListMovimientosByCaja(int nIdCaja, int nIdUsuario);
        Task<IList<SelectDTO>> getAllTipoMovimiento();
        Task<IList<ItemDTO>> getAllItem();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros);
        Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato);
        Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdCompania, int nIdConceptoVenta);
        Task<IList<MovimientosDTO>> getAllListMovimientosById(int nIdMovimiento);
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania, int nIdProyecto, int nIdSector, int nIdManzana, int nIdLote);
        Task<IList<ItemDTO>> getAllItemCompania(int nIdCompania);


        //Task<SqlRspDTO> InsMovimientos(MovimientosDTO movimiento);
        Task<SqlRspDTO> InsMovimientosVenta(MovVentaLoteDTO ventaLote);
        Task<SqlRspDTO> InsMovimientosCuota(MovCuotaDTO cuota);
        Task<SqlRspDTO> InsMovimientosPrecontrato(MovPreContratoDTO preContrato);
        Task<SqlRspDTO> InsMovimientosAdicionPrecontrato(MovPreContratoDTO preContrato);
        Task<SqlRspDTO> InsMovimientosReserva(MovReservaDTO reserva);
        Task<IList<MovReporteArqueoDTO>> getAllReporteArqueoCaja(int nIdCompania, int nIdCaja, int nIdUsuario);
        


    }
}
