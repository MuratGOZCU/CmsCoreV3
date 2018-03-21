using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class productFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShippingClassId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingClassId",
                table: "Products",
                column: "ShippingClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShippingClasses_ShippingClassId",
                table: "Products",
                column: "ShippingClassId",
                principalTable: "ShippingClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShippingClasses_ShippingClassId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShippingClassId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippingClassId",
                table: "Products");
        }
    }
}
