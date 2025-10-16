using System.ComponentModel.DataAnnotations;

namespace Pedidos.Application.DTOs
{
    public class ObtenerClientesDto
    {
        public string? Identificacion { get; set; }        
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }


    }
}
