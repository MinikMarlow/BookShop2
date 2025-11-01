using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations;

/// <inheritdoc />
public partial class AddImageDataToBook : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.AddColumn<byte[]>(
			name: "ImageData",
			table: "Books",
			type: "varbinary(max)",
			nullable: true);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropColumn(
			name: "ImageData",
			table: "Books");
	}
}
