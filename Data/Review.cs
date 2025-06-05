using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Data
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
    }
}