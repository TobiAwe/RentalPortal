using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
{
    public interface ICartRepository : IRepository<CartItem>
    {
        Task<List<CartItem>> UserCartItems(string userId);
        Task<CartItem> CartItemsById(Guid cartId);
        Task<bool> CheckOut(string userId);




    }
}
