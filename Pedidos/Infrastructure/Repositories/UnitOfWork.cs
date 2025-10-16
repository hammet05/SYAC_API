using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Infrastructure.Context;

namespace Pedidos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IClienteRepository clientes { get; }
        public IOrdenPedidoRepository ordenPedidos { get; }

      
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            clientes = new ClienteRepository(_applicationDbContext);
            ordenPedidos = new OrdenPedidosRepository(_applicationDbContext);
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
