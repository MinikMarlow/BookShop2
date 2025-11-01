using BookApp.Data;

using Microsoft.EntityFrameworkCore;

namespace BookApp.Features.Services;

public class DiscountService(ApplicationDbContext context)
{
	public IQueryable<Discount> Discounts => context.Discounts
		.Include(x => x.Book)
		.AsQueryable();

	public async Task<List<Discount>> GetActualDiscountsAsync()
	{
		var today = DateTime.Today;
		return await Discounts
			.Where(x => x.StartDate <= today && x.EndDate >= today)
			.ToListAsync();
	}

	public async Task AddAsync(Discount discount)
	{
		context.Discounts.Add(discount);
		await context.SaveChangesAsync();
	}

	public async Task<Discount?> FindByIdAsync(int id)
	{
		var discount = await context.Discounts.FindAsync(id);
		return discount;
	}

	public async Task UpdateAsync(Discount discount)
	{
		var entry = context.Discounts.Entry(discount);
		if (entry.State == EntityState.Detached)
			context.Discounts.Update(discount);

		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Discount discount)
	{
		context.Remove(discount);
		await context.SaveChangesAsync();
	}
}
