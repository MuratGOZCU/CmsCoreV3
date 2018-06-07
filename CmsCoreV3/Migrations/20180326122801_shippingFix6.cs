using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class shippingFix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "ShippingCityId",
                table: "Products",
                nullable: true);
             migrationBuilder.AddColumn<long>(
                name: "ShippingZoneId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingMethod",
                table: "Products",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingCityId",
                table: "Products",
                column: "ShippingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingZoneId",
                table: "Products",
                column: "ShippingZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ShippingCityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShippingZoneId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippingCityId",
                table: "Products");
            migrationBuilder.DropColumn(
                name: "ShippingZoneId",
                table: "Products");
            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "Products");

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Length",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Products",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
