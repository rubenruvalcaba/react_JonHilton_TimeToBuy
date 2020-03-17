using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TimeToBuy.Features.Checkout
{
    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {

        readonly CheckoutService _checkoutService;
        public CheckoutController(CheckoutService checkoutService)
        {
            this._checkoutService = checkoutService;
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutRequest checkoutRequest)
        {
            var userIdentifier = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            _checkoutService.PlaceOrder(checkoutRequest, userIdentifier);
            return Ok();
        }

    }
}