using System;
using Microsoft.Extensions.DependencyInjection;

using backend.businesslogic;
using backend.businesslogic.Interfaces;
using backend.repository;
using backend.repository.Interfaces;

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
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IAuthBL, AuthBL>();
            services.AddScoped<IPerfilBL, PerfilBL>();
            services.AddScoped<IOpcionBL, OpcionBL>();
        }
    }
}
