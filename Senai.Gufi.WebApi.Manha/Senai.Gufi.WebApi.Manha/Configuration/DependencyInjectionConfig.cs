using Microsoft.Extensions.DependencyInjection;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<IPresencaRepository, PresencaRepository>();
            services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

            services.AddScoped<GufiContext>();

            return services;
        }
    }
}
