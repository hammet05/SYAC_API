namespace Pedidos.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository clientes { get; }
        IOrdenPedidoRepository ordenPedidos { get; }
        Task SaveAsync();
    }
}
