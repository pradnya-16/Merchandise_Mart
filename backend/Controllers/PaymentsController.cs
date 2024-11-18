using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    [HttpPost("create-payment-intent")]
public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest request)
{
    StripeConfiguration.ApiKey = "sk_test_51QMcBgELN7EfHzd3PSRUO37EY5M3F9uMs5Vn8MfMJBTRcjT2AsBoGzXtCHeIm898xdXKC4CBzlAeivxQyms9UJ90006GKjJb21"; // Replace with your Stripe secret key

    try
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Amount = request.Amount, // Amount in cents (e.g., 1000 for $10.00)
            Currency = "usd",       // Set your currency
            PaymentMethodTypes = new List<string> { "card" }
        });

        return Ok(new { clientSecret = paymentIntent.ClientSecret });
    }
    catch (StripeException ex)
    {
        return BadRequest(new { error = ex.Message });
    }
}

}

public class PaymentRequest
{
    public long Amount { get; set; } // Amount in cents
}
