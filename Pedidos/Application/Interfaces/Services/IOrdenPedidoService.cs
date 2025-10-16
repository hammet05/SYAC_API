using Pedidos.Application.Common;
using Pedidos.Application.DTOs;

namespace Pedidos.Application.Interfaces.Services
{
    public interface IOrdenPedidoService
    {
        Task<Response<bool>> Create(CrearOrdenPedidoDto ordenPedidoDto);
        Task<Response<IEnumerable<ObtenerOrdenesDto>>> GetAllOrders();
    }
}
