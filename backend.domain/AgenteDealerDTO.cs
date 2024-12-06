namespace backend.domain
{
    public class selectListAgenteDealerDTO 
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProveedor { get; set;  }
    }

    public class AgenteDealerDTO : PersonaDTO
    {
        public int? nIdAgenteDealer { get; set; }
        public string? sProveedor { get; set; }
        public int? nIdPerfil { get; set; }
        public int? nIdProveedorAgente { get; set; }
    }
}
