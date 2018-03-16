using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class addParentCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_parentCategoryId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "parentCategoryId",
                table: "ProductCategories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_parentCategoryId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "ProductCategories",
                newName: "parentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_parentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_parentCategoryId",
                table: "ProductCategories",
                column: "parentCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
