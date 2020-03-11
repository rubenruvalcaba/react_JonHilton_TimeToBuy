using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeToBuy.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CartController : ControllerBase
    {
        readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartRequest addToCartRequest)
        {
            var cart = _cartService.AddToCart(addToCartRequest);

            return Ok(cart);
        }

        public class AddToCartRequest
        {
            public Guid SessionId { get; set; }
            public int ProductId { get; set; }
        }

    }
}