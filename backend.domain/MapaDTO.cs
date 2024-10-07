using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System;

namespace backend.domain
{
    public class GeometryDTO
    {
        public string type { get; set; }
        public object coordinates { get; set; } // List de Listas para soportar la estructura de MultiPolygon
    }

    public class LoteSqlDTO
    {
        public int estado { get; set; }
        public string? nombreEstado { get; set; }
        public decimal metraje { get; set; }
    }

    public class MapaLoteDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid_1 { get; set; }
        public int objectid { get; set; }
        public int secuencial { get; set; }
        public int idproyecto { get; set; }
        public string proyecto { get; set; }
        public int sector { get; set; }
        public int idinmueble { get; set; }
        public string manzana { get; set; }
        public string lote { get; set; }
        public string inmueble { get; set; }
        public string grupo { get; set; }
        public string terreno { get; set; }
        public string zonificaci { get; set; }
        public string descripcio { get; set; }
        public string ubicacion { get; set; }
        public double metrajefin { get; set; }
        public string estadoinmu { get; set; }
        public string idestado { get; set; }
        public string estadoplan { get; set; }
        public string aa { get; set; }
        public double shape_leng { get; set; }
        public int proyectoid { get; set; }
        public string bb_1 { get; set; }
        public string bb { get; set; }
        public double shape_le_1 { get; set; }
        public string precio { get; set; }
        public LoteSqlDTO loteSql { get; set; }
    }

    public class MapaManzanaDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaParqueDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaEducacionDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaOtrosFinesDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaRecreacionDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaComercialDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaServicioDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaBermaDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaSectorDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class MapaViaDTO
    {
        public int id { get; set; }
        public int qgs_fid { get; set; }
        public int objectid { get; set; }
        public string cod_mz { get; set; }
        public int proyectoid { get; set; }
        public double shape_leng { get; set; }
    }

    public class FeatureDTO<T>
    {
        public string type { get; set; }
        public GeometryDTO geometry { get; set; }
        public T properties { get; set; }
    }

    public class FeatureCollectionDTO<T>
    {
        public string type { get; set; }
        public List<FeatureDTO<T>> features { get; set; }
    }
}
