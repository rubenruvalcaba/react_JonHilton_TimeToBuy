using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeToBuy.Domain;

namespace TimeToBuy.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        readonly StoreContext _dbContext;

        public CartController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartRequest addToCartRequest)
        {
            // Create a new cart
            var cart = new ShoppingCart()
            {
                SessionId = Guid.NewGuid(),
                CreatedOn = DateTime.Now
            };

            // Add line item if it's new. If already exists, adds 1 to qty
            cart.Items.Add(new CartLineItems() { ProductId = addToCartRequest.ProductId, Quantity = 1 });

            // Save to database
            _dbContext.ShoppingCart.Add(cart);
            _dbContext.SaveChanges();

            return Ok();
        }
        public class AddToCartRequest
        {
            public int ProductId { get; set; }
        }

    }
}