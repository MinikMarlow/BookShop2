namespace BookApp.Data;

public class CartItem
{
	public int CartItemId { get; set; }
	public int BookId { get; set; }
	public Book? Book { get; set; }
	public int Amount { get; set; }
}
