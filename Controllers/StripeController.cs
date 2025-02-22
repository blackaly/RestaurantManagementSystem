using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.ViewModel;
using Stripe.Checkout;

namespace OrderingSystem.Controllers
{
    public class StripeController : Controller
    {

        [HttpPost]
        public IActionResult CreateCheckoutSession([FromBody]CheckoutRequest request)
        {
            if (request == null || request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new { error = "Cart is empty or request body is invalid." });
            }

            var options = new SessionCreateOptions
            {

                PaymentMethodTypes = new List<string> { "card" },
                LineItems = request.Items.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ProductName,
                        },
                        UnitAmount = (long)(item.Price * 100) // Convert to cents
                    },
                    Quantity = item.Quantity
                }).ToList(),
                Mode = "payment",
                SuccessUrl = "https://localhost:7018/Stripe/Success",
                CancelUrl = "https://localhost:7018/Stripe/Cancel"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Ok(new { url = session.Url });
        }

        public IActionResult Success()
        {

            return View();
        }

        public IActionResult Cancel()
        {

            return View();
        }
    }


}
