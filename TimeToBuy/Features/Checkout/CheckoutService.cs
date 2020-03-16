using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeToBuy.Domain;

namespace TimeToBuy.Features.Checkout
{
    public class CheckoutService
    {

        private readonly StoreContext _dbContext;
        readonly CartService _cartService;
        readonly IConfiguration _configuration;

        public CheckoutService(StoreContext storeContext, CartService cartService,IConfiguration configuration)
        {
            this._configuration = configuration;
            this._cartService = cartService;
            _dbContext = storeContext;
        }

        public void PlaceOrder(CheckoutRequest checkoutRequest)
        {
            // Create an order
            var order = Domain.Order.FromCheckoutRequest(checkoutRequest);

            // Get cart for session
            var cart = _cartService.GetCart(checkoutRequest.SessionId);

            // Add each item to the order
            foreach (var item in cart.Items)
            {
                order.AddItem(item);
            }

            // Charge the customer
            ChargeCustomer(checkoutRequest.PaymentToken, order.GetTotal(), "Order for " + checkoutRequest.Customer.email);

            // Persist the order to db
            _dbContext.Orders.Add(order);

            // Empty the cart
            _cartService.EmptyCart(cart);

            _dbContext.SaveChanges();


        }
        void ChargeCustomer(string paymentToken, decimal total, string description)
        {
            var requestOptions = new RequestOptions()
            {
                ApiKey = _configuration.GetValue<string>("Stripe:ApiKey")
            };

            var options = new ChargeCreateOptions()
            {
                Amount = Convert.ToInt64(total * 100),
                Currency = "mxn",
                Description = description,
                Source = paymentToken
            };

            var service = new ChargeService();
            service.Create(options, requestOptions);

        }

    }
}
