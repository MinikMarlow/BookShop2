using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations;

/// <inheritdoc />
public partial class Migr2 : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.AddColumn<int>(
			name: "CityId",
			table: "AspNetUsers",
			type: "int",
			nullable: false,
			defaultValue: 0);

		migrationBuilder.AddColumn<string>(
			name: "Ima",
			table: "AspNetUsers",
			type: "nvarchar(100)",
			maxLength: 100,
			nullable: false,
			defaultValue: "");

		migrationBuilder.AddColumn<string>(
			name: "SecSurname",
			table: "AspNetUsers",
			type: "nvarchar(100)",
			maxLength: 100,
			nullable: false,
			defaultValue: "");

		migrationBuilder.AddColumn<string>(
			name: "Surname",
			table: "AspNetUsers",
			type: "nvarchar(100)",
			maxLength: 100,
			nullable: false,
			defaultValue: "");

		migrationBuilder.CreateTable(
			name: "Cities",
			columns: table => new
			{
				CityId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Cities", x => x.CityId);
			});

		migrationBuilder.CreateIndex(
			name: "IX_AspNetUsers_CityId",
			table: "AspNetUsers",
			column: "CityId");

		migrationBuilder.AddForeignKey(
			name: "FK_AspNetUsers_Cities_CityId",
			table: "AspNetUsers",
			column: "CityId",
			principalTable: "Cities",
			principalColumn: "CityId",
			onDelete: ReferentialAction.Cascade);
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropForeignKey(
			name: "FK_AspNetUsers_Cities_CityId",
			table: "AspNetUsers");

		migrationBuilder.DropTable(
			name: "Cities");

		migrationBuilder.DropIndex(
			name: "IX_AspNetUsers_CityId",
			table: "AspNetUsers");

		migrationBuilder.DropColumn(
			name: "CityId",
			table: "AspNetUsers");

		migrationBuilder.DropColumn(
			name: "Ima",
			table: "AspNetUsers");

		migrationBuilder.DropColumn(
			name: "SecSurname",
			table: "AspNetUsers");

		migrationBuilder.DropColumn(
			name: "Surname",
			table: "AspNetUsers");
	}
}
