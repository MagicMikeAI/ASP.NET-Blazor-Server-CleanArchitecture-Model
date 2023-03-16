using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_CategoryId1",
                table: "TodoItems",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Categories_CategoryId1",
                table: "TodoItems",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Categories_CategoryId1",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_CategoryId1",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "TodoItems");
        }
    }
}
