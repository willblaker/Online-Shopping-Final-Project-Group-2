using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class ItemsTableSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemDescription", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 1, "Black cotton crew neck T-shirt for Men", "Mens - Black T-shirt", 15.5f },
                    { 2, "Green cotton crew neck T-shirt for Men", "Mens - Green T-shirt", 15.25f },
                    { 3, "Pink cotton crew neck T-shirt for Men", "Mens - Pink T-shirt", 14.5f },
                    { 4, "Biege cotton crew neck T-shirt for Men", "Mens - Biege T-shirt", 13f },
                    { 5, "Light Blue Denim Jeans for Men", "Mens - Light Blue Jeans", 22.25f },
                    { 6, "Black Denim Jeans for Men", "Mens - Black Jeans", 25.5f },
                    { 7, "Grey Denim Jeans for Men", "Mens - Grey Jeans", 27.25f },
                    { 8, "Grey Denim Jeans for Men", "Mens - Blue Jeans", 30f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8);
        }
    }
}
