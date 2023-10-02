using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditWorks.VehicleManagement.Core.Migrations
{
    /// <inheritdoc />
    public partial class added_manufacturer_category_vehicle_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinWeight = table.Column<float>(type: "real", nullable: false),
                    MaxWeight = table.Column<float>(type: "real", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            //insert pre-defined manufacturers according to the test requirement
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Mazda" },
                    { "Mercedes" },
                    { "Honda" },
                    { "Ferrari" },
                    { "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "MinWeight", "MaxWeight", "IconUrl" },
                values: new object[,]
                {
                    { "Light", 0, 499.00, "fa-solid fa-motorcycle" },
                    { "Medium", 500.00, 2499.00, "fa-solid fa-car" },
                    { "Heavy", 2500.00, float.MaxValue, "fa-solid fa-truck" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "ManufacturerId", "CategoryId", "Owner", "Year", "Weight" },
                values: new object[,]
                {
                    { "2", 3, "Jane Turei", "2015", "2500" },
                    { "1", 2, "John Smith", "2019", "1000" },
                    { "3", 2, "Andy Smith", "1990", "400" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
