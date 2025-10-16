using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Domain.Entities;
using Pedidos.Infrastructure.Context;

namespace Pedidos.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClienteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
