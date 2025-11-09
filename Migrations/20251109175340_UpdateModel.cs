using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "Category", "Date", "Title" },
                values: new object[,]
                {
                    { 1, 150.75m, "Food", new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Groceries" },
                    { 2, 60.00m, "Utilities", new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electricity Bill" },
                    { 3, 30.00m, "Entertainment", new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Movie Tickets" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
