using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Data;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence.Repository
{
    public class CartItemRepository : Repository<CartItem>, ICartRepository
    {

        public CartItemRepository(OrderDbContext context) : base(context)
        {
        }


        public async Task<List<CartItem>> UserCartItems(string userId)
        {
            return await Context.CartItems.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<CartItem> CartItemsById(Guid cartId)
        {
            return await Context.CartItems.FirstOrDefaultAsync(x => x.CartItemId == cartId);
        }

        public async Task<bool> CheckOut(string userId)
        {
            var cartItem = await Context.CartItems.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
            if (cartItem.Any())
            {
                //delete all of them and return tru
                foreach (var item in cartItem)
                {
                    Context.CartItems.Remove(item);
                    await Context.SaveChangesAsync();
                }

                return true;
            }

            return false;
        }


        
    }
}
