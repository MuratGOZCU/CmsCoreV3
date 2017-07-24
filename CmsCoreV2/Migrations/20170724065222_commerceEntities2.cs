using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class commerceEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_ApiUserId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_ApiUserId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "ApiUser",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiUser",
                table: "Settings");

            migrationBuilder.AddColumn<Guid>(
                name: "ApiUserId",
                table: "Settings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ApiUserId",
                table: "Settings",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_ApiUserId",
                table: "Settings",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
