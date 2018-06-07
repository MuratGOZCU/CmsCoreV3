using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class orderFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryNotes",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderItems",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SalePrice",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "OrderItems",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryNotes",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "OrderItems");
        }
    }
}
