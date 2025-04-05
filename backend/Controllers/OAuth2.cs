using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class OAuth2Controller : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("google-login")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = "http://localhost:3000/login" // Redirect to your React app after login
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [AllowAnonymous]
    [HttpGet("google-callback")]
    public IActionResult GoogleCallback()
    {
        // Handle callback logic here
        return Ok("Google login successful!"); // Replace with token generation or frontend redirect logic
    }
}
