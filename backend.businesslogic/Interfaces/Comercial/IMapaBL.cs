using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IMapaBL
    {
        Task<FeatureCollectionDTO<MapaLoteDTO>> getListLotes();
        Task<FeatureCollectionDTO<MapaManzanaDTO>> getListManzanas();

    }
}
