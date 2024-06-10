using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class EmpleadoBL : IEmpleadoBL
    {
        IEmpleadoRepository repository;
        public EmpleadoBL(IEmpleadoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<EmpleadoDTO>> getListEmpleado() 
        { 
            return await repository.getListEmpleado();
        }

        public async Task<EmpleadoDTO> findPersona(string? sDNI, string? sCE)
        { 
            return await repository.findPersona(sDNI, sCE);
        }

        public async Task<EmpleadoDTO> getEmpleadoById(int nIdEmpleado)
        {
            return await repository.getEmpleadoById(nIdEmpleado);
        }

        public async Task<IList<DireccionDTO>> getListDireccion(int nIdPersona)
        {
            return await repository.getListDireccion(nIdPersona);
        }

        public async Task<IList<PeriodoLaboralDTO>> getListPeriodoLab(int nIdEmpleado)
        {
            return await repository.getListPeriodoLab(nIdEmpleado);        
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<SqlRspDTO> InsEmpleado(EmpleadoDTO empleado)
        { 
            return await repository.InsEmpleado(empleado);
        }

        public async Task<SqlRspDTO> UpdEmpleado(EmpleadoDTO empleado)
        {
            return await repository.UpdEmpleado(empleado);   
        }

        public async Task<SqlRspDTO> InsDireccion(DireccionDTO direccion)
        {
            return await repository.InsDireccion(direccion);
        }

        public async Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion)
        {
            return await repository.UpdDireccion(direccion);
        }

        public async Task<IList<SelectDTO>> getCompanias()
        {
            return await repository.getCompanias();
        }

        public async Task<int> CantPerLabActivoByEmpleado(int nIdEmpleado)
        {
            return await repository.CantPerLabActivoByEmpleado(nIdEmpleado);
        }

        public async Task<SqlRspDTO> InsPerLab(PeriodoLaboralDTO periodoLaboral)
        {
            return await repository.InsPerLab(periodoLaboral);
        }

        public async Task<SqlRspDTO> UpdPerLab(PeriodoLaboralDTO periodoLaboral)
        {
            return await repository.UpdPerLab(periodoLaboral);
        }

        public async Task<IList<SelectDTO>> getSelectJefesEmpleado(int nIdCompania, int nIdEmpleado)
        {
            return await repository.getSelectJefesEmpleado(nIdCompania, nIdEmpleado);
        }

        public async Task<SqlRspDTO> InsJefeEmpleado(JefeEmpleadoDTO jefeEmpleado)
        {
            return await repository.InsJefeEmpleado(jefeEmpleado);
        }

        public async Task<IList<JefeEmpleadoDTO>> getJefesEmpleadosByEmpleado(int nIdEmpleado, int nIdPeriodoLaboral)
        {
            return await repository.getJefesEmpleadosByEmpleado(nIdEmpleado, nIdPeriodoLaboral);
        }
    }
}
