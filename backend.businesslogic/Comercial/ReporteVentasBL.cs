using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Comercial;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ReporteVentasBL : IReporteVentasBL
    {
        IReporteVentasRepository repository;

        public ReporteVentasBL(IReporteVentasRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ReporteVentasDTO>> getListReporteVentas()
        {
            return await repository.getListReporteVentas();
        }
    }
}
