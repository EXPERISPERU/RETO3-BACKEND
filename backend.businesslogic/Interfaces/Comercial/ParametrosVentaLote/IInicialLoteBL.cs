using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IInicialLoteBL
    {
        Task<IList<InicialLoteDTO>> getListInicialLote();
        Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote);
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<IList<SelectDTO>> getSelectMoneda();
        Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote);
    }
}
