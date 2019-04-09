using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Service.Interfaces
{
    public interface ICartService
    {
        Task<string> CreateCart(CartItemDto cart);
        Task<string> UpdateCartItem(CartItemDto cart);
        Task<List<CartItem>> UserCartItems(string userId);
        Task<CartItem> CartItemsById(Guid cartId);
        Task<bool> CheckOut(string userId);
    }
}
