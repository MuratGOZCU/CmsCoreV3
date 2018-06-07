using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class shippingFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingZoneRegions_ShippingZone_ShippingZoneId",
                table: "ShippingZoneRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingZone",
                table: "ShippingZone");

            migrationBuilder.RenameTable(
                name: "ShippingZone",
                newName: "ShippingZones");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShippingZones",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingZones",
                table: "ShippingZones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingZoneRegions_ShippingZones_ShippingZoneId",
                table: "ShippingZoneRegions",
                column: "ShippingZoneId",
                principalTable: "ShippingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingZoneRegions_ShippingZones_ShippingZoneId",
                table: "ShippingZoneRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingZones",
                table: "ShippingZones");

            migrationBuilder.RenameTable(
                name: "ShippingZones",
                newName: "ShippingZone");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShippingZone",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingZone",
                table: "ShippingZone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingZoneRegions_ShippingZone_ShippingZoneId",
                table: "ShippingZoneRegions",
                column: "ShippingZoneId",
                principalTable: "ShippingZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
