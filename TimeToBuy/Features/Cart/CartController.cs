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

        #region Get 

        [HttpGet]        
        public IActionResult GetCart(Guid sessionId)
        {
            if (sessionId.Equals(Guid.Empty))
            {
                return BadRequest("No ha indicado el identificador del carrito");
            };

            var cart = _cartService.GetCart(sessionId);
            if(cart == null)
            {
                return NotFound("No se encontró el carrito");
            }
            else
            {
                return Ok(cart);
            }
        }

        #endregion

        #region  Add To Cart

        [HttpPost]
        public IActionResult AddToCart(AddToCartRequest addToCartRequest)
        {
            var cart = _cartService.AddToCart(addToCartRequest);

            return Ok(new AddToCartResponse() { SessionId = cart.SessionId });
        }

        public class AddToCartRequest
        {
            public Guid? SessionId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }


        public class AddToCartResponse
        {
            public Guid SessionId { get; set; }
        }
        #endregion


    }
}