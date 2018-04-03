using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class paymentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptForVirtualOrders",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "AddressInvalid",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ApiSignature",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BIC",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "DebugRegister",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "EnableCheckPayments",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "EnableForShipmentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "EnablePayAtTheDoor",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "EnablePayPalStandart",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ImageAddress",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "InvoiceFront",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PageFormat",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PayPalEmail",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PayPalIdentityKey",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PayPalTestMethod",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PaymentAction",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "SubmissionInformation",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<string>(
                name: "ApiUserName",
                table: "PaymentMethods",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiPassword",
                table: "PaymentMethods",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiUrl",
                table: "PaymentMethods",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PaymentMethods",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiUrl",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<string>(
                name: "ApiUserName",
                table: "PaymentMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiPassword",
                table: "PaymentMethods",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptForVirtualOrders",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AddressInvalid",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApiSignature",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BIC",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerEmail",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DebugRegister",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCheckPayments",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EnableForShipmentMethods",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EnablePayAtTheDoor",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnablePayPalStandart",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAddress",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceFront",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageFormat",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayPalEmail",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayPalIdentityKey",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PayPalTestMethod",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentAction",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SubmissionInformation",
                table: "PaymentMethods",
                nullable: false,
                defaultValue: false);
        }
    }
}
