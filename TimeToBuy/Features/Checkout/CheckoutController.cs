﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            _checkoutService.PlaceOrder(checkoutRequest);
            return Ok();
        }

    }
}