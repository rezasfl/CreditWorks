using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditWorks.VehicleManagement.Migrations
{
    /// <inheritdoc />
    public partial class added_vehicle_and_manufacturer_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Vehicles",
                columns: new[] { "ManufacturerId", "Owner", "Year", "Weight" },
                values: new object[,]
                {
                    { "2", "Jane Turei", "2015", "2500" },
                    { "1", "John Smith", "2019", "1000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
