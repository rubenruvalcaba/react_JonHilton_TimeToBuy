using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TimeToBuy.Domain;

namespace TimeToBuy.Features
{
    public partial class CartController
    {
        public class CartService
        {
            readonly StoreContext _dbContext;

            public CartService(StoreContext dbContext)
            {
                _dbContext = dbContext;
            }            

            public ShoppingCart AddToCart(AddToCartRequest request)
            {
                var sessionId = Guid.Empty;
                if(request.SessionId != null)
                {
                    sessionId = request.SessionId.Value;
                }

                // Get or create a new cart
                var cart = GetOrCreateCart(sessionId);

                // Add new line item or increase qty
                AddOrIncreaseItem(cart, request.ProductId, request.Quantity);                              

                // Save to database                
                _dbContext.SaveChanges();

                return cart;
            }
          

            private ShoppingCart GetOrCreateCart(Guid sessionId)
            {
                var cart = GetCart(sessionId);
                if (cart == null)
                {
                    cart = new ShoppingCart()
                    {
                        SessionId = Guid.NewGuid(),
                        CreatedOn = DateTime.Now
                    };
                    _dbContext.ShoppingCart.Add(cart);
                }

                return cart;
            }

            internal ShoppingCart GetCart(Guid sessionId)
            {
                if (sessionId.Equals(Guid.Empty))
                {
                    return null;
                }

                var cart = _dbContext.ShoppingCart
                             .Include(c => c.Items)
                             .SingleOrDefault(b => b.SessionId == sessionId);
                return cart;              
            }

            private void AddOrIncreaseItem(ShoppingCart cart, int productId, int quantity)
            {                
                var item = cart.Items.SingleOrDefault(b => b.ProductId == productId);
                if (item == null)
                {
                    //var product = ProductService.
                    cart.Items.Add(new CartLineItems()
                    {
                        ProductId = productId,
                        Quantity = quantity
                        
                    });

                }
                else
                {
                    item.Quantity += quantity;
                }

            }

        }


    }
}