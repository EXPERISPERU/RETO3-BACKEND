using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class InteresCuotaBL : IInteresCuotaBL
    {
        IInteresCuotaRepository repository;

        public InteresCuotaBL(IInteresCuotaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<InteresCuotaDTO> getListInteresCuotaById(int nIdProyecto, int nIdCuotaLote)
        {
            return await repository.getListInteresCuotaById(nIdProyecto, nIdCuotaLote);
        }

        public async Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota)
        {
            return await repository.InsInteresCuota(interesCuota);
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroInteres()
        {
            return await repository.getListMaestroInteres();
        }

        public async Task<ProyectoDTO> getProyectoByID(int nIdProyecto)
        {
            return await repository.getProyectoByID(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            return await repository.getSelectTipoDescuento();
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }
    }
}
