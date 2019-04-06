using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Persistence.Repository
{
    public interface IEquipmentRepository: IRepository<Equipment>
    {
        Task<List<EquipmentDto>> GetAllEquipmentsAsync();
        Task<int> EquipmentCount(int productId);
    }
}
