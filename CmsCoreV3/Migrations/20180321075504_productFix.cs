using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class productFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_CrossSellId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_GroupedProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_UpSellId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CrossSellId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GroupedProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UpSellId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CrossSellId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GroupedProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpSellId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Products",
                newName: "IsApproved");

            migrationBuilder.AlterColumn<float>(
                name: "Width",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Products",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrl",
                table: "Products",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Length",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Products",
                newName: "IsPublished");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductUrl",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Products",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<long>(
                name: "CrossSellId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GroupedProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpSellId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CrossSellId",
                table: "Products",
                column: "CrossSellId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupedProductId",
                table: "Products",
                column: "GroupedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpSellId",
                table: "Products",
                column: "UpSellId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_CrossSellId",
                table: "Products",
                column: "CrossSellId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_GroupedProductId",
                table: "Products",
                column: "GroupedProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_UpSellId",
                table: "Products",
                column: "UpSellId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
