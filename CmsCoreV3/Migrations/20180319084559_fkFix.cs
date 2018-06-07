using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class fkFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeItems_Attributes_ProductAttributeId",
                table: "AttributeItems");

            migrationBuilder.DropIndex(
                name: "IX_AttributeItems_ProductAttributeId",
                table: "AttributeItems");

            migrationBuilder.DropColumn(
                name: "ProductAttributeId",
                table: "AttributeItems");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeItems_AttributeId",
                table: "AttributeItems",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeItems_Attributes_AttributeId",
                table: "AttributeItems",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeItems_Attributes_AttributeId",
                table: "AttributeItems");

            migrationBuilder.DropIndex(
                name: "IX_AttributeItems_AttributeId",
                table: "AttributeItems");

            migrationBuilder.AddColumn<long>(
                name: "ProductAttributeId",
                table: "AttributeItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeItems_ProductAttributeId",
                table: "AttributeItems",
                column: "ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeItems_Attributes_ProductAttributeId",
                table: "AttributeItems",
                column: "ProductAttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
