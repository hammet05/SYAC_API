using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Domain.Entities;
using Pedidos.Infrastructure.Context;

namespace Pedidos.Infrastructure.Repositories
{
    public class OrdenPedidosRepository : Repository<OrdenPedido>, IOrdenPedidoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrdenPedidosRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
