using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.Common.Enums;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence.Repository.Interfaces;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IServiceHelper _helper;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IUnitOfWork uow,IOrderRepository orderRepository, IMapper mapper, IServiceHelper helper)
        {
            _uow = uow;
            _orderRepository = orderRepository;
            _mapper = mapper;
            _helper = helper;
        }


        public async Task<OrderDto> GetOrderById(int orderId)
        {
            var request = await _orderRepository.GetAsync(orderId);

            if (request == null)
            {
                throw await _helper.GetExceptionAsync("Order entry does not exist");
            }
            return _mapper.Map<OrderDto>(request);
        }

        public async Task<List<OrderDto>> GetCustomerOrders(string email)
        {
            var orders =await _orderRepository.GetCustomerOrdersAsync(email);
            return orders;
        }

        public async Task<List<OrderDto>> GetApprovedOrders()
        {
            var approved =await _orderRepository.GetAllOrdersAsync();
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
            _orderRepository.Add(entry);
            await _uow.CompleteAsync();
        }

        public async Task UpdateOrder(OrderDto order)
        {
            var request = await _orderRepository.GetAsync(order.OrderId);

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
