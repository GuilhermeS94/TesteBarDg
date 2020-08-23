using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteBarDg.Infra.ExternalServices;
using TesteBarDg.Domain.ExternalServices;

namespace TesteBarDg
{
    public static class Configs
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddInfrastructureServices();

            return services;
        }

        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IGerarExtratoExternalService, GerarExtratoExternalService>();
            services.AddScoped<IItemCompradoExternalService, ItemCompradoExternalService>();
            services.AddScoped<IListarItensMenuExternalService, ListarItensMenuExternalService>();
            services.AddScoped<IResetarComandaExternalService, ResetarComandaExternalService>();

            return services;
        }
    }
}
