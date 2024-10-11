using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IMapaRepository
    {
        Task<string> getListLotes(int nIdProyecto);
        Task<string> getListManzanas(int nIdProyecto);
        Task<string> getListParques(int nIdProyecto);
        Task<string> getListEducacion(int nIdProyecto);
        Task<string> getListOtrosFines(int nIdProyecto);
        Task<string> getListRecreacion(int nIdProyecto);
        Task<string> getListComercial(int nIdProyecto);
        Task<string> getListServicios(int nIdProyecto);
        Task<string> getListBermas(int nIdProyecto);
        Task<string> getListSectores(int nIdProyecto);
        Task<string> getListVias(int nIdProyecto);
    }
}
