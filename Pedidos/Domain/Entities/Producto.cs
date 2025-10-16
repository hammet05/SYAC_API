using Pedidos.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain.Entities
{
    public class Producto: BaseEntity
    {
       
        [Required]
        [MaxLength(20)]
        public string? Codigo { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorUnitario { get; set; }

        public ICollection<DetallePedido>? Detalles { get; set; }
    }

}
