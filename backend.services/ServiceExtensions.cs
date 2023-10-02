using backend.businesslogic.Comercial;
using backend.businesslogic.Dealers;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Dealers;
using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Proyectos;
using backend.businesslogic.Interfaces.Seguridad;
using backend.businesslogic.Maestros;
using backend.businesslogic.Proyectos;
using backend.businesslogic.Seguridad;
using backend.repository.Comercial;
using backend.repository.Dealers;
using backend.repository.Interfaces.Comercial;
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

            services.AddScoped<IPersonaRepository, PersonaRepository>();

            services.AddScoped<IEmpresaDealerRepository, EmpresaDealerRepository>();
            services.AddScoped<IAgenteDealerRepository, AgenteDealerRepository>();
            services.AddScoped<IEmpresaDealerAgenteRepository, EmpresaDealerAgenteRepository>();
            services.AddScoped<IReferidoRepository, ReferidoRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IListaPrecioRepository, ListaPrecioRepository>();
            services.AddScoped<IPrecioRepository, PrecioRepository>();

            services.AddScoped<IProyectoRepository, ProyectoRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IManzanaRepository, ManzanaRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();

            services.AddScoped<IItemRepository, ItemRepository>();
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

            services.AddScoped<IPersonaBL, PersonaBL>();

            services.AddScoped<IEmpresaDealerBL, EmpresaDealerBL>();
            services.AddScoped<IAgenteDealerBL, AgenteDealerBL>();
            services.AddScoped<IEmpresaDealerAgenteBL, EmpresaDealerAgenteBL>();
            services.AddScoped<IReferidoBL, ReferidoBL>();

            services.AddScoped<IClienteBL, ClienteBL>();
            services.AddScoped<IListaPrecioBL, ListaPrecioBL>();
            services.AddScoped<IPrecioBL, PrecioBL>();

            services.AddScoped<IProyectoBL, ProyectoBL>();
            services.AddScoped<ISectorBL, SectorBL>();
            services.AddScoped<IManzanaBL, ManzanaBL>();
            services.AddScoped<ILoteBL, LoteBL>();

            services.AddScoped<IItemBL, ItemBL>();
        }
    }
}
