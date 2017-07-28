using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class SettingFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingCalculation",
                table: "Settings");

            migrationBuilder.AddColumn<bool>(
                name: "EnableShippingCal",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SalesLocationOptions",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShippingCostRequires",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShippingLocationsOptions",
                table: "Settings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableShippingCal",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SalesLocationOptions",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingCostRequires",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingLocationsOptions",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "ShippingCalculation",
                table: "Settings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
