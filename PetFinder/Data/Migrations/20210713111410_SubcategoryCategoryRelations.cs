using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinder.Data.Migrations
{
    public partial class SubcategoryCategoryRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Subcategories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 470, DateTimeKind.Utc).AddTicks(1662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 8, 18, 622, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 466, DateTimeKind.Utc).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 8, 18, 618, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subcategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 8, 18, 622, DateTimeKind.Utc).AddTicks(9464),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 470, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 13, 15, 8, 18, 618, DateTimeKind.Utc).AddTicks(1012),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 13, 15, 14, 10, 466, DateTimeKind.Utc).AddTicks(3264));
        }
    }
}
