using backend.businesslogic.Comercial;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using backend.repository.Interfaces.Tesoreria;
using backend.repository.Tesoreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Tesoreria
{
    public class MovimientosBL: IMovimientosBL
    {
        IMovimientosRepository repository;
        ICotizacionBL cotizacionBL;
        public MovimientosBL(IMovimientosRepository _repository, ICotizacionBL _cotizacionBL)
        {
            repository = _repository;
            cotizacionBL = _cotizacionBL;
        }

        public async Task<IList<ItemDTO>> getAllItem()
        {
            return await repository.getAllItem();
        }

        public async Task<IList<MovimientosDTO>> getAllListMovimientosByCaja(int nIdCaja, int nIdUsuario)
        {
            return await repository.getAllListMovimientosByCaja(nIdCaja, nIdUsuario);
        }

        public async Task<IList<SelectDTO>> getAllTipoMovimiento()
        {
            return await repository.getAllTipoMovimiento();
        }

        public async Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros)
        {
            return await repository.getListContratoByFilters(contratoFiltros);
        }

        public async Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato)
        {
            return await repository.getListCronogramaByContrato(nIdContrato);
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            return await repository.getSelectManzanaBySector(nIdSector);
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            return await repository.getSelectSectorByProyecto(nIdProyecto);
        }

        //public async Task<SqlRspDTO> InsMovimientos(MovimientosDTO movimiento)
        //{
        //    return await repository.InsMovimientos(movimiento);
        //}
        public async Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdCompania, int nIdConceptoVenta)
        {
            return await repository.GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(nIdCompania, nIdConceptoVenta);
        }

        public async Task<IList<MovimientosDTO>> getAllListMovimientosById(int nIdMovimiento)
        {
            return await repository.getAllListMovimientosById(nIdMovimiento);
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania, int nIdProyecto, int nIdSector, int nIdManzana, int nIdLote)
        {
            var list = await repository.getListLotesDisponibles(nIdCompania, nIdProyecto, nIdSector, nIdManzana, nIdLote);
            foreach (var item in list)
            {
                await cotizacionBL.calculateCotizacionValues(item, false);
            }
            return list;
            //return await repository.getListLotesDisponibles(nIdCompania, nIdProyecto, nIdSector, nIdManzana, nIdLote);
        }

        public async Task<IList<ItemDTO>> getAllItemCompania(int nIdCompania)
        {
            return await repository.getAllItemCompania(nIdCompania);
        }

        public async Task<SqlRspDTO> InsMovimientosVenta(MovVentaLoteDTO ventaLote)
        {
            return await repository.InsMovimientosVenta(ventaLote);
        }

        public async Task<SqlRspDTO> InsMovimientosCuota(MovCuotaDTO cuota)
        {
            return await repository.InsMovimientosCuota(cuota);
        }

        public async Task<SqlRspDTO> InsMovimientosPrecontrato(MovPreContratoDTO preContrato)
        {
            return await repository.InsMovimientosPrecontrato(preContrato);
        }

        public async Task<SqlRspDTO> InsMovimientosReserva(MovReservaDTO reserva)
        {
            return await repository.InsMovimientosReserva(reserva);
        }

        public async Task<IList<MovReporteArqueoDTO>> getAllReporteArqueoCaja(int nIdCompania, int nIdCaja, int nIdUsuario)
        {
            return await repository.getAllReporteArqueoCaja(nIdCompania, nIdCaja, nIdUsuario);
        }

        public async Task<SqlRspDTO> InsMovimientosAdicionPrecontrato(MovPreContratoDTO preContrato)
        {
            return await repository.InsMovimientosAdicionPrecontrato(preContrato);
        }

        public async Task<SqlRspDTO> InsMovimientosEgreso(MovEgresoDTO movEgreso)
        {
            return await repository.InsMovimientosEgreso(movEgreso);
        }

        public async Task<IList<ItemDTO>> getAllItemProductos(int nIdCompania)
        {
            return await repository.getAllItemProductos(nIdCompania);
        }

        public async Task<IList<ListPrecioProductoDTO>> postPrecioProducto(ParamPrecioProductoDTO paramPrecioProducto)
        {
            return await repository.postPrecioProducto(paramPrecioProducto);
        }

    }
}
