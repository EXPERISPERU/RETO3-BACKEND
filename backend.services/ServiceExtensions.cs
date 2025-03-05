
using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Maestros;
using Npgsql;
using System.Data;

using backend.businesslogic.Interfaces.Seguridad;
using backend.businesslogic.Seguridad;

using backend.repository.Interfaces.Maestros;
using backend.repository.Maestros;

using backend.repository.Interfaces.Seguridad;
using backend.repository.Seguridad;



namespace backend.services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services, string connectionString)
        {
            // Inyectar la conexi�n a PostgreSQL
            services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IAuthBL, AuthBL>();
            services.AddScoped<IPersonaBL, PersonaBL>();
        }
    }
}
