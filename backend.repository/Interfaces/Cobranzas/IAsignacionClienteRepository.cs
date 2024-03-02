﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Cobranzas
{
    public interface IAsignacionClienteRepository
    {
        Task<IList<SelectDTO>> getSelectPeriodoGestion();
        Task<IList<SelectDTO>> getSelectProyectoByCompania( int nIdCompania );
        Task<IList<SelectDTO>> getSelectSectoresByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectCicloPagoByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectAsesorCobranza(int nIdUsuario, int nIdCompania);
        Task<IList<AsignacionClienteDTO>> getListAsignacionClienteByFilters(AsignacionClienteFiltrosDTO AsignacionFiltros);
        Task<SqlRspDTO> InsAsignacionCliente(AsignacionClienteDTO asignacionCliente);
        Task<IList<AsignacionClienteDTO>> getClienteAsignadosByEmpleadoPeriodo(int nIdEmpleado, int nIdPeriodo);
    }
}
