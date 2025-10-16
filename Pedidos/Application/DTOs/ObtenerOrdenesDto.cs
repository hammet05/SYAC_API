using Pedidos.Domain.Common;
using Pedidos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Application.DTOs
{
    public class ObtenerOrdenesDto
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; } = null!;        
        public PrioridadPedido? Prioridad { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal ValorTotal { get; set; }

        public List<ObtenerDetallePedidoDto> Detalles { get; set; } = new();

    }
}
