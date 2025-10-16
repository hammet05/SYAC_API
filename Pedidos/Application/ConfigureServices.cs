using Pedidos.Application.Interfaces.Services;
using Pedidos.Application.UsesCases.Clientes;
using Pedidos.Application.UsesCases.Mappings;
using Pedidos.Application.UsesCases.Pedidos;

namespace Pedidos.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddScoped<IClienteService, ClienteService>();           
            services.AddScoped<IOrdenPedidoService, OrdenPedidoService>();           
            return services;
        }
    }
}
