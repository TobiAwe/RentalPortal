using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository
{
    public class OrderRepository : Repository<OrderRequest, EfDbContext>, IOrderRepository
    {
        public OrderRepository(EfDbContext context) : base(context)
        {
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var data = from order in Context.OrderRequests
                orderby order.DateCreated descending
                select new OrderDto
                {
                    OrderId = order.OrderId,
                    Email = order.Email,
                    DateCreated = order.DateCreated,
                    OrderStatus = order.OrderStatus,
                    OrderRequestItems = order.OrderRequestItems
                };
            return await data.AsNoTracking().ToListAsync();
        }

        public async Task<List<OrderDto>> GetCustomerOrdersAsync(string email)
        {
            var data = from order in Context.OrderRequests
                where order.Email==email
                orderby order.DateCreated descending
                select new OrderDto
                {
                    OrderId = order.OrderId,
                    Email = order.Email,
                    DateCreated = order.DateCreated,
                    OrderStatus = order.OrderStatus,
                    OrderRequestItems = order.OrderRequestItems

                };
            return await data.AsNoTracking().ToListAsync();
        }
    }
}

