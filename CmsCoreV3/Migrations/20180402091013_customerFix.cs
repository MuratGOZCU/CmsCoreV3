using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV3.Migrations
{
    public partial class customerFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_BillingCityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_BillingCountryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_BillingDistrictId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_ShippingCityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_ShippingCountryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Regions_ShippingDistrictId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BillingCityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BillingCountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BillingDistrictId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ShippingCityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ShippingCountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ShippingDistrictId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingCityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingDistrictId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingCityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingCountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingDistrictId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "County",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BillingZipCode",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "BillingLastName",
                table: "Customers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "BillingFirstName",
                table: "Customers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "BillingCompanyName",
                table: "Customers",
                newName: "ShippingCounty");

            migrationBuilder.RenameColumn(
                name: "BillingAddress",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCompanyName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCounty",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingEmail",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingFirstName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingIdentityNumber",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingLastName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingPhone",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingStreet",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingZipCode",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCompanyName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCountry",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCounty",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryFirstName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryLastName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryStreet",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryZipCode",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCityCode",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCity",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCountry",
                table: "Customers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckout",
                table: "Carts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderCoupon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowFreeShipping = table.Column<bool>(nullable: false),
                    AppTenantId = table.Column<string>(nullable: true),
                    CouponAmount = table.Column<float>(nullable: false),
                    CouponCode = table.Column<string>(maxLength: 200, nullable: true),
                    CouponId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiscountType = table.Column<int>(nullable: false),
                    ExcludeDiscountProduct = table.Column<bool>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    LimitPerCoupon = table.Column<int>(nullable: false),
                    LimitPerUser = table.Column<int>(nullable: false),
                    LimitUse = table.Column<int>(nullable: true),
                    MaximumSpending = table.Column<float>(nullable: false),
                    MinimumSpending = table.Column<float>(nullable: false),
                    OnlyIndividualUse = table.Column<bool>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCoupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderCoupon_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCoupon_OrderId",
                table: "OrderCoupon",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderCoupon");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingCompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingCounty",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingIdentityNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingStreet",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingZipCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCountry",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCounty",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryStreet",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryZipCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DestinationCityCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingCountry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsCheckout",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "BillingZipCode");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customers",
                newName: "BillingLastName");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Customers",
                newName: "BillingFirstName");

            migrationBuilder.RenameColumn(
                name: "ShippingCounty",
                table: "Customers",
                newName: "BillingCompanyName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "BillingAddress");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BillingCityId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BillingCountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BillingDistrictId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShippingCityId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShippingCountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShippingDistrictId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingCityId",
                table: "Customers",
                column: "BillingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingCountryId",
                table: "Customers",
                column: "BillingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingDistrictId",
                table: "Customers",
                column: "BillingDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingCityId",
                table: "Customers",
                column: "ShippingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingCountryId",
                table: "Customers",
                column: "ShippingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingDistrictId",
                table: "Customers",
                column: "ShippingDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_BillingCityId",
                table: "Customers",
                column: "BillingCityId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_BillingCountryId",
                table: "Customers",
                column: "BillingCountryId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_BillingDistrictId",
                table: "Customers",
                column: "BillingDistrictId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_ShippingCityId",
                table: "Customers",
                column: "ShippingCityId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_ShippingCountryId",
                table: "Customers",
                column: "ShippingCountryId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Regions_ShippingDistrictId",
                table: "Customers",
                column: "ShippingDistrictId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
