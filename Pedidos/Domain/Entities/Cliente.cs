using Pedidos.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain.Entities
{
    public class Cliente : BaseEntity
    {        

        [Required]
        [MaxLength(20)]
        public string? Identificacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(200)]
        public string? Direccion { get; set; }

        public ICollection<OrdenPedido>? Ordenes { get; set; }
    }

}
