using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class PageModulEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LayoutTemplate",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta1",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta2",
                table: "Pages",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Pages",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LayoutTemplate",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Meta1",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Meta2",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Pages");
        }
    }
}
