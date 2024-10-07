using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IMapaBL
    {
        Task<FeatureCollectionDTO<MapaLoteDTO>> getListLotes();
        Task<FeatureCollectionDTO<MapaManzanaDTO>> getListManzanas();
        Task<FeatureCollectionDTO<MapaParqueDTO>> getListParques();
        Task<FeatureCollectionDTO<MapaEducacionDTO>> getListEducacion();
        Task<FeatureCollectionDTO<MapaOtrosFinesDTO>> getListOtrosFines();
        Task<FeatureCollectionDTO<MapaRecreacionDTO>> getListRecreacion();
        Task<FeatureCollectionDTO<MapaComercialDTO>> getListComercial();
        Task<FeatureCollectionDTO<MapaServicioDTO>> getListServicios();
        Task<FeatureCollectionDTO<MapaBermaDTO>> getListBermas();
        Task<FeatureCollectionDTO<MapaSectorDTO>> getListSectores();
        Task<FeatureCollectionDTO<MapaViaDTO>> getListVias();

    }
}
