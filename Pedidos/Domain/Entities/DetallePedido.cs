using Pedidos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
       
        [Required]
        public Guid OrdenPedidoId { get; set; }

        public OrdenPedido? OrdenPedido { get; set; }

        [Required]
        public Guid ProductoId { get; set; }

        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcial { get; set; }
    }

}
