using Microsoft.EntityFrameworkCore;
using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Infrastructure.Context;
using Pedidos.Infrastructure.Repositories;

namespace Pedidos.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("connection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteRepository, ClienteRepository>();            
            services.AddScoped<IOrdenPedidoRepository, OrdenPedidosRepository>();            

            return services;
        }
    }
}
