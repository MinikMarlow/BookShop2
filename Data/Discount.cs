using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class Discount
{
	public int DiscountId { get; set; }
	public int BookId { get; set; }
	public Book? Book { get; set; }
	[Precision(5, 2)]
	public decimal DiscountRate { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string DiscountView => $"{DiscountRate}% ({StartDate:d} - {EndDate:d})";
}
