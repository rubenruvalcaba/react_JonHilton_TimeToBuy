using System;

namespace TimeToBuy.Features.Checkout
{
    public class CheckoutRequest
    {
        public Guid SessionId { get; set; }

        public Client Customer { get; set; }
        public Address BillingAddress { get; set; }
        public Address DeliveryAddress { get; set; }
        public bool deliverToBillingAddress { get; set; }
        public string PaymentToken { get; set; }

        public class Client
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string email { get; set; }
        }

        public class Address
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

    }


}
