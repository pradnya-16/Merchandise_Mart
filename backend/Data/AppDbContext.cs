using Microsoft.EntityFrameworkCore;
using System.Text.Json; // Required for JSON deserialization
using System.IO;


public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed default user
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FullName = "Default User", Email = "defaultuser@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"), Role = "User" }
        );

        // Seed default products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "T-shirt", Price = 15.99M, Description = "Comfortable cotton T-shirt", ImageUrl = "/images/tshirt1.jpg" },
            new Product { Id = 2, Name = "Hoodie", Price = 25.99M, Description = "Warm hoodie for winter", ImageUrl = "/images/hoodie1.jpg" },
            new Product { Id = 3, Name = "Accessory", Price = 5.99M, Description = "Stylish accessory", ImageUrl = "/images/accessory1.jpg" }
            // Add more products as needed
        );

        base.OnModelCreating(modelBuilder);
    }
}


