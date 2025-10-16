using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pedidos.Application.Common;
using Pedidos.Application.DTOs;
using Pedidos.Application.Interfaces.Persistence;
using Pedidos.Application.Interfaces.Services;
using Pedidos.Application.UsesCases.Clientes;
using Pedidos.Domain.Entities;
using System.Linq.Expressions;

namespace Pedidos.Application.UsesCases.Pedidos
{
    public class OrdenPedidoService : IOrdenPedidoService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<ClienteService>? _logger;

        public OrdenPedidoService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<ClienteService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Create(CrearOrdenPedidoDto ordenPedidoDto)
        {
            const string? methodName = nameof(Create);

            try
            {
                
                var pedido = _mapper!.Map<OrdenPedido>(ordenPedidoDto);
                

                pedido.ValorTotal = pedido!.Detalles!.Sum(d => d.Cantidad * d.ValorUnitario);      

                await _unitOfWork!.ordenPedidos.Add(pedido);
                await _unitOfWork.SaveAsync();

                return new Response<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Orden  creada exitosamente."
                };

            }
            catch (Exception ex)
            {

                _logger?.LogError(ex, $"Fallo al crear la orden {methodName}");
                return new Response<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Fallo al crear la orden."
                };
            }
        }

        public async Task<Response<IEnumerable<ObtenerOrdenesDto>>> GetAllOrders()
        {
            const string? methodName = nameof(GetAllOrders);

            var ordenesList = await _unitOfWork!.ordenPedidos.GetAll(filter: t => t.IsActive == true,
                                                               orderBy: q => q.OrderBy(c => c.Cliente),
                                                               isTracking: false,
                                                                u => u.Cliente!
                                                               );

            if (ordenesList.Any())
            {
                _logger!.LogInformation("{MethodName}: Clientes obtenidos exitosamente", methodName);

                var listaOrdenesDto = _mapper!.Map<IEnumerable<ObtenerOrdenesDto>>(ordenesList);

                return new Response<IEnumerable<ObtenerOrdenesDto>>
                {
                    Data = listaOrdenesDto,
                    IsSuccess = true,
                    Message = "Ordenes obtenidas exitosamente."
                };
            }
            else
            {

                _logger!.LogInformation("{MethodName}: Ninguna orden encontrada", methodName);

                return new Response<IEnumerable<ObtenerOrdenesDto>>
                {
                    Data = Enumerable.Empty<ObtenerOrdenesDto>(),
                    IsSuccess = true,
                    Message = "Ninguna orden encontrada."
                };
            }
        }
    }
    
}
