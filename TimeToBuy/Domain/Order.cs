using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeToBuy.Features.Checkout;

namespace TimeToBuy.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public string UserIdentifier { get; set; }
        public string CustomerEmail { get; private set; }
        public List<OrderLine> Lines { get; private set; } = new List<OrderLine>();

        internal static Order FromCheckoutRequest(CheckoutRequest checkoutRequest, string userIdentifier)
        {
            return new Order() {
                UserIdentifier =userIdentifier,
                CustomerEmail = checkoutRequest.Customer.email
            };
        }
        public void AddItem(CartLineItems item)
        {
            Lines.Add(new OrderLine()
            {
                Name = item.Name,
                Price = item.Price,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }

        public decimal GetTotal()
        {
            return Lines.Sum(x => x.Amount);
        }

    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
