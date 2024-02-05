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

        public async Task<ProveedorDTO> findProveedorByRUC(string sRUC)
        {
            return await repository.findProveedorByRUC(sRUC);    
        }

        public async Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor)
        {
            return await repository.InsProveedor(proveedor);        
        }

        public async Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor)
        {
            return await repository.UpdProveedor(proveedor);            
        }
    }
}
