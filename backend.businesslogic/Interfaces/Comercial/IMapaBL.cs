using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IMapaBL
    {
        Task<string> getListLotes();
    }
}
