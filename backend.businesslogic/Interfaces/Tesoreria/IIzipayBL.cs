using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Tesoreria
{
    public interface IIzipayBL
    {
        Task<IList<IzipayComercioDTO>> getListComerciosByCompania(int nIdUsuario, int nIdCompania);
        Task<IzipayComercioDTO> getComerciosById(int nIdComercio);
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsIzipayComercio(IzipayComercioDTO comercio);
        Task<SqlRspDTO> UpdIzipayComercio(IzipayComercioDTO comercio);
        Task<IList<IzipayVoucherDTO>> getListVouchersByCompania(int nIdUsuario, int nIdCompania);
        Task<IzipayVoucherDTO> getVoucherById(int nIdVoucher);
        Task<IList<SelectDTO>> getSelectVoucherTipo();
        Task<IList<SelectDTO>> getSelectVoucherProyectoByCompania(int nIdUsuario, int nIdCompania);
        Task<IList<SelectDTO>> getSelectVoucherComercioByTipoProyecto(int nIdUsuario, int nIdProyecto, int nIdTipoVoucher);
        Task<IList<SelectDTO>> getSelectVoucherMoneda(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsIzipayVoucher(IzipayVoucherDTO voucher);
        Task<SqlRspDTO> UpdIzipayVoucher(IzipayVoucherDTO voucher);
    }
}
