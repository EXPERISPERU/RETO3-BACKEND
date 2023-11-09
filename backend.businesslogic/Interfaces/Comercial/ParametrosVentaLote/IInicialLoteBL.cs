using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IInicialLoteBL
    {
        Task<IList<InicialLoteDTO>> getListInicialLote();
        Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote);
        Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO inicialLote);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
    }
}
