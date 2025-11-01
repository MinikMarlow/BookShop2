using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class Book
{
	public int BookId { get; set; }
	public string? Title { get; set; }
	public string? Author { get; set; }
	public string? Genre { get; set; }
	public string? Description { get; set; }
	[Precision(10, 2)]
	public decimal Price { get; set; }
	public byte[]? ImageData { get; set; }
	public int AvailableCount { get; set; }
	public string? ImageFileName { get; set; }
	public virtual ICollection<Review>? Reviews { get; set; }
	public virtual ICollection<CartItem>? CartItems { get; set; }
}
