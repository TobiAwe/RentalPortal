using RentalPortal.Order.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.DTO;

namespace RentalPortal.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IServiceHelper _helper;

        public OrderService(IUnitOfWork uow, IServiceHelper helper)
        {
            _uow = uow;
            _helper = helper;
        }


        public async Task<OrderDto> GetOrderById(int orderId)
        {
            var request = await _uow.Orders.GetAsync(orderId);

            if (request == null)
            {
                throw await _helper.GetExceptionAsync("Order entry does not exist");
            }
            return Mapper.Map<OrderDto>(request);
        }

        public async Task<List<OrderDto>> GetCustomerOrders(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetApprovedOrders()
        {
            throw new NotImplementedException();
        }

        public async Task CreateOrder(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrder(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}
