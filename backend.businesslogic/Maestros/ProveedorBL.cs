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
    public class ProveedorBL : IProveedorBL
    {
        IProveedorRepository repository;
        public ProveedorBL(IProveedorRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ProveedorDTO>> getListProveedor()
        {
            return await repository.getListProveedor();
        }

        public async Task<ProveedorDTO> getProveedorByID(int nIdProveedor)
        {
            return await repository.getProveedorByID(nIdProveedor);
        }

        public async Task<ProveedorDTO> findProveedorByRUC(string? sDNI, string? sRUC)
        {
            return await repository.findProveedorByRUC(sDNI, sRUC);    
        }

        public async Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor)
        {
            return await repository.InsProveedor(proveedor);        
        }

        public async Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor)
        {
            return await repository.UpdProveedor(proveedor);            
        }

        public async Task<SqlRspDTO> InsJefeComercialProveedor(JefeComercialDTO jefeComercial)
        {
            return await repository.InsJefeComercialProveedor(jefeComercial);
        }

        public async Task<IList<JefeComercialDTO>> getJefesComercialesByProveedor(int nIdProveedor)
        {
            return await repository.getJefesComercialesByProveedor(nIdProveedor);
        }

        public async Task<IList<SelectDTO>> getSelectJefesComerciales(int nIdCompania)
        {
            return await repository.getSelectJefesComerciales(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectTipoPersona() 
        {
            return await repository.getSelectTipoPersona();
        }

    }
}
