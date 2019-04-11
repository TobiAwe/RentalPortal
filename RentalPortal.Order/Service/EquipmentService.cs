using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence.Repository.Interfaces;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Service
{
    public class EquipmentService : IEquipmentService
    {

        //private readonly IUnitOfWork _uow;
        private readonly IServiceHelper _helper;
        private readonly IEquipmentRepository _equipment;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipment, IServiceHelper helper, IMapper mapper)
        {
            //_uow = uow;
            _helper = helper;
            _equipment = equipment;
            _mapper = mapper;
        }
        public async Task<EquipmentDto> GetEquipmentById(int id)
        {
            var request = await _equipment.GetAsync(id);//_uow.Equipment.GetAsync(id);

            if (request == null)
            {
                throw await _helper.GetExceptionAsync("Equipment entry does not exist");
            }
            return _mapper.Map<Equipment,EquipmentDto>(request);

        }

        public async Task<List<EquipmentDto>> GetAllEquipment()
        {
            var request = await _equipment.GetAllEquipmentsAsync();
            return request;
        }

        public async Task<int> EquipmentCount(int equipmentId)
        {
            var request = await _equipment.EquipmentCount(equipmentId);
            return request;
        }
    }
}
