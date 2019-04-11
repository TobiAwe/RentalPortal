using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence;
using RentalPortal.Order.Persistence.Repository.Interfaces;
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

        public async Task<CartItemDto> CartItemsByIdAsync(Guid cartId)
        {

            var item = _uow.Carts.CartItemsById(cartId);
            if (item == null)
            {
                throw await _helper.GetExceptionAsync("Cart entry does not exist");
            }
            return Mapper.Map<CartItemDto>(item);
        }

        public Task<bool> CheckOut(string userId)
        {
            return _uow.Carts.CheckOut(userId);
        }

        public async Task DeleteCartItem(Guid cartId)
        {
            var item =  _uow.Carts.Get(cartId);
            _uow.Carts.Remove(item);
            await _uow.CompleteAsync();
        }

        public async Task<string> CreateCartItem(CartItemDto cart)
        {
            var c = new CartItem
            {
                EquipmentId = cart.EquipmentId,
                UserId = cart.UserId,
                DateCreated = DateTime.Now,
                NoOfDays = cart.NoOfDays
            };

            _uow.Carts.Add(c);
            await _uow.CompleteAsync();
            return c.CartItemId.ToString();
        }

        public async Task<string> UpdateCartItem(CartItemDto cart)
        {
            var editor = _uow.Carts.CartItemsById(cart.CartItemId);
            if (editor != null)
            {
                editor.Result.NoOfDays = cart.NoOfDays;
                editor.Result.DateCreated = cart.DateCreated;
                editor.Result.UserId = cart.UserId;
                editor.Result.EquipmentId = cart.EquipmentId;
                await _uow.CompleteAsync();
                return editor.Result.CartItemId.ToString();
            }

            return "";

        }

        public async Task<List<CartItemDto>> UserCartItems(string userId)
        {
            var data= await _uow.Carts.UserCartItems(userId);
            return Mapper.Map<List<CartItemDto>>(data);
        }
    }
}
