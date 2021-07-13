using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinder.Data.Migrations
{
    public partial class CategoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Pet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoathLength",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 14, 7, 17, 674, DateTimeKind.Utc).AddTicks(4541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 9, 18, 7, 48, 683, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 14, 7, 17, 670, DateTimeKind.Utc).AddTicks(214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 9, 18, 7, 48, 678, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_CategoryId",
                table: "Pet",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Categories_CategoryId",
                table: "Pet",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Categories_CategoryId",
                table: "Pet");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Pet_CategoryId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CoathLength",
                table: "Pet");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 9, 18, 7, 48, 683, DateTimeKind.Utc).AddTicks(7887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 14, 7, 17, 674, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 9, 18, 7, 48, 678, DateTimeKind.Utc).AddTicks(2419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 14, 7, 17, 670, DateTimeKind.Utc).AddTicks(214));
        }
    }
}
