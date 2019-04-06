using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalPortal.Order.Common.Enums;
using RentalPortal.Order.DTO;

namespace RentalPortal.Order.Service
{
    public interface IEquipmentService
    {
        Task<EquipmentDto> GetEquipmentById(int orderId);
        Task<List<EquipmentDto>> GetEquipmentByType(EquipmentType type);
        Task<List<EquipmentDto>> GetAllEquipment();

        
    }
}
