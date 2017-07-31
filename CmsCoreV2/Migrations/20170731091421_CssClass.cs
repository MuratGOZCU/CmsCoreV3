using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class CssClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CssColor",
                table: "MenuItems",
                newName: "CssClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CssClass",
                table: "MenuItems",
                newName: "CssColor");
        }
    }
}
