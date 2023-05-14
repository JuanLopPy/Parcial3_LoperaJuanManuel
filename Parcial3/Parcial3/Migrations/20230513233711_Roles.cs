using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial3.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_NumberPlate",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_VehiculeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "NumberPlate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VehiculeId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberPlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_VehiculeId",
                table: "VehicleDetails",
                column: "VehiculeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_NumberPlate",
                table: "vehicles",
                column: "NumberPlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberPlate",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehiculeId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_NumberPlate",
                table: "Services",
                column: "NumberPlate",
                unique: true,
                filter: "[NumberPlate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehiculeId",
                table: "Services",
                column: "VehiculeId",
                unique: true,
                filter: "[VehiculeId] IS NOT NULL");
        }
    }
}
