using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IMapaBL
    {
        Task<List<FeatureDTO>> getListLotes();
    }
}
