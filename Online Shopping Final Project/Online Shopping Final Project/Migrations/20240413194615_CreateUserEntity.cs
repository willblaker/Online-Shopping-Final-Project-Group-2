using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_User_UserId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_User_UserId",
                table: "OrderHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
