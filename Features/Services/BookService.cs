using BookApp.Data;

using Microsoft.EntityFrameworkCore;

namespace BookApp.Features.Services;

public class BookService(ApplicationDbContext context)
{
	public IQueryable<Book> GetQueryable()
	{
		return context.Books;
	}

	public async Task<List<Book>> GetAllAsync()
	{
		var books = await context.Books.ToListAsync();
		return books;
	}

	public async Task AddAsync(Book book)
	{
		context.Books.Add(book);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Book book)
	{
		var entry = context.Entry(book);
		if (entry.State == EntityState.Detached)
			context.Update(book);

		await context.SaveChangesAsync();
	}

	public async Task<Book?> FindByIdAsync(int id)
	{
		var book = await context.Books.FirstOrDefaultAsync(m => m.BookId == id);
		return book;
	}

	public async Task DeleteAsync(Book book)
	{
		context.Books.Remove(book);
		await context.SaveChangesAsync();
	}
}
