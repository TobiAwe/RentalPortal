using RentalPortal.Order.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.Common.Enums;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Service.Interfaces;

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
            var orders =await _uow.Orders.GetCustomerOrdersAsync(email);
            return orders;
        }

        public async Task<List<OrderDto>> GetApprovedOrders()
        {
            var approved =await _uow.Orders.GetAllOrdersAsync();
            return approved;
        }

        public async Task CreateOrder(OrderDto order)
        {
            var entry = new OrderRequest
            {
                OrderStatus = OrderStatus.Approved,
                DateCreated = DateTime.UtcNow,
                Email = order.Email,
                OrderRequestItems = order.OrderRequestItems,
            };
            _uow.Orders.Add(entry);
            await _uow.CompleteAsync();
        }

        public async Task UpdateOrder(OrderDto order)
        {
            var request = await _uow.Orders.GetAsync(order.OrderId);

            if (request == null)
            {
                throw await _helper.GetExceptionAsync("Order entry does not exist");
            }
            request.Email = order.Email;
            request.DateCreated = order.DateCreated;
            request.OrderStatus = order.OrderStatus;
            request.OrderRequestItems = order.OrderRequestItems;
            await _uow.CompleteAsync();
        }
    }
}
