using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class CuotaLoteBL : ICuotaLoteBL
    {
        ICuotaLoteRepository repository;

        public CuotaLoteBL(){}

        public CuotaLoteBL(ICuotaLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos()
        {
            return await repository.getListCuotaLoteProyectos();
        }

        public async Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote)
        {
            return await repository.getCuotaLoteByID(nIdCuotaLote);
        }

        public async Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote)
        {
            return await repository.InsCuotaLoteProyecto(cuotaLote);
        }
    }
}
