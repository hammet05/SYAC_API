namespace Pedidos.Application.DTOs
{
    public class CrearDetallePedidoDto
    {
        public Guid ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}
