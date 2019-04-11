using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;


        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipmentDto>>> Equipment()
        {
            var eq = await _equipmentService.GetAllEquipment();
            return Ok(eq);
        }
        [HttpGet]
        public async Task<ActionResult<EquipmentDto>> EquipmentById(int id)
        {
            var eq = await _equipmentService.GetEquipmentById(id);
            return Ok(eq);
        }
        [HttpGet]
        public async Task<ActionResult<int>> EquipmentCount(int id)
        {
            var eq = await _equipmentService.EquipmentCount(id);
            return Ok(eq);
        }
    }
}