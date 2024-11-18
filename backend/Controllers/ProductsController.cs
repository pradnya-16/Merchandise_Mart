using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.ImageUrl = updatedProduct.ImageUrl;
        _context.SaveChanges();

        return Ok(product);
    }
}
