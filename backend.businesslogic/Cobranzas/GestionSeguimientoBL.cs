using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using System;
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

        public async Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato)
        {
            return await repository.getListCronogramaDeuda(nIdContrato);
        }

        public async Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento)
        {
            return await repository.InsSeguimiento(seguimiento);
        }

        public async Task<GestionClienteDTO> getDatosCliente(int nIdCliente)
        {
            return await repository.getDatosCliente(nIdCliente);
        }
        public async Task<IList<SelectDTO>> getListClientSearchByName(string termino)
        {
            return await repository.getListClientSearchByName(termino);
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

    }
}
