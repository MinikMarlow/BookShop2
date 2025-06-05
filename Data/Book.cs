using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Zhanr { get; set; }
        public string? Opisanie { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        public byte[]? ImageData { get; set; }
        public int KolVoNaSklade { get; set; }
        public string? ImageFileName { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
