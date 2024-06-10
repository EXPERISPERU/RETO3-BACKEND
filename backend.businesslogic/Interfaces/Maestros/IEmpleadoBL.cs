using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IEmpleadoBL
    {
        Task<IList<EmpleadoDTO>> getListEmpleado();
        Task<EmpleadoDTO> findPersona(string? sDNI, string? sCE);
        Task<EmpleadoDTO> getEmpleadoById(int nIdEmpleado);
        Task<IList<DireccionDTO>> getListDireccion(int nIdPersona);
        Task<IList<PeriodoLaboralDTO>> getListPeriodoLab(int nIdEmpleado);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsEmpleado(EmpleadoDTO empleado);
        Task<SqlRspDTO> UpdEmpleado(EmpleadoDTO empleado);
        Task<SqlRspDTO> InsDireccion(DireccionDTO direccion);
        Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion);
        Task<IList<SelectDTO>> getCompanias();
        Task<int> CantPerLabActivoByEmpleado(int nIdEmpleado);
        Task<SqlRspDTO> InsPerLab(PeriodoLaboralDTO periodoLaboral);
        Task<SqlRspDTO> UpdPerLab(PeriodoLaboralDTO periodoLaboral);
        Task<IList<SelectDTO>> getSelectJefesEmpleado(int nIdCompania, int nIdEmpleado);
        Task<SqlRspDTO> InsJefeEmpleado(JefeEmpleadoDTO jefeEmpleado);
        Task<IList<JefeEmpleadoDTO>> getJefesEmpleadosByEmpleado(int nIdEmpleado, int nIdPeriodoLaboral);
    }
}
