using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class shippingFix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Regions_ShippingCityId",
                table: "Products",
                column: "ShippingCityId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShippingZones_ShippingZoneId",
                table: "Products",
                column: "ShippingZoneId",
                principalTable: "ShippingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Regions_ShippingCityId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShippingZones_ShippingZoneId",
                table: "Products");
        }
    }
}
