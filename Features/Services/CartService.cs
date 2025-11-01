using BookApp.Data;

namespace BookApp.Features.Services;

public class CartService(ApplicationDbContext context)
{
	public event Action? OnChange;
	private readonly List<CartItem> _cartItems = [];

	public List<CartItem> GetCartItems() => _cartItems;

	public decimal GetTotalCost() => _cartItems.Sum(x => x.Amount * (x.Book?.Price ?? 0));

	private void NotifyStateChanged() => OnChange?.Invoke();

	public int TotalItems => _cartItems.Sum(x => x.Amount);

	public void AddToCart(Book book, int quantity)
	{
		var existingItem = _cartItems.FirstOrDefault(x => x.BookId == book.BookId);
		if (existingItem != null)
		{
			existingItem.Amount += quantity;
		}
		else
		{
			_cartItems.Add(new CartItem { BookId = book.BookId, Book = book, Amount = quantity });
		}
		NotifyStateChanged();
	}

	public void RemoveFromCart(int bookId)
	{
		var item = _cartItems.FirstOrDefault(x => x.BookId == bookId);
		if (item != null)
		{
			_cartItems.Remove(item);
			NotifyStateChanged();
		}
	}

	public void ClearCart()
	{
		_cartItems.Clear();
		NotifyStateChanged();
	}

	public async Task CheckoutAsync()
	{
		var order = new Order
		{
			Amount = GetTotalCost(),
			Status = "Новый",
			Items = GetCartItems().Select(x => new OrderItem
			{
				BookId = x.BookId,
				Count = x.Amount,
				ItemPrice = x.Book!.Price
			}).ToList()
		};

		context.Orders.Add(order);
		await context.SaveChangesAsync();
	}
}