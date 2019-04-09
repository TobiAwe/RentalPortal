using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<OrderRequest>
    {
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<List<OrderDto>> GetCustomerOrdersAsync(string email);



    }
}
