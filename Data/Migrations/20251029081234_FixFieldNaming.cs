using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations;

    /// <inheritdoc />
    public partial class FixFieldNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summa",
                table: "Orders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "StatusZakaza",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "KolVo",
                table: "OrderItems",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "CenaZaEdinicy",
                table: "OrderItems",
                newName: "ItemPrice");

            migrationBuilder.RenameColumn(
                name: "ProcentSkidki",
                table: "Discounts",
                newName: "DiscountRate");

            migrationBuilder.RenameColumn(
                name: "DataNachala",
                table: "Discounts",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DataKonca",
                table: "Discounts",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Kolichestvo",
                table: "CartItems",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Zhanr",
                table: "Books",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Opisanie",
                table: "Books",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "KolVoNaSklade",
                table: "Books",
                newName: "AvailableCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "StatusZakaza");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Orders",
                newName: "Summa");

            migrationBuilder.RenameColumn(
                name: "ItemPrice",
                table: "OrderItems",
                newName: "CenaZaEdinicy");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "OrderItems",
                newName: "KolVo");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Discounts",
                newName: "DataNachala");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Discounts",
                newName: "DataKonca");

            migrationBuilder.RenameColumn(
                name: "DiscountRate",
                table: "Discounts",
                newName: "ProcentSkidki");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CartItems",
                newName: "Kolichestvo");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "Zhanr");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "Opisanie");

            migrationBuilder.RenameColumn(
                name: "AvailableCount",
                table: "Books",
                newName: "KolVoNaSklade");
        }
    }
