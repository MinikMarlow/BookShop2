using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	public virtual DbSet<Book> Books { get; set; }
	public virtual DbSet<CartItem> CartItems { get; set; }
	public virtual DbSet<Discount> Discounts { get; set; }
	public virtual DbSet<Order> Orders { get; set; }
	public virtual DbSet<Review> Reviews { get; set; }
	public virtual DbSet<City> Cities { get; set; }
	public virtual DbSet<OrderItem> OrderItems { get; set; }
}
