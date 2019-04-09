using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Persistence;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Service
{
    public class EquipmentService : IEquipmentService
    {

        private readonly IUnitOfWork _uow;
        private readonly IServiceHelper _helper;

        public EquipmentService(IUnitOfWork uow, IServiceHelper helper)
        {
            _uow = uow;
            _helper = helper;
        }
        public async Task<EquipmentDto> GetEquipmentById(int id)
        {
            var request = await _uow.Equipment.GetAsync(id);

            if (request == null)
            {
                throw await _helper.GetExceptionAsync("Equipment entry does not exist");
            }
            return Mapper.Map<EquipmentDto>(request);
        }

        public async Task<List<EquipmentDto>> GetAllEquipment()
        {
            var request = await _uow.Equipment.GetAllEquipmentsAsync();
            return request;
        }

        public async Task<int> EquipmentCount(int equipmentId)
        {
            var request = await _uow.Equipment.EquipmentCount(equipmentId);
            return request;
        }
    }
}
