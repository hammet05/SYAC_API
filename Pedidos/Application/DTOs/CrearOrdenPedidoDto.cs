using Pedidos.Domain.Common;
using Pedidos.Domain.Entities;

namespace Pedidos.Application.DTOs
{
    public class CrearOrdenPedidoDto
    {
        public Guid ClienteId { get; set; }
        public EstadoPedido Estado { get; set; } = EstadoPedido.Registrado;

        public string? DireccionEntrega { get; set; }

        public PrioridadPedido? Prioridad { get; set; }

        public decimal ValorTotal { get; set; }
      
        public List<CrearDetallePedidoDto> Detalles { get; set; } = new();
    }
}
