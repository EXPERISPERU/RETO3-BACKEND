using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IInicialLoteRepository
    {
        Task<IList<InicialLoteDTO>> getListInicialLote();
        Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote);
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<IList<SelectDTO>> getSelectMoneda();
        Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote);
    }
}
