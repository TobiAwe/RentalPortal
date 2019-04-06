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
            var data = from order in Context.OrderRequest
                orderby order.DateCreated descending
                select new OrderDto
                {
                    OrderId = order.OrderId,
                    Email = order.Email,
                    StartDate = order.StartDate,
                    EndDate = order.EndDate,
                    Equipment = order.Equipment.Name

                };
            return await data.AsNoTracking().ToListAsync();
        }

        public async Task<List<OrderDto>> GetCustomerOrdersAsync(string email)
        {
            var data = from order in Context.OrderRequest
                where order.Email==email
                orderby order.DateCreated descending
                select new OrderDto
                {
                    OrderId = order.OrderId,
                    Email = order.Email,
                    StartDate = order.StartDate,
                    EndDate = order.EndDate,
                    Equipment = order.Equipment.Name

                };
            return await data.AsNoTracking().ToListAsync();
        }
    }
}

