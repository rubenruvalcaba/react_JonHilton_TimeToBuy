using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeToBuy.Domain;

namespace TimeToBuy.Features.Orders
{
    public class OrdersService
    {

        readonly StoreContext _storeContext;
        public OrdersService(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        public List<Order> GetUserOrders(string userIdentifier)
        {
            return _storeContext.Orders.Where(x => x.UserIdentifier == userIdentifier).ToList();
        }
    }
}
