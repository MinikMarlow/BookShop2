using BookApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace BookApp.Services
{
    public class CartService
    {
        public event Action? OnChange;
        private List<CartItem> _cartItems = new();
        public int TotalItems => _cartItems.Sum(x => x.Kolichestvo);

        public void AddToCart(Book book, int quantity)
        {
            var existingItem = _cartItems.FirstOrDefault(x => x.BookId == book.BookId);
            if (existingItem != null)
            {
                existingItem.Kolichestvo += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { BookId = book.BookId, Book = book, Kolichestvo = quantity });
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

        public List<CartItem> GetCartItems() => _cartItems;

        public decimal GetTotalCost() => _cartItems.Sum(x => x.Kolichestvo * (x.Book?.Price ?? 0));

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}