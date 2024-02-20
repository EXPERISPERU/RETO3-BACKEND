using backend.businesslogic.Comercial;
using backend.businesslogic.Comercial.ParametrosVentaLote;
using backend.businesslogic.Comercial.ParametrosVentaProducto;
using backend.businesslogic.Contabilidad;
using backend.businesslogic.Contratos;
using backend.businesslogic.Dealers;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.businesslogic.Interfaces.Comercial.ParametrosVentaProducto;
using backend.businesslogic.Interfaces.Contabilidad;
using backend.businesslogic.Interfaces.Contratos;
using backend.businesslogic.Interfaces.Dealers;
using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Proyectos;
using backend.businesslogic.Interfaces.Seguridad;
using backend.businesslogic.Maestros;
using backend.businesslogic.Proyectos;
using backend.businesslogic.Seguridad;
using backend.repository.Comercial;
using backend.repository.Comercial.ParametrosVentaLote;
using backend.repository.Comercial.ParametrosVentaProducto;
using backend.repository.Contabilidad;
using backend.repository.Contratos;
using backend.repository.Dealers;
using backend.repository.Interfaces;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaProducto;
using backend.repository.Interfaces.Contabilidad;
using backend.repository.Interfaces.Contratos;
using backend.repository.Interfaces.Dealers;
using backend.repository.Interfaces.Maestros;
using backend.repository.Interfaces.Proyectos;
using backend.repository.Interfaces.Seguridad;
using backend.repository.Maestros;
using backend.repository.Proyectos;
using backend.repository.Seguridad;

namespace backend.services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IOpcionRepository, OpcionRepository>();

            services.AddScoped<IElementoSistemaRepository, ElementoSistemaRepository>();
            services.AddScoped<IUbigeoRepository, UbigeoRepository>();
            services.AddScoped<ICompaniaRepository, CompaniaRepository>();
            services.AddScoped<IOficinaRepository, OficinaRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IMonedaRepository, MonedaRepository>();
            services.AddScoped<ICompaniaMonedaRepository, CompaniaMonedaRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<ICorrelativoRepository, CorrelativoRepository>();

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IDatoContactoRepository, DatoContactoRepository>();

            services.AddScoped<IEmpresaDealerRepository, EmpresaDealerRepository>();
            services.AddScoped<IAgenteDealerRepository, AgenteDealerRepository>();
            services.AddScoped<IProveedorAgenteDealerRepository, ProveedorAgenteDealerRepository>();
            services.AddScoped<IReferidoRepository, ReferidoRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IListaPrecioRepository, ListaPrecioRepository>();
            services.AddScoped<IPrecioRepository, PrecioRepository>();
            services.AddScoped<IAsignacionPrecioRepository, AsignacionPrecioRepository>();
            services.AddScoped<IDescuentoLoteRepository, DescuentoLoteRepository>();
            services.AddScoped<IInicialLoteRepository, InicialLoteRepository>();
            services.AddScoped<ICuotaLoteRepository, CuotaLoteRepository>();
            services.AddScoped<ILotesDisponiblesRepository, LotesDisponiblesRepository>();
            services.AddScoped<ICotizacionRepository, CotizacionRepository>();
            services.AddScoped<IPrecioServicioRepository, PrecioServicioRepository>();
            services.AddScoped<IReservaLoteRepository, ReservaLoteRepository>();
            services.AddScoped<IPreContratoLoteRepository, PreContratoLoteRepository>();
            services.AddScoped<IVentaLoteRepository, VentaLoteRepository>();
            services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();

            services.AddScoped<IProyectoRepository, ProyectoRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IManzanaRepository, ManzanaRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();

            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IReporteVentasRepository, ReporteVentasRepository>();
            
            services.AddScoped<IContratoRepository, ContratoRepository>();

            services.AddScoped<IComprobanteRepository, ComprobanteRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IAuthBL, AuthBL>();
            services.AddScoped<IPerfilBL, PerfilBL>();
            services.AddScoped<IOpcionBL, OpcionBL>();

            services.AddScoped<IElementoSistemaBL, ElementoSistemaBL>();
            services.AddScoped<IUbigeoBL, UbigeoBL>();
            services.AddScoped<ICompaniaBL, CompaniaBL>();
            services.AddScoped<IOficinaBL, OficinaBL>();
            services.AddScoped<IEmpleadoBL, EmpleadoBL>();
            services.AddScoped<IProveedorBL, ProveedorBL>();
            services.AddScoped<IMonedaBL, MonedaBL>();
            services.AddScoped<ICompaniaMonedaBL, CompaniaMonedaBL>();
            services.AddScoped<ISerieBL, SerieBL>();
            services.AddScoped<ICorrelativoBL, CorrelativoBL>();

            services.AddScoped<IPersonaBL, PersonaBL>();
            services.AddScoped<IDireccionBL, DireccionBL>();
            services.AddScoped<IDatoContactoBL, DatoContactoBL>();

            services.AddScoped<IEmpresaDealerBL, EmpresaDealerBL>();
            services.AddScoped<IAgenteDealerBL, AgenteDealerBL>();
            services.AddScoped<IProveedorAgenteDealerBL, ProveedorAgenteDealerBL>();
            services.AddScoped<IReferidoBL, ReferidoBL>();

            services.AddScoped<IClienteBL, ClienteBL>();
            services.AddScoped<IListaPrecioBL, ListaPrecioBL>();
            services.AddScoped<IPrecioBL, PrecioBL>();
            services.AddScoped<IAsignacionPrecioBL, AsignacionPrecioBL>();
            services.AddScoped<IDescuentoLoteBL, DescuentoLoteBL>();
            services.AddScoped<IInicialLoteBL, InicialLoteBL>();
            services.AddScoped<ICuotaLoteBL, CuotaLoteBL>();
            services.AddScoped<ILotesDisponiblesBL, LotesDisponiblesBL>();
            services.AddScoped<ICotizacionBL, CotizacionBL>();
            services.AddScoped<IPrecioServicioBL, PrecioServicioBL>();
            services.AddScoped<IReservaLoteBL, ReservaLoteBL>();
            services.AddScoped<IPreContratoLoteBL, PreContratoLoteBL>();
            services.AddScoped<IVentaLoteBL, VentaLoteBL>();
            services.AddScoped<IBeneficiarioBL, BeneficiarioBL>();

            services.AddScoped<IProyectoBL, ProyectoBL>();
            services.AddScoped<ISectorBL, SectorBL>();
            services.AddScoped<IManzanaBL, ManzanaBL>();
            services.AddScoped<ILoteBL, LoteBL>();

            services.AddScoped<IItemBL, ItemBL>();

            services.AddScoped<IReporteVentasBL, ReporteVentasBL>();
            services.AddScoped<IContratoBL, ContratoBL>();

            services.AddScoped<IComprobanteBL, ComprobanteBL>();
        }
    }
}
