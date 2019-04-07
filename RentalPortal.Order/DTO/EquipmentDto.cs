using RentalPortal.Order.Common.Enums;

namespace RentalPortal.Order.DTO
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public  EquipmentType EquipmentType { get; set; }
    }
}
