using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.IO;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configure Product entity
    modelBuilder.Entity<Product>(entity =>
    {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.Name).IsRequired();
        entity.Property(p => p.Price).IsRequired();
        entity.Property(p => p.ImageUrl).IsRequired();
    });

    // Load and seed products from JSON
    var productsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "products.json");
    Console.WriteLine($"Looking for products.json at: {productsFilePath}");

    if (File.Exists(productsFilePath))
    {
        var products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(productsFilePath));
        if (products != null)
        {
            int id = -1; // Start IDs at -1
            foreach (var product in products)
            {
                product.Id = id--; // Assign negative IDs
            }
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
    else
    {
        Console.WriteLine("products.json not found!");
    }
}
}