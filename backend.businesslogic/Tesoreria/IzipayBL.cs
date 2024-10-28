using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using backend.repository.Interfaces.Tesoreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Tesoreria
{
    public class IzipayBL : IIzipayBL
    {
        IIzipayRepository repository;

        public IzipayBL(IIzipayRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<IzipayComercioDTO>> getListComerciosByCompania(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListComerciosByCompania(nIdUsuario, nIdCompania);
        }

        public async Task<IzipayComercioDTO> getComerciosById(int nIdComercio)
        {
            return await repository.getComerciosById(nIdComercio);
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsIzipayComercio(IzipayComercioDTO comercio)
        {
            return await repository.InsIzipayComercio(comercio);
        }

        public async Task<SqlRspDTO> UpdIzipayComercio(IzipayComercioDTO comercio)
        {
            return await repository.UpdIzipayComercio(comercio);
        }

        public async Task<IList<IzipayVoucherDTO>> getListVouchersByCompania(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListVouchersByCompania(nIdUsuario, nIdCompania);
        }

        public async Task<IzipayVoucherDTO> getVoucherById(int nIdVoucher)
        {
            return await repository.getVoucherById(nIdVoucher);
        }

        public async Task<IList<SelectDTO>> getSelectVoucherTipo()
        {
            return await repository.getSelectVoucherTipo();
        }

        public async Task<IList<SelectDTO>> getSelectVoucherProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectVoucherProyectoByCompania(nIdUsuario, nIdCompania);
        }

        public async Task<IList<IzipayComercioDTO>> getSelectVoucherComercioByTipoProyecto(int nIdUsuario, int nIdProyecto, int nIdTipoVoucher)
        {
            return await repository.getSelectVoucherComercioByTipoProyecto(nIdUsuario, nIdProyecto, nIdTipoVoucher);
        }

        public async Task<IList<SelectDTO>> getSelectVoucherMoneda(int nIdUsuario, int nIdCompania)
        {
            return await repository.getSelectVoucherMoneda(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsIzipayVoucher(IzipayVoucherDTO voucher)
        {
            return await repository.InsIzipayVoucher(voucher);
        }

        public async Task<SqlRspDTO> UpdIzipayVoucher(IzipayVoucherDTO voucher)
        { 
            return await repository.UpdIzipayVoucher(voucher);
        }
    }
}
