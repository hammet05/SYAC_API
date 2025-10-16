using Pedidos.Application.Common;
using Pedidos.Application.DTOs;

namespace Pedidos.Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Response<bool>> Create(CrearClienteDto clienteDto);
        Task<Response<IEnumerable<ObtenerClientesDto>>> GetAllClients();
        
    }
}
