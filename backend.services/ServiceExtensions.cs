﻿using backend.businesslogic.Dealers;
using backend.businesslogic.Interfaces.Dealers;
using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Seguridad;
using backend.businesslogic.Maestros;
using backend.businesslogic.Seguridad;
using backend.repository.Dealers;
using backend.repository.Interfaces.Dealers;
using backend.repository.Interfaces.Maestros;
using backend.repository.Interfaces.Seguridad;
using backend.repository.Maestros;
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
        }
    }
}
