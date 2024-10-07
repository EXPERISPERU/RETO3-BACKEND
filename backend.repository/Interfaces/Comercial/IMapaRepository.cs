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
        Task<string> getListLotes();
        Task<string> getListManzanas();
        Task<string> getListParques();
        Task<string> getListEducacion();
        Task<string> getListOtrosFines();
        Task<string> getListRecreacion();
        Task<string> getListComercial();
        Task<string> getListServicios();
        Task<string> getListBermas();
        Task<string> getListSectores();
        Task<string> getListVias();
    }
}
