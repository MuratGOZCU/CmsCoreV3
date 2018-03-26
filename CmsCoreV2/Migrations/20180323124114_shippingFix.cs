using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CmsCoreV2.Migrations
{
    public partial class shippingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleRegions");

            migrationBuilder.DropTable(
                name: "SettingRegions");

            migrationBuilder.DropTable(
                name: "ShippingRegions");

            migrationBuilder.CreateTable(
                name: "ShippingFlatRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MethodTitle = table.Column<string>(maxLength: 200, nullable: true),
                    OrderCost = table.Column<float>(nullable: true),
                    PerCostType = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingFlatRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingZone",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalCosts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingClassId = table.Column<long>(nullable: false),
                    ShippingFlatRateId = table.Column<long>(nullable: false),
                    ShippingPrice = table.Column<float>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalCosts_ShippingClasses_ShippingClassId",
                        column: x => x.ShippingClassId,
                        principalTable: "ShippingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalCosts_ShippingFlatRates_ShippingFlatRateId",
                        column: x => x.ShippingFlatRateId,
                        principalTable: "ShippingFlatRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalCost = table.Column<float>(nullable: false),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShippingFlatRateId = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalRates_ShippingFlatRates_ShippingFlatRateId",
                        column: x => x.ShippingFlatRateId,
                        principalTable: "ShippingFlatRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingFlatRateId = table.Column<long>(nullable: false),
                    StandardShippingMethod = table.Column<int>(nullable: false),
                    StandardShippingMethodId = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingSettings_ShippingFlatRates_ShippingFlatRateId",
                        column: x => x.ShippingFlatRateId,
                        principalTable: "ShippingFlatRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingZoneRegions",
                columns: table => new
                {
                    ShippingZoneId = table.Column<long>(nullable: false),
                    RegionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingZoneRegions", x => new { x.ShippingZoneId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_ShippingZoneRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingZoneRegions_ShippingZone_ShippingZoneId",
                        column: x => x.ShippingZoneId,
                        principalTable: "ShippingZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalCosts_ShippingClassId",
                table: "AdditionalCosts",
                column: "ShippingClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalCosts_ShippingFlatRateId",
                table: "AdditionalCosts",
                column: "ShippingFlatRateId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalRates_ShippingFlatRateId",
                table: "AdditionalRates",
                column: "ShippingFlatRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingSettings_ShippingFlatRateId",
                table: "ShippingSettings",
                column: "ShippingFlatRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingZoneRegions_RegionId",
                table: "ShippingZoneRegions",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalCosts");

            migrationBuilder.DropTable(
                name: "AdditionalRates");

            migrationBuilder.DropTable(
                name: "ShippingSettings");

            migrationBuilder.DropTable(
                name: "ShippingZoneRegions");

            migrationBuilder.DropTable(
                name: "ShippingFlatRates");

            migrationBuilder.DropTable(
                name: "ShippingZone");

            migrationBuilder.CreateTable(
                name: "SaleRegions",
                columns: table => new
                {
                    SettingId = table.Column<long>(nullable: false),
                    RegionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRegions", x => new { x.SettingId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_SaleRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleRegions_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingRegions",
                columns: table => new
                {
                    SettingId = table.Column<long>(nullable: false),
                    RegionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingRegions", x => new { x.SettingId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_SettingRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingRegions_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingRegions",
                columns: table => new
                {
                    SettingId = table.Column<long>(nullable: false),
                    RegionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingRegions", x => new { x.SettingId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_ShippingRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingRegions_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleRegions_RegionId",
                table: "SaleRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingRegions_RegionId",
                table: "SettingRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRegions_RegionId",
                table: "ShippingRegions",
                column: "RegionId");
        }
    }
}
