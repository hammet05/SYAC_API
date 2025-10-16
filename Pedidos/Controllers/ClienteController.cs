using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.DTOs;
using Pedidos.Application.Interfaces.Services;

namespace Pedidos.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService? _clienteService;

        public ClienteController(IClienteService? clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CrearClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Cliente no puede ser nulo");
            }
            var response = await _clienteService!.Create(clienteDto);
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
            var response = await _clienteService!.GetAllClients();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(new { response.Message });


        }
    }
}
