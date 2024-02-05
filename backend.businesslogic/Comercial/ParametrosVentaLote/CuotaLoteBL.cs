using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class CuotaLoteBL : ICuotaLoteBL
    {
        ICuotaLoteRepository repository;

        public CuotaLoteBL(ICuotaLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos()
        {
            return await repository.getListCuotaLoteProyectos();
        }

        public async Task<IList<CuotaLoteDTO>> getListCuotaLoteEspecifica()
        {
            return await repository.getListCuotaLoteEspecifica();
        }

        public async Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote)
        {
            return await repository.getCuotaLoteByID(nIdCuotaLote);
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote)
        {
            return await repository.InsCuotaLoteProyecto(cuotaLote);
        }

        public async Task<SqlRspDTO> UpdCuotaLoteProyecto(CuotaLoteDTO cuotaLote)
        {
            return await repository.UpdCuotaLoteProyecto(cuotaLote);
        }
    }
}
