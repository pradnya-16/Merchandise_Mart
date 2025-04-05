public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Add default value to avoid warnings
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty; // Add default value to avoid warnings
}
