namespace backend.domain
{
    public class AgenteDealerDTO : PersonaDTO
    {
        public int? nIdAgenteDealer { get; set; }
        public string? sProveedor { get; set; }
        public int? nIdPerfil { get; set; }
        public int? nIdProveedorAgente { get; set; }
    }
}
