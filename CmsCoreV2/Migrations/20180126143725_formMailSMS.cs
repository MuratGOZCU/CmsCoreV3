using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class formMailSMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendMailToUser",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendSMS1ToUser",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendSMS2ToUser",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserMailAttachment",
                table: "Forms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserMailContent",
                table: "Forms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSMS1",
                table: "Forms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSMS2",
                table: "Forms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendMailToUser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "SendSMS1ToUser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "SendSMS2ToUser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserMailAttachment",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserMailContent",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserSMS1",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserSMS2",
                table: "Forms");
        }
    }
}
