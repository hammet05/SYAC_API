using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.DTOs;
using Pedidos.Application.Interfaces.Services;
using Pedidos.Application.UsesCases.Clientes;

namespace Pedidos.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class OrdenPedidosController : ControllerBase
    {
        private readonly IOrdenPedidoService? _ordenPedidoService;

        public OrdenPedidosController(IOrdenPedidoService? ordenPedidoService)
        {
            _ordenPedidoService = ordenPedidoService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CrearOrdenPedidoDto crearOrdenPedidoDto)
        {
            if (crearOrdenPedidoDto == null)
            {
                return BadRequest("La orden no puede ser nula");
            }
            var response = await _ordenPedidoService!.Create(crearOrdenPedidoDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllTasks()
        {
            var response = await _ordenPedidoService!.GetAllOrders();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });


        }
    }
}

