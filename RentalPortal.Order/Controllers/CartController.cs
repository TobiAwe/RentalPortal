using System;
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
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IServiceHelper _helper;


        public CartController(IServiceHelper helper, ICartService cartService)
        {
            _helper = helper;
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItemDto>>> Cart()
        {
            var user = _helper.GetCurrentUserEmail();
            var result=await _cartService.UserCartItems(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddToCart(CartItemDto cart)
        {
            var user = _helper.GetCurrentUserEmail();
            cart.UserId = user;
            var data= await _cartService.CreateCartItem(cart);
            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<string>> DeleteFromCart(string cartItemId)
        {
            var identity = Guid.Parse(cartItemId);
            await _cartService.DeleteCartItem(identity);
            return Ok();

        }


    }
}