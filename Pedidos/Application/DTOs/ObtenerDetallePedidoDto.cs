namespace Pedidos.Application.DTOs
{
    public class ObtenerDetallePedidoDto
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
