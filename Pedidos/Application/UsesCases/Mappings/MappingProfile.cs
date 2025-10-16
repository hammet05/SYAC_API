using AutoMapper;
using Pedidos.Application.DTOs;
using Pedidos.Domain.Common;
using Pedidos.Domain.Entities;

namespace Pedidos.Application.UsesCases.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, CrearClienteDto>().ReverseMap()
                                            .ForMember(dest => dest.Ordenes, opt => opt.Ignore());

            CreateMap<Cliente, ObtenerClientesDto>().ReverseMap()                                           
                                            .ForMember(dest => dest.Ordenes, opt => opt.Ignore());

            

            CreateMap<CrearDetallePedidoDto, DetallePedido>().ReverseMap();

            CreateMap<OrdenPedido, CrearOrdenPedidoDto>().ReverseMap()
                                                         .ForMember(dest => dest.Estado, opt => opt.MapFrom(_ => EstadoPedido.Registrado))
                                                         .ForMember(dest => dest.ValorTotal, opt => opt.Ignore())
                                                         .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));


            CreateMap<OrdenPedido, ObtenerOrdenesDto>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));

            CreateMap<DetallePedido, ObtenerDetallePedidoDto>();

            

        }
            
    }
}
