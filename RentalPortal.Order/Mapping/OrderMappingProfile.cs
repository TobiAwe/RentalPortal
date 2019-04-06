using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                .AfterMap((orderRequest, dto) =>
                {
                    dto.Equipment = orderRequest.Equipment?.Name.Trim();
                });
        }
    }
}
