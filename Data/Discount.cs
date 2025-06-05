using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Precision(5, 2)]
        public decimal ProcentSkidki { get; set; }
        public DateTime DataNachala { get; set; }
        public DateTime DataKonca { get; set; }
        public string SkidkaInfo => $"{ProcentSkidki}% ({DataNachala:d} - {DataKonca:d})";
    }
}
