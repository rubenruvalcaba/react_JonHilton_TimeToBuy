using Microsoft.EntityFrameworkCore;
using System;
using TimeToBuy.Domain;
using TimeToBuy.Features;
using Xunit;
using static TimeToBuy.Features.CartController;

namespace TimeToBuy.Specs
{
    public class AddItemToCartShould
    {
        private DbContextOptions<StoreContext> _options;

        public AddItemToCartShould()
        {
            _options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "Cart")
                .Options;
        }

        [Fact]
        public void CreateCartIfNotFound()
        {

            using (var context = new StoreContext(_options))
            {
                var cartService = new CartService(context);
                var result = cartService.AddToCart(null, 1, 1);
                Assert.NotEqual(Guid.Empty, result.SessionId);
            }

        }

        [Fact]
        public void NotCreateIfExistingOneFound()
        {
            // setup a cart in the database
            Guid sessionId = Guid.NewGuid();
            using (var context = new StoreContext(_options))
            {
                context.ShoppingCart.Add(new ShoppingCart() { SessionId = sessionId });
                context.SaveChanges();
            }

            // test adding item with the session id for the cart that exists
            using (var context = new StoreContext(_options))
            {
                var cartService = new CartService(context);
                var result = cartService.AddToCart(sessionId,1, 1);

                // should get back the session id of the existing cart
                Assert.Equal(sessionId, result.SessionId);
            }

        }

        [Fact]
        public void AddLineItemIfNotExists()
        {
            using (var context = new StoreContext(_options))
            {
                var cartService = new CartService(context);
                var result = cartService.AddToCart( null, 1, 1);
                Assert.Single(result.Items);
                Assert.Equal(1, result.Items[0].Quantity);
            }
        }

        [Fact]
        public void AddQuantityLineItemIfExists()
        {
            using (var context = new StoreContext(_options))
            {
                var cartService = new CartService(context);
                var firstLineItem = cartService.AddToCart( null,1,1);
                var secondLineItem = cartService.AddToCart(firstLineItem.SessionId,1,1);
                Assert.Single(secondLineItem.Items);
                Assert.Equal(2, secondLineItem.Items[0].Quantity);
            }
        }

        [Fact]
        public void AddQuantityTwoLineItem()
        {
            using (var context = new StoreContext(_options))
            {
                var cartService = new CartService(context);
                var cart = cartService.AddToCart(null,1,2);
                Assert.Equal(2, cart.Items[0].Quantity);
            }
        }

    }
}
