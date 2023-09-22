using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Dealers
{
    public class ReferidoBL : IReferidoBL
    {
        IReferidoRepository repository;

        public ReferidoBL(IReferidoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ReferidoDTO>> getListReferido()
        {
            return await repository.getListReferido();
        }

        public async Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente)
        {
            return await repository.getListReferidoByCliente(nIdCliente);
        }

        public async Task<int> getIdAgenteDealer(int nIdUsuario)
        {
            return await repository.getIdAgenteDealer(nIdUsuario);
        }

        public async Task<SqlRspDTO> InsReferido(ReferidoDTO referido)
        {
            return await repository.InsReferido(referido);
        }
    }
}
