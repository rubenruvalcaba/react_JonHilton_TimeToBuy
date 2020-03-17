using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TimeToBuy.Features.Orders
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        readonly OrdersService _ordersService;
        public OrdersController(OrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult MyOrders()
        {
            var userIdentifier = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(_ordersService.GetUserOrders(userIdentifier));
        }

        
    }
}