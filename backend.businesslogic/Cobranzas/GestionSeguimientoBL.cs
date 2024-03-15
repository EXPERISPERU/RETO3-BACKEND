using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Cobranzas
{
    public class GestionSeguimientoBL: IGestionSeguimientoBL
    {
        IGestionSeguimientoRepository repository;
        public GestionSeguimientoBL(IGestionSeguimientoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado)
        {
            return await repository.getListClientesAsignados(nIdEmpleado);
        }

        public async Task<IList<ContratosDeudaDTO>> getListContratosDeuda(int nIdCliente)
        {
            return await repository.getListContratosDeuda(nIdCliente);
        }

        public async Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato, int nIdSeguimiento)
        {
            return await repository.getListCronogramaDeuda(nIdContrato, nIdSeguimiento);
        }

        public async Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento)
        {
            return await repository.InsSeguimiento(seguimiento);
        }

        public async Task<GestionClienteDTO> getDatosCliente(int nIdUsuario, int nIdCliente)
        {
            return await repository.getDatosCliente(nIdUsuario, nIdCliente);
        }
        public async Task<IList<ClienteSearchDTO>> getListClientSearchByName(int nIdUsuario, string termino)
        {
            return await repository.getListClientSearchByName(nIdUsuario, termino);
        }

        public async Task<IList<SelectDTO>> getSelectTipoContacto()
        {
            return await repository.getSelectTipoContacto();
        }

        public async Task<IList<SelectDTO>> getSelectMedioContacto()
        {
            return await repository.getSelectMedioContacto();
        }

        public async Task<SqlRspDTO> InsSeguimientoDetalle(SeguimientoDetalleDTO detalle)
        {
            return await repository.InsSeguimientoDetalle(detalle);
        }

        public async Task<IList<SeguimientoDetalleDTO>> getListDetalleSeguimiento(int nIdSeguimiento)
        {
            return await repository.getListDetalleSeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SelectDTO>> getSelectResultado(int bRespuesta)
        {
            return await repository.getSelectResultado(bRespuesta);
        }

        public async Task<SqlRspDTO> InsAgendamiento(AgendamientoDTO agendamiento)
        {
            return await repository.InsAgendamiento(agendamiento);
        }

        public async Task<IList<SelectDTO>> getSelectTipoAgendamiento()
        {
            return await repository.getSelectTipoAgendamiento();
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamiento(int nIdSeguimiento)
        {
            return await repository.getListAgendamiento(nIdSeguimiento);
        }

        public async Task<SqlRspDTO> InsSeguimientoCuota(SeguimientoCuotaDTO seguimientoCuota)
        {
            return await repository.InsSeguimientoCuota(seguimientoCuota);
        }

        public async Task<SqlRspDTO> UpdTerminarSeguimiento(SeguimientoDTO seguimiento)
        {
            return await repository.UpdTerminarSeguimiento(seguimiento);
        }

        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoByFilters(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            return await repository.getListSeguimientoByFilters(SeguimientoFiltros);
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> getSelectTipoDocumento()
        {
            return await repository.getSelectTipoDocumento();
        }

        public async Task<IList<SeguimientoDTO>> getSeguimiento(int nIdSeguimiento)
        {
            return await repository.getSeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SeguimientoCuotaDTO>> getListSeguimientoCuotaBySeguimiento(int nIdSeguimiento)
        {
            return await repository.getListSeguimientoCuotaBySeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SelectDTO>> getInfoContactoByMedio(int nIdCliente, int nIdMedio)
        {
            return await repository.getInfoContactoByMedio(nIdCliente, nIdMedio);
        }
    }
}
