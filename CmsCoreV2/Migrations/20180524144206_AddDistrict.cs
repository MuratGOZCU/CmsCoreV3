using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class AddDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

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
                name: "ShippingAddress",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "DeliveryZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Customers",
                newName: "DeliveryStreet");

            migrationBuilder.RenameColumn(
                name: "ShippingZipCode",
                table: "Customers",
                newName: "DeliveryLastName");

            migrationBuilder.RenameColumn(
                name: "ShippingStreet",
                table: "Customers",
                newName: "DeliveryFirstName");

            migrationBuilder.RenameColumn(
                name: "ShippingLastName",
                table: "Customers",
                newName: "DeliveryDistrict");

            migrationBuilder.RenameColumn(
                name: "ShippingFirstName",
                table: "Customers",
                newName: "DeliveryCounty");

            migrationBuilder.RenameColumn(
                name: "ShippingCounty",
                table: "Customers",
                newName: "DeliveryCountry");

            migrationBuilder.RenameColumn(
                name: "ShippingCountry",
                table: "Customers",
                newName: "DeliveryCompanyName");

            migrationBuilder.RenameColumn(
                name: "ShippingCompanyName",
                table: "Customers",
                newName: "DeliveryCity");

            migrationBuilder.RenameColumn(
                name: "ShippingCity",
                table: "Customers",
                newName: "DeliveryAddress");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryZipCode",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryStreet",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryLastName",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryFirstName",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCounty",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCountry",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCompanyName",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "BillingDistrict",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDistrict",
                table: "Orders",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCompanyName",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCounty",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingDistrict",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingEmail",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingFirstName",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingIdentityNumber",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingLastName",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingPhone",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingStreet",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingZipCode",
                table: "Customers",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingDistrict",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDistrict",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCompanyName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCounty",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingDistrict",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingIdentityNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingPhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingStreet",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingZipCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DeliveryZipCode",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "DeliveryStreet",
                table: "Customers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "DeliveryLastName",
                table: "Customers",
                newName: "ShippingZipCode");

            migrationBuilder.RenameColumn(
                name: "DeliveryFirstName",
                table: "Customers",
                newName: "ShippingStreet");

            migrationBuilder.RenameColumn(
                name: "DeliveryDistrict",
                table: "Customers",
                newName: "ShippingLastName");

            migrationBuilder.RenameColumn(
                name: "DeliveryCounty",
                table: "Customers",
                newName: "ShippingFirstName");

            migrationBuilder.RenameColumn(
                name: "DeliveryCountry",
                table: "Customers",
                newName: "ShippingCounty");

            migrationBuilder.RenameColumn(
                name: "DeliveryCompanyName",
                table: "Customers",
                newName: "ShippingCountry");

            migrationBuilder.RenameColumn(
                name: "DeliveryCity",
                table: "Customers",
                newName: "ShippingCompanyName");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "Customers",
                newName: "ShippingCity");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryZipCode",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryStreet",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryLastName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryFirstName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCounty",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCountry",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCompanyName",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                maxLength: 4000,
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
                name: "ShippingAddress",
                table: "Customers",
                maxLength: 4000,
                nullable: true);
        }
    }
}
