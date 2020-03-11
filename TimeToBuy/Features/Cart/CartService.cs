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

            public ShoppingCart AddToCart(AddToCartRequest addToCartRequest)
            {
                // Get or create a new cart
                var cart = GetOrCreateCart(addToCartRequest.SessionId);

                // Add new line item or increase qty
                AddOrIncreaseItem(cart, addToCartRequest.ProductId);                              

                // Save to database                
                _dbContext.SaveChanges();

                return cart;
            }

            private ShoppingCart GetOrCreateCart(Guid sessionId)
            {
                var cart = _dbContext.ShoppingCart
                            .SingleOrDefault(b => b.SessionId == sessionId);
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

            private void AddOrIncreaseItem(ShoppingCart cart, int productId)
            {                
                var item = cart.Items.SingleOrDefault(b => b.ProductId == productId);
                if (item == null)
                {
                    cart.Items.Add(new CartLineItems()
                    {
                        ProductId = productId,
                        Quantity = 1
                    });

                }
                else
                {
                    item.Quantity += 1;
                }

            }

        }

    }
}