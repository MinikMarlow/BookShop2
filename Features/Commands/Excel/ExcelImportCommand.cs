using BookApp.Contracts;
using BookApp.Data;
using BookApp.Exceptions;

using ClosedXML.Excel;

namespace BookApp.Features.Commands.Excel;

public class ExcelImportCommand(ApplicationDbContext context)
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="file"></param>
	/// <returns></returns>
	/// <exception cref="ExcelParseException"></exception>
	public async Task<ExcelImportResponse> HandleAsync(Stream file)
	{
		var bookList = new List<Book>();
		var reviewList = new List<Review>();

		using var workbook = new XLWorkbook(file);

		foreach (var worksheet in workbook.Worksheets)
		{
			var rowId = 1;
			foreach (var row in worksheet.RowsUsed().Skip(1))
			{
				rowId++;
				try
				{
					switch (worksheet.Name)
					{
						case "Books":
						{
							var book = ParseBookRow(worksheet, row);
							book.BookId = 0;
							bookList.Add(book);
							break;
						}
						case "Reviews":
						{
							var review = ParseReviewRow(worksheet, row);
							review.ReviewId = 0;
							review.Book = bookList.FirstOrDefault(x => x.BookId == review.BookId)!;
							reviewList.Add(review);
							break;
						}
					}
				}
				catch
				{
					throw new ExcelParseException(worksheet.Name, rowId);
				}
			}
		}

		foreach (var el in bookList)
			el.BookId = 0;

		foreach (var el in reviewList)
			el.ReviewId = 0;

		context.AddRange(bookList);
		context.AddRange(reviewList);
		await context.SaveChangesAsync();

		return new(bookList.Count, reviewList.Count);
	}

	private static Book ParseBookRow(IXLWorksheet worksheet, IXLRow row)
	{
		var book = new Book();
		var range = worksheet.RangeUsed();
		var table = range!.AsTable();

		book.BookId = int.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "BookId").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		book.Title = row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Title").RangeAddress.FirstAddress.ColumnNumber).Value.ToString();

		book.Author = row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Author").RangeAddress.FirstAddress.ColumnNumber).Value.ToString();

		book.Genre = row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Zhanr").RangeAddress.FirstAddress.ColumnNumber).Value.ToString();

		book.Description = row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Opisanie").RangeAddress.FirstAddress.ColumnNumber).Value.ToString();

		book.Price = decimal.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Price").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		book.AvailableCount = int.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "KolVoNaSklade").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		return book;
	}

	private static Review ParseReviewRow(IXLWorksheet worksheet, IXLRow row)
	{
		var review = new Review();
		var range = worksheet.RangeUsed();
		var table = range!.AsTable();

		review.ReviewId = int.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "ReviewId").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		review.Rating = int.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Rating").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		review.Text = row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "Text").RangeAddress.FirstAddress.ColumnNumber).Value.ToString();

		review.BookId = int.Parse(row.Cell(table.FindColumn(c =>
			c.FirstCell().Value.ToString() == "BookId").RangeAddress.FirstAddress.ColumnNumber).Value.ToString());

		return review;
	}
}
