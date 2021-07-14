using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinder.Data.Migrations
{
    public partial class SubcategoryTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Subcategories",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Subcategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 39, 29, 595, DateTimeKind.Utc).AddTicks(6272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 470, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 39, 29, 592, DateTimeKind.Utc).AddTicks(5693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 466, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryID",
                table: "Subcategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryID",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Subcategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoryID",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Subcategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 470, DateTimeKind.Utc).AddTicks(1662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 39, 29, 595, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 466, DateTimeKind.Utc).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 39, 29, 592, DateTimeKind.Utc).AddTicks(5693));

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
