using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDiet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumMeal = table.Column<int>(type: "int", nullable: false),
                    NumCalories = table.Column<int>(type: "int", nullable: false),
                    TimeMealsString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_DietTypes_DietId",
                        column: x => x.DietId,
                        principalTable: "DietTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductForDietTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietTypeId = table.Column<int>(type: "int", nullable: false),
                    dietTypeCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductForDietTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductForDietTypes_DietTypes_dietTypeCode",
                        column: x => x.dietTypeCode,
                        principalTable: "DietTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeeklyTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustId = table.Column<int>(type: "int", nullable: false),
                    WeakDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatdedWieght = table.Column<double>(type: "float", nullable: false),
                    IsPassCalories = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyTrackings_Customers_CustId",
                        column: x => x.CustId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DietId",
                table: "Customers",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductForDietTypes_dietTypeCode",
                table: "ProductForDietTypes",
                column: "dietTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyTrackings_CustId",
                table: "WeeklyTrackings",
                column: "CustId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductForDietTypes");

            migrationBuilder.DropTable(
                name: "WeeklyTrackings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DietTypes");
        }
    }
}
