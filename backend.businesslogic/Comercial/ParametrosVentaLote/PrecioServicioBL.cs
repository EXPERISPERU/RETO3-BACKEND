using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class PrecioServicioBL : IPrecioServicioBL
    {
        IPrecioServicioRepository repository;

        public PrecioServicioBL(IPrecioServicioRepository _repository)
        {
            repository = _repository;
        }
        
        public async Task<IList<PrecioServicioDTO>> getListPrecioServicioGeneral()
        {
            return await repository.getListPrecioServicioGeneral();
        }
        
        public async Task<IList<PrecioServicioDTO>> getListPrecioServicioEspecifica()
        {
            return await repository.getListPrecioServicioEspecifica();
        }
        
        public async Task<PrecioServicioDTO> getPrecioServicioByID(int nIdPrecioServicio)
        {
            return await repository.getPrecioServicioByID(nIdPrecioServicio);
        }
        
        public async Task<IList<SelectDTO>> getSelectItem()
        {
            return await repository.getSelectItem();
        }
        
        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }
        
        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }
        
        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            return await repository.getSelectSectorByProyecto(nIdProyecto);
        }
        
        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            return await repository.getSelectManzanaBySector(nIdSector);
        }
        
        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }
        
        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }
        
        public async Task<SqlRspDTO> InsPrecioServicio(PrecioServicioDTO precioServicio)
        {
            return await repository.InsPrecioServicio(precioServicio);
        }
        
        public async Task<SqlRspDTO> UpdPrecioServicio(PrecioServicioDTO precioServicio)
        {
            return await repository.UpdPrecioServicio(precioServicio);
        }
    }
}
