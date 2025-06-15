using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    /// <inheritdoc />
    public partial class init99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerFoodPreferences_CustomerId",
                table: "CustomerFoodPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerFoodPreferences_ProductId",
                table: "CustomerFoodPreferences");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFoodPreferences_CustomerId",
                table: "CustomerFoodPreferences",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFoodPreferences_ProductId",
                table: "CustomerFoodPreferences",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerFoodPreferences_CustomerId",
                table: "CustomerFoodPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerFoodPreferences_ProductId",
                table: "CustomerFoodPreferences");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFoodPreferences_CustomerId",
                table: "CustomerFoodPreferences",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFoodPreferences_ProductId",
                table: "CustomerFoodPreferences",
                column: "ProductId");
        }
    }
}
