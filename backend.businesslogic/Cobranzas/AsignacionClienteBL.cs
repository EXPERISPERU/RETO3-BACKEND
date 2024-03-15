using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using backend.repository.Interfaces.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Cobranzas
{
    public class AsignacionClienteBL : IAsignacionClienteBL
    {
        IAsignacionClienteRepository repository;
        public AsignacionClienteBL(IAsignacionClienteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectPeriodoGestion()
        {
            return await repository.getSelectPeriodoGestion();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania( int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectSectoresByProyecto(int nIdProyecto)
        {
            return await repository.getSelectSectoresByProyecto(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            return await repository.getSelectManzanaBySector(nIdSector);
        }

        public async Task<IList<SelectDTO>> getSelectCicloPagoByProyecto(int nIdProyecto)
        {
            return await repository.getSelectCicloPagoByProyecto(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> getSelectAsesorCobranza(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectAsesorCobranza(nIdUsuario, nIdCompania);
        }

        public async Task<IList<AsignacionClienteDTO>> getListAsignacionClienteByFilters(AsignacionClienteFiltrosDTO AsignacionFiltros)
        {
            return await repository.getListAsignacionClienteByFilters(AsignacionFiltros);
        }

        public async Task<SqlRspDTO> InsAsignacionCliente(AsignacionClienteDTO asignacionCliente)
        {
            return await repository.InsAsignacionCliente(asignacionCliente);
        }

        public async Task<IList<AsignacionClienteDTO>> getClienteAsignadosByEmpleadoPeriodo(int nIdEmpleado, int nIdPeriodo, int nIdCompania)
        {
            return await repository.getClienteAsignadosByEmpleadoPeriodo(nIdEmpleado, nIdPeriodo, nIdCompania);
        }

    }
}
