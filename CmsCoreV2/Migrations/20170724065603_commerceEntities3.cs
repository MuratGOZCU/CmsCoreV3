using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsCoreV2.Migrations
{
    public partial class commerceEntities3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponProducts_Coupon_CouponId",
                table: "CouponProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CouponProductCategories_Coupon_CouponId",
                table: "CouponProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ExcludeCouponProducts_Coupon_CouponId",
                table: "ExcludeCouponProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExcludeCouponProductCategories_Coupon_CouponId",
                table: "ExcludeCouponProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon");

            migrationBuilder.RenameTable(
                name: "Coupon",
                newName: "Coupons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponProducts_Coupons_CouponId",
                table: "CouponProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CouponProductCategories_Coupons_CouponId",
                table: "CouponProductCategories",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludeCouponProducts_Coupons_CouponId",
                table: "ExcludeCouponProducts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludeCouponProductCategories_Coupons_CouponId",
                table: "ExcludeCouponProductCategories",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponProducts_Coupons_CouponId",
                table: "CouponProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CouponProductCategories_Coupons_CouponId",
                table: "CouponProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ExcludeCouponProducts_Coupons_CouponId",
                table: "ExcludeCouponProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExcludeCouponProductCategories_Coupons_CouponId",
                table: "ExcludeCouponProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "Coupon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponProducts_Coupon_CouponId",
                table: "CouponProducts",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CouponProductCategories_Coupon_CouponId",
                table: "CouponProductCategories",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludeCouponProducts_Coupon_CouponId",
                table: "ExcludeCouponProducts",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExcludeCouponProductCategories_Coupon_CouponId",
                table: "ExcludeCouponProductCategories",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
