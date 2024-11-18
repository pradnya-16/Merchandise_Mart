using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult PlaceOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return Ok(order);
    }

    [HttpGet("{userId}")]
    public IActionResult GetOrders(int userId)
    {
        var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
        return Ok(orders);
    }
}
