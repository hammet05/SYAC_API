using AutoMapper;
using Pedidos.Application.Common;
using Pedidos.Application.DTOs;
using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Application.Interfaces.Services;
using Pedidos.Domain.Entities;

namespace Pedidos.Application.UsesCases.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<ClienteService>? _logger;

        public ClienteService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<ClienteService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Create(CrearClienteDto clienteDto)
        {
            const string? methodName = nameof(Create);

            try
            {

                var newTask = _mapper!.Map<Cliente>(clienteDto);

                await _unitOfWork!.clientes.Add(newTask);
                await _unitOfWork.SaveAsync();

                return new Response<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Cliente creado exitosamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"Fallo al crear un cliente {methodName}");
                return new Response<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Fallo al crear un cliente."
                };
            }
        }

        public async Task<Response<IEnumerable<ObtenerClientesDto>>> GetAllClients()
        {
            const string? methodName = nameof(GetAllClients);

            var clientesList = await _unitOfWork!.clientes.GetAll(filter: t => t.IsActive == true,
                                                               orderBy: q => q.OrderBy(c => c.Nombre),
                                                               isTracking: false
                                                               );

            if (clientesList.Any())
            {
                _logger!.LogInformation("{MethodName}: Clientes obtenidos exitosamente", methodName);

                var listaClientesDto = _mapper!.Map<IEnumerable<ObtenerClientesDto>>(clientesList);

                return new Response<IEnumerable<ObtenerClientesDto>>
                {
                    Data = listaClientesDto,
                    IsSuccess = true,
                    Message = "Clientes obtenidos exitosamente."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ningún cliente encontrado", methodName);

                return new Response<IEnumerable<ObtenerClientesDto>>
                {
                    Data = Enumerable.Empty<ObtenerClientesDto>(),
                    IsSuccess = true,
                    Message = "Ningun cliente encontrado."
                };
            }
        }
    }
}
