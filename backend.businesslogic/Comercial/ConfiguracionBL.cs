using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ConfiguracionBL: IConfiguracionBL
    {
        IConfiguracionRepository repository;

        public ConfiguracionBL(IConfiguracionRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ConfiguracionDTO>> getConfiguracionByIdProyecto(int nIdproyecto)
        {
            return await repository.getConfiguracionByIdProyecto(nIdproyecto);
        }

        public async Task<IList<ElementoSistemaDTO>> getListConceptoVenta()
        {
            return await repository.getListConceptoVenta();
        }

        public async Task<IList<ElementoSistemaDTO>> getListDocumentoVenta()
        {
            return await repository.getListDocumentoVenta();
        }

        public async Task<IList<ElementoSistemaDTO>> getListInteres()
        {
            return await repository.getListInteres();
        }

        public async Task<SqlRspDTO> InsConfiguracion(ConfiguracionDTO configuracion)
        {
            return await repository.InsConfiguracion(configuracion);
        }

        public async Task<SqlRspDTO> InsSistemaConfiguracionConcepto(ConfiguracionConceptoDTO configuracionConcepto)
        {
            return await repository.InsSistemaConfiguracionConcepto(configuracionConcepto);
        }
    }
}
