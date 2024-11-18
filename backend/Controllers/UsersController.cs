using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UsersController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

        [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.Select(u => new { u.Id, u.FullName, u.Email, u.Role }).ToList();
        return Ok(users);
    }


    // Endpoint: Register a New User
    [HttpPost("register")]
public async Task<IActionResult> Register(UserDto userDto)
{
    if (_context.Users.Any(u => u.Email == userDto.Email))
    {
        return BadRequest("User already exists.");
    }

    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
    var user = new User
    {
        FullName = userDto.FullName, // Save FullName
        Email = userDto.Email,
        PasswordHash = hashedPassword,
        Role = "User"
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return Ok("User registered successfully!");
}


    // Endpoint: Login and Get JWT Token
    [HttpPost("login")]
    public IActionResult Login(UserDto userDto)
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == userDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid credentials.");
        }

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    // Endpoint: Get User Profile (Requires Authentication)
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userIdClaim == null) return Unauthorized("Invalid user.");

        var userId = int.Parse(userIdClaim);
        var user = _context.Users.Find(userId);

        if (user == null) return NotFound("User not found.");

        return Ok(new { user.Email, user.Role });
    }

    // Generate JWT Token
    private string GenerateJwtToken(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
