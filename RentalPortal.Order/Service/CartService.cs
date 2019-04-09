using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Service
{
    public class CartService: ICartService
    {

        private readonly IUnitOfWork _uow;
        private readonly IServiceHelper _helper;

        public CartService(IUnitOfWork uow, IServiceHelper helper)
        {
            _uow = uow;
            _helper = helper;
        }

        public Task<CartItem> CartItemsById(Guid cartId)
        {
            
            throw new NotImplementedException();
        }

        public Task<bool> CheckOut(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateCart(CartItemDto cart)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateCartItem(CartItemDto cart)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItem>> UserCartItems(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
