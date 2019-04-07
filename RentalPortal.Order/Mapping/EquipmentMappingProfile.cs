using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;

namespace RentalPortal.Order.Mapping
{
    internal class EquipmentMappingProfile : Profile
    {
        public EquipmentMappingProfile()
        {
            CreateMap<Equipment, EquipmentDto>()
                .AfterMap((equipment, dto) =>
                {
                    dto.EquipmentType = equipment.EquipmentType;
                });
        }
    }
}
