using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class lastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemGalleryItemCategories_GalleryItemCategories_GalleryItemCategoryId",
                table: "GalleryItemGalleryItemCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemGalleryItemCategories_GalleryItemCategories_GalleryItemCategoryId",
                table: "GalleryItemGalleryItemCategories",
                column: "GalleryItemCategoryId",
                principalTable: "GalleryItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemGalleryItemCategories_GalleryItemCategories_GalleryItemCategoryId",
                table: "GalleryItemGalleryItemCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemGalleryItemCategories_GalleryItemCategories_GalleryItemCategoryId",
                table: "GalleryItemGalleryItemCategories",
                column: "GalleryItemCategoryId",
                principalTable: "GalleryItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
