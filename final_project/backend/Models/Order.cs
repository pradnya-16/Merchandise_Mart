public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Status { get; set; } // e.g., Pending, Paid
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
}
