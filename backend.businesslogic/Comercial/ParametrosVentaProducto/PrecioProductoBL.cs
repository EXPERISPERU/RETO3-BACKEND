using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.businesslogic.Interfaces.Comercial.ParametrosVentaProducto;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.ParametrosVentaProducto
{
    public class PrecioProductoBL : IPrecioProductoBL
    {
        IPrecioProductoRepository repository;

        public PrecioProductoBL(IPrecioProductoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<PrecioProductoDTO>> getListPrecioProductoAdicional(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListPrecioProductoAdicional(nIdUsuario, nIdCompania);
        }        

        public async Task<IList<SelectDTO>> getSelectItem(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectItem(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsPrecioProducto(PrecioProductoDTO precioProducto)
        {
            return await repository.InsPrecioProducto(precioProducto);
        }

        public async Task<SqlRspDTO> UpdPrecioProducto(PrecioProductoDTO precioProducto)
        {
            return await repository.UpdPrecioProducto(precioProducto);
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

        public async Task<IList<PrecioProductoDTO>> getListPrecioProductoEspecifica()
        {
            return await repository.getListPrecioProductoEspecifica();
        }
    }
}
