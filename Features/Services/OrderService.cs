using BookApp.Data;

using Microsoft.EntityFrameworkCore;

namespace BookApp.Features.Services;

public class OrderService(ApplicationDbContext context)
{
	public IQueryable<Order> Orders => context.Orders
			.Include(o => o.Items)
			.ThenInclude(i => i.Book)
			.AsQueryable();

	public async Task<Order?> FindByIdAsync(int id)
	{
		return await Orders.FirstOrDefaultAsync(x => x.OrderId == id);
	}

	public async Task<List<Order>> GetAllAsync()
	{
		return await context.Orders.ToListAsync();
	}

	public async Task AddAsync(Order order)
	{
		context.Orders.Add(order);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Order order)
	{
		context.Orders.Remove(order);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Order order)
	{
		var entry = context.Entry(order);
		if (entry.State == EntityState.Detached)
			context.Update(order);

		await context.SaveChangesAsync();
	}
}
