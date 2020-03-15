using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeToBuy.Domain
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<CartLineItems> Items { get; set; } = new List<CartLineItems>();
    }

    public class CartLineItems
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
