using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Model;
using RentalPortal.Order.Service;

namespace RentalPortal.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IServiceHelper _helper;


        public OrderController(IServiceHelper helper, IOrderService orderService)
        {
            _helper = helper;
            _orderService = orderService;
        }


        public async Task<ActionResult<List<OrderDto>>> Order()
        {
            var eq = await _orderService.GetApprovedOrders();
            return Ok(eq);
        }

        public async Task<ActionResult<OrderDto>> OrderById(int id)
        {
            var eq = await _orderService.GetOrderById(id);
            return Ok(eq);
        }

        public async Task<ActionResult> CreateOrder(OrderDto order)
        {
            order.Email = _helper.GetCurrentUserEmail();
            await _orderService.CreateOrder(order);
            return Ok();
        }

        public async Task<ActionResult<Invoice>> Invoice(int id)
        {
            var order = await _orderService.GetOrderById(id);
            var rents = new List<Rent>();
            if (order.OrderRequestItems.Any())
            {
                foreach (var item in order.OrderRequestItems)
                {
                    var r = new Rent {Name = item.Equipment.Name.Trim(), Amount = _helper.CalculateAmount(item)};
                    rents.Add(r);
                }
            }
            var invoice = new Invoice
            {
                Title = "Invoice for the Rent of Equipment on the " +  order.DateCreated.ToLongTimeString(),
                TotalPrice = _helper.CalculateTotalOrderAmount(order),
                Rents = rents,
                Bonus = _helper.CalculateTotalOrderBonus(order)
            };
            return Ok(invoice);
        }


        public string NumberOfDays(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays.ToString(CultureInfo.InvariantCulture);
        }

       

    }
}