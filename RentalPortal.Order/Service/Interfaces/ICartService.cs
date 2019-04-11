using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;

namespace RentalPortal.Order.Service.Interfaces
{
    public interface ICartService
    {
        Task<string> CreateCartItem(CartItemDto cart);
        Task<string> UpdateCartItem(CartItemDto cart);
        Task<List<CartItemDto>> UserCartItems(string userId);
        Task<CartItemDto> CartItemsByIdAsync(Guid cartId);
        Task<bool> CheckOut(string userId);
        Task DeleteCartItem(Guid cartId);
    }
}
