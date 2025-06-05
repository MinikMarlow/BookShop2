using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        [Precision(10, 2)]
        public decimal Summa { get; set; }
        public string? StatusZakaza { get; set; }
        public virtual ICollection<OrderItem>? Items { get; set; }
        public string? UserEmail { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Address { get; set; }
    }
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int KolVo { get; set; }

        [Precision(10, 2)]
        public decimal CenaZaEdinicy { get; set; }
    }
}
