using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;

namespace backend.businesslogic.Comercial
{
    public class ReporteVentasBL : IReporteVentasBL
    {
        IReporteVentasRepository repository;

        public ReporteVentasBL(IReporteVentasRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdUsuario, nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdUsuario, int nIdProyecto)
        {
            return await repository.getSelectSectorByProyecto(nIdUsuario, nIdProyecto);        
        }

        public async Task<IList<SelectDTO>> getSelectManzanaByProyectoSector(int nIdUsuario, int nIdProyecto, int? nIdSector)
        {
            return await repository.getSelectManzanaByProyectoSector(nIdUsuario, nIdProyecto, nIdSector);            
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdUsuario, int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdUsuario, nIdManzana);                
        }

        public async Task<IList<SelectDTO>> getSelectItemVentas(int nIdUsuario)
        {
            return await repository.getSelectItemVentas(nIdUsuario);                    
        }

        public async Task<IList<SelectDTO>> getSelectTipoGestion(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectTipoGestion(nIdUsuario, nIdCompania);                        
        }

        public async Task<IList<SelectDTO>> getSelectDealerEmpleadoByTipoGestion(int nIdUsuario, int nIdCompania, int nIdTipoGestion)
        {
            return await repository.getSelectDealerEmpleadoByTipoGestion(nIdUsuario, nIdCompania, nIdTipoGestion);                            
        }

        public async Task<IList<ReporteVentasDTO>> getListReporteVentas(ReporteVentasFiltrosDTO filtros)
        {
            return await repository.getListReporteVentas(filtros);
        }
    }
}
