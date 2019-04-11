using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Route("GetEquipment")]
        public async Task<ActionResult<List<EquipmentDto>>> Equipment()
        {
            var eq = await _equipmentService.GetAllEquipment();
            return Ok(eq);
        }
        [HttpGet]
        [Route("GetEquipmentById/{id}")]
        public async Task<ActionResult<EquipmentDto>> EquipmentById(int id)
        {
            var eq = await _equipmentService.GetEquipmentById(id);
            return Ok(eq);
        }
        [HttpGet]
        [Route("GetEquipmentCount/{id}")]
        public async Task<ActionResult<int>> EquipmentCount(int id)
        {
            var eq = await _equipmentService.EquipmentCount(id);
            return Ok(eq);
        }
    }
}