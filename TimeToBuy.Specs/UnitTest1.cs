using Microsoft.EntityFrameworkCore;
using System;
using TimeToBuy.Domain;
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
                var result = cartService.AddToCart(new AddToCartRequest() { ProductId = 1, SessionId = null });
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
                var result = cartService.AddToCart(new AddToCartRequest() { ProductId = 1, SessionId = sessionId });

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
                var result = cartService.AddToCart(new AddToCartRequest() { ProductId = 1, Quantity = 1, SessionId = null });
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
                var firstLineItem = cartService.AddToCart(new AddToCartRequest() { ProductId = 1, Quantity = 1, SessionId = null });
                var secondLineItem = cartService.AddToCart(new AddToCartRequest() { ProductId = 1, Quantity = 1, SessionId = firstLineItem.SessionId });
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
                var cart = cartService.AddToCart(new AddToCartRequest()
                {
                    ProductId = 1,
                    Quantity = 2,
                    SessionId = null
                });
                Assert.Equal(2, cart.Items[0].Quantity);
            }
        }

    }
}
