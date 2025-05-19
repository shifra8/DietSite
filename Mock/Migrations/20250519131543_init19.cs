using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    /// <inheritdoc />
    public partial class init19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumMeal",
                table: "DietTypes",
                newName: "MealsPerDay");

            migrationBuilder.RenameColumn(
                name: "NameDiet",
                table: "DietTypes",
                newName: "DietName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MealsPerDay",
                table: "DietTypes",
                newName: "NumMeal");

            migrationBuilder.RenameColumn(
                name: "DietName",
                table: "DietTypes",
                newName: "NameDiet");
        }
    }
}
