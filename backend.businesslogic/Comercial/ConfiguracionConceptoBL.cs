using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Comercial;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ConfiguracionConceptoBL: IConfiguracionConceptoBL
    {
        IConfiguracionConceptoRepository repository;

        public ConfiguracionConceptoBL(IConfiguracionConceptoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<tipoComprobante>> getListTipoComprante()
        {
            return await repository.getListTipoComprante();
        }

        public async Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto)
        {
            return await repository.ListConfiguracionConceptoByIdProyecto(nIdproyecto);
        }

        public async Task<IList<ElementoSistemaDTO>> getListMedioPago()
        {
            return await repository.getListMedioPago();
        }

        public async Task<SqlRspDTO> postInsConfiguracionConcepto(ConfiguracionConceptoDTO configuracion)
        {
            return await repository.postInsConfiguracionConcepto(configuracion);
        }

        public async Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdproyecto, int nIdConceptoVenta)
        {
            return await repository.GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(nIdproyecto, nIdConceptoVenta);
        }

        public async Task<IList<JsonFormatDTO>> getComprobanteMedioPago(int nIdCompania)
        {
            return await repository.getComprobanteMedioPago(nIdCompania);
        }
    }
}
