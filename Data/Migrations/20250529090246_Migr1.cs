using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations;

/// <inheritdoc />
public partial class Migr1 : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Books",
			columns: table => new
			{
				BookId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Zhanr = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Opisanie = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
				KolVoNaSklade = table.Column<int>(type: "int", nullable: false),
				ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Books", x => x.BookId);
			});

		migrationBuilder.CreateTable(
			name: "Orders",
			columns: table => new
			{
				OrderId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Summa = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
				StatusZakaza = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Orders", x => x.OrderId);
			});

		migrationBuilder.CreateTable(
			name: "CartItems",
			columns: table => new
			{
				CartItemId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				BookId = table.Column<int>(type: "int", nullable: false),
				Kolichestvo = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_CartItems", x => x.CartItemId);
				table.ForeignKey(
					name: "FK_CartItems_Books_BookId",
					column: x => x.BookId,
					principalTable: "Books",
					principalColumn: "BookId",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateTable(
			name: "Discounts",
			columns: table => new
			{
				DiscountId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				BookId = table.Column<int>(type: "int", nullable: false),
				ProcentSkidki = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
				DataNachala = table.Column<DateTime>(type: "datetime2", nullable: false),
				DataKonca = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Discounts", x => x.DiscountId);
				table.ForeignKey(
					name: "FK_Discounts_Books_BookId",
					column: x => x.BookId,
					principalTable: "Books",
					principalColumn: "BookId",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateTable(
			name: "Reviews",
			columns: table => new
			{
				ReviewId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				BookId = table.Column<int>(type: "int", nullable: false),
				Rating = table.Column<int>(type: "int", nullable: false),
				Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Reviews", x => x.ReviewId);
				table.ForeignKey(
					name: "FK_Reviews_Books_BookId",
					column: x => x.BookId,
					principalTable: "Books",
					principalColumn: "BookId",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateTable(
			name: "OrderItem",
			columns: table => new
			{
				OrderItemId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				BookId = table.Column<int>(type: "int", nullable: false),
				KolVo = table.Column<int>(type: "int", nullable: false),
				CenaZaEdinicy = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
				OrderId = table.Column<int>(type: "int", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
				table.ForeignKey(
					name: "FK_OrderItem_Books_BookId",
					column: x => x.BookId,
					principalTable: "Books",
					principalColumn: "BookId",
					onDelete: ReferentialAction.Cascade);
				table.ForeignKey(
					name: "FK_OrderItem_Orders_OrderId",
					column: x => x.OrderId,
					principalTable: "Orders",
					principalColumn: "OrderId");
			});

		migrationBuilder.CreateIndex(
			name: "IX_CartItems_BookId",
			table: "CartItems",
			column: "BookId");

		migrationBuilder.CreateIndex(
			name: "IX_Discounts_BookId",
			table: "Discounts",
			column: "BookId");

		migrationBuilder.CreateIndex(
			name: "IX_OrderItem_BookId",
			table: "OrderItem",
			column: "BookId");

		migrationBuilder.CreateIndex(
			name: "IX_OrderItem_OrderId",
			table: "OrderItem",
			column: "OrderId");

		migrationBuilder.CreateIndex(
			name: "IX_Reviews_BookId",
			table: "Reviews",
			column: "BookId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "CartItems");

		migrationBuilder.DropTable(
			name: "Discounts");

		migrationBuilder.DropTable(
			name: "OrderItem");

		migrationBuilder.DropTable(
			name: "Reviews");

		migrationBuilder.DropTable(
			name: "Orders");

		migrationBuilder.DropTable(
			name: "Books");
	}
}
