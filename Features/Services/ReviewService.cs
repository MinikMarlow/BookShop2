using BookApp.Data;

using Microsoft.EntityFrameworkCore;

namespace BookApp.Features.Services;

public class ReviewService(ApplicationDbContext context)
{
	public IQueryable<Review> Reviews => context.Reviews
		.Include(x => x.Book);

	public async Task<Review?> FindByIdAsync(int id)
	{
		return await Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
	}

	public async Task<List<Review>> GetAllAsync()
	{
		var reviews = await context.Reviews.ToListAsync();
		return reviews;
	}

	public async Task AddAsync(Review review)
	{
		context.Reviews.Add(review);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Review review)
	{
		context.Reviews.Remove(review);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Review review)
	{
		var entry = context.Entry(review);
		if (entry.State == EntityState.Detached)
			context.Update(review);

		await context.SaveChangesAsync();
	}
}
