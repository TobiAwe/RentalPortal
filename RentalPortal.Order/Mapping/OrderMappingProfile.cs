using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Mapping
{
    internal class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderRequest, OrderDto>()
                .AfterMap((orderRequest, dto) => { dto.OrderRequestItems = orderRequest.OrderRequestItems; });
        }
    }
}
