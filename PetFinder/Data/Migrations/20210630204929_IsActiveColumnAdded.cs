using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinder.Data.Migrations
{
    public partial class IsActiveColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Breeds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Breeds");
        }
    }
}
