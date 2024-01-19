using backend.businesslogic.Interfaces.Contratos;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Contratos
{
    public class ContratoBL : IContratoBL
    {
        IContratoRepository repository;

        public ContratoBL(IContratoRepository _repository)
        {
            this.repository = _repository;
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

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        { 
            return await repository.getSelectCondicionPago();
        }

        public async Task<IList<SelectDTO>> getSelectEstadoContrato()
        {
            return await repository.getSelectEstadoContrato();
        }

        public async Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros)
        {
            return await repository.getListContratoByFilters(contratoFiltros);
        }
    }
}
