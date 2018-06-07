using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class productFix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedias_Medias_MediaId",
                table: "ProductMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMedias",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "AlternateProductImage",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "MediaId",
                table: "ProductMedias",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductMedias",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AppTenantId",
                table: "ProductMedias",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ProductMedias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductMedias",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "ProductMedias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Position",
                table: "ProductMedias",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductMedias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ProductMedias",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMedias",
                table: "ProductMedias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedias_Medias_MediaId",
                table: "ProductMedias",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedias_Medias_MediaId",
                table: "ProductMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMedias",
                table: "ProductMedias");

            migrationBuilder.DropIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "AppTenantId",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductMedias");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductMedias");

            migrationBuilder.AddColumn<string>(
                name: "AlternateProductImage",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MediaId",
                table: "ProductMedias",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMedias",
                table: "ProductMedias",
                columns: new[] { "ProductId", "MediaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedias_Medias_MediaId",
                table: "ProductMedias",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
