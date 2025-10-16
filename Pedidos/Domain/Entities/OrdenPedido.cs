using Pedidos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain.Entities
{
    public class OrdenPedido : BaseEntity
    {
       
        [Required]
        public Guid ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public EstadoPedido Estado { get; set; } = EstadoPedido.Registrado;

        [Required]
        [MaxLength(200)]
        public string? DireccionEntrega { get; set; }

        public PrioridadPedido? Prioridad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        public ICollection<DetallePedido>? Detalles { get; set; }
    }

}
