using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Service;

namespace RentalPortal.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IServiceHelper _helper;
        

        public EquipmentController(IServiceHelper helper, IEquipmentService equipmentService)
        {           
            _helper = helper;
            _equipmentService = equipmentService;
        }


        public async Task<ActionResult<List<EquipmentDto>>> Equipment()
        {
            var eq = await _equipmentService.GetAllEquipment();
            return Ok(eq);
        }

        public async Task<ActionResult<EquipmentDto>> EquipmentById(int id)
        {
            var eq = await _equipmentService.GetEquipmentById(id);
            return Ok(eq);
        }

        public async Task<ActionResult<int>> EquipmentCount(int id)
        {
            var eq = await _equipmentService.EquipmentCount(id);
            return Ok(eq);
        }
    }
}