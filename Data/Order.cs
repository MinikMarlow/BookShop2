using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class Order
{
	public int OrderId { get; set; }
	[Precision(10, 2)]
	public decimal Amount { get; set; }
	public string? Status { get; set; }
	public ICollection<OrderItem> Items { get; set; } = [];
	public string? UserEmail { get; set; }
	public string? PaymentMethod { get; set; }
	public string? Address { get; set; }
}
public class OrderItem
{
	public int OrderItemId { get; set; }
	public int BookId { get; set; }
	public Book? Book { get; set; }
	public int Count { get; set; }

	[Precision(10, 2)]
	public decimal ItemPrice { get; set; }
}
