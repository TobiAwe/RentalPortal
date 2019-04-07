using System.Collections.Generic;
using System.Threading.Tasks;
using RentalPortal.Order.DTO;

namespace RentalPortal.Order.Service
{
    public interface IEquipmentService
    {
        Task<EquipmentDto> GetEquipmentById(int id);
        Task<List<EquipmentDto>> GetAllEquipment();
        Task<int> EquipmentCount(int equipmentId);


    }
}
