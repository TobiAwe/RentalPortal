using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Mapping
{
   
    internal class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .AfterMap((cartItem, dto) =>
                {
                    dto.Equipment =cartItem.Equipment.Name.Trim();
                });
        }
    }
}
