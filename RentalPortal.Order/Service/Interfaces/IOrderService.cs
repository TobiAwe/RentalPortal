using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;

namespace RentalPortal.Order.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderById(int orderId);
        Task<List<OrderDto>> GetCustomerOrders(string email);
        Task<List<OrderDto>> GetApprovedOrders();
        Task CreateOrder(OrderDto order);
        Task UpdateOrder(OrderDto order);



    }
}
