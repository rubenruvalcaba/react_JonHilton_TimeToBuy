using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TimeToBuy.Domain;

namespace TimeToBuy.Features
{

    public class CartService
    {
        readonly StoreContext _dbContext;

        public CartService(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShoppingCart AddToCart(Guid? sessionId, int productId, int quantity)
        {            
            if (sessionId != null)
            {
                sessionId = sessionId.Value;
            }
            else
            {
                sessionId = Guid.Empty;
            }

            // Get or create a new cart
            var cart = GetOrCreateCart(sessionId.Value);

            // Add new line item or increase qty
            AddOrIncreaseItem(cart, productId, quantity);

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
                ProductService productService = new ProductService(_dbContext);
                var product = productService.GetProductDetails(productId);
                cart.Items.Add(new CartLineItems()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    Name  = product.Name
                });

            }
            else
            {
                item.Quantity += quantity;
            }

        }
        public void DeleteItemFormCart(Guid sessionId, int lineItemId)
        {
            var cart = GetCart(sessionId);
            if (cart == null)
            {
                throw new Exception("No existe carrito para esta sesión");
            }
            
            var lineItem = cart.Items.FirstOrDefault(x => x.Id == lineItemId);
            if(lineItem == null)
            {
                return;
            }

            _dbContext.Set<CartLineItems>().Remove(lineItem);           
            _dbContext.SaveChanges();

        }

    }

}