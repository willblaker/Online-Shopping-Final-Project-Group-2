using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CartEntry",
                columns: table => new
                {
                    CartEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartEntry", x => x.CartEntryId);
                    table.ForeignKey(
                        name: "FK_CartEntry_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "City", "Email", "FirstName", "LastName", "PasswordHash", "PostalCode", "State", "Username" },
                values: new object[,]
                {
                    { 1, "123 User1 St", "City1", "user1@onlineshopping.com", "User", "User1", "hashedpassword1", "45219", "State1", "user 1" },
                    { 2, "123 User2 St", "City2", "user2@onlineshopping.com", "User", "User2", "hashedpassword2", "45219", "State2", "user 2" },
                    { 3, "123 User3 St", "City3", "user3@onlineshopping.com", "User", "User3", "hashedpassword3", "45219", "State3", "user 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartEntry_ItemId",
                table: "CartEntry",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartEntry");

            migrationBuilder.DropTable(
                name: "OrderHistory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
