using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class UserSeededTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "City", "Email", "FirstName", "LastName", "PasswordHash", "PostalCode", "State", "Username" },
                values: new object[,]
                {
                    { 1, "123 User1 St", "City1", "user1@onlineshopping.com", "User", "User1", "hashedpassword1", "45219", "State1", "user 1" },
                    { 2, "123 User2 St", "City2", "user2@onlineshopping.com", "User", "User2", "hashedpassword2", "45219", "State2", "user 2" },
                    { 3, "123 User3 St", "City3", "user3@onlineshopping.com", "User", "User3", "hashedpassword3", "45219", "State3", "user 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
