using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CmsCoreV2.Migrations
{
    public partial class commerceEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                table: "PostPostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories");

            migrationBuilder.AddColumn<string>(
                name: "AddPaymentMethodSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalTaxClasses",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowAccessToDownloadableProductsAfterPaymentIsGranted",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ApiPermission",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ApiUserId",
                table: "Settings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "AutomaticallyCreateAUsernameFromTheCustomerEmail",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseColor",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BasketPageId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyBackgroundColor",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyTextColor",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottomText",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CalculateCouponDiscountInOrder",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CalculateTaxAccordingTo",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatalogOrderBy",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryView",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CreateAutomaticCustomerPassword",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CropImage",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyPosition",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerLocation",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeletePaymentMethodSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionUnit",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DownloadSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditAccountSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCoupons",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableDebugMode",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableGuestPayment",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableLowStockNotifications",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableMemberRegistrationOnTheMyAccountPage",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableMemberRegistrationOnThePaymentPage",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableOutOfStockNotifications",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableProductReviews",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableRestApi",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableStarRatingInReviews",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableStockManagement",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableStoreAnnouncement",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableTaxes",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FileDownloadMethod",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ForceHttpAfterPayment",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ForceSecurePayment",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ForgotPasswordSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HideOutOfStockProducts",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ImageHeight",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageWidth",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "LoginRequiredForDownloads",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogoutSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LowStockThreshold",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MainLocationId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MyAccountPageId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationReceivers",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderReceivedSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodsSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentPageId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceDisplayFrontPart",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PricesIncludeTax",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RedirectAfterAddingBasket",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReviewsCanOnlyBeReleasedByVerifiedUsers",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SetDefaultPaymentMethodSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingCalculation",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingDestination",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShippingMethod",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingRegion",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingTaxClass",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowPricesInStore",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowPricesOnCartAndPay",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowRememberMeOnPaymentLogin",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShowTaxTotal",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowVerifiedUserLabelInCustomerReviews",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StarRatingsAreRequired",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StockDisplayFormat",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockExhaustThreshold",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "StorePageId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorePageView",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TaxRoundAtSubTotal",
                table: "Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TermsAndConditionsPageId",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpperVisual",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViewOrderSlug",
                table: "Settings",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaitStock",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightUnit",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    AttributePosition = table.Column<int>(nullable: false),
                    AttributeType = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowFreeShipping = table.Column<bool>(nullable: false),
                    AppTenantId = table.Column<string>(nullable: true),
                    CouponAmount = table.Column<decimal>(nullable: false),
                    CouponCode = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiscountType = table.Column<int>(nullable: false),
                    ExcludeDiscountProduct = table.Column<bool>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    LimitPerCoupon = table.Column<int>(nullable: false),
                    LimitPerUser = table.Column<int>(nullable: false),
                    LimitUse = table.Column<int>(nullable: true),
                    MaximumSpending = table.Column<decimal>(nullable: false),
                    MinimumSpending = table.Column<decimal>(nullable: false),
                    OnlyIndividualUse = table.Column<bool>(nullable: false),
                    RestrictedEmails = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 200, nullable: true),
                    DecimalScale = table.Column<string>(maxLength: 200, nullable: true),
                    DecimalSeparator = table.Column<string>(maxLength: 200, nullable: true),
                    ThousandsSeparator = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    EmailTitle = table.Column<string>(maxLength: 200, nullable: true),
                    EmailType = table.Column<int>(nullable: false),
                    EnableThisEmailNotification = table.Column<bool>(nullable: false),
                    Recipients = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(maxLength: 200, nullable: true),
                    Template = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaFields",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptForVirtualOrders = table.Column<bool>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AddressInvalid = table.Column<bool>(nullable: false),
                    ApiPassword = table.Column<string>(nullable: true),
                    ApiSignature = table.Column<string>(nullable: true),
                    ApiUserName = table.Column<string>(nullable: true),
                    AppTenantId = table.Column<string>(nullable: true),
                    BIC = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BuyerEmail = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    DebugRegister = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    EnableCheckPayments = table.Column<bool>(nullable: false),
                    EnableForShipmentMethods = table.Column<int>(nullable: false),
                    EnablePayAtTheDoor = table.Column<bool>(nullable: false),
                    EnablePayPalStandart = table.Column<bool>(nullable: false),
                    IBAN = table.Column<string>(nullable: true),
                    ImageAddress = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    InvoiceFront = table.Column<string>(nullable: true),
                    PageFormat = table.Column<string>(nullable: true),
                    PayPalEmail = table.Column<string>(nullable: true),
                    PayPalIdentityKey = table.Column<string>(nullable: true),
                    PayPalTestMethod = table.Column<bool>(nullable: false),
                    PaymentAction = table.Column<int>(nullable: false),
                    SubmissionInformation = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CatalogVisibility = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CrossSellId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupedProductId = table.Column<long>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    MenuOrder = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: false),
                    ProductUrl = table.Column<string>(nullable: true),
                    PurchaseNote = table.Column<string>(nullable: true),
                    SaleCount = table.Column<int>(nullable: false),
                    SalePrice = table.Column<decimal>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    StockCode = table.Column<string>(nullable: true),
                    StockCount = table.Column<int>(nullable: false),
                    StockStatus = table.Column<bool>(nullable: false),
                    TaxClass = table.Column<int>(nullable: false),
                    TaxStatus = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UpSellId = table.Column<long>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_CrossSellId",
                        column: x => x.CrossSellId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_GroupedProductId",
                        column: x => x.GroupedProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_UpSellId",
                        column: x => x.UpSellId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    SmallImage = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    parentCategoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_parentCategoryId",
                        column: x => x.parentCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ParentRegionId = table.Column<long>(nullable: true),
                    RegionType = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Regions_ParentRegionId",
                        column: x => x.ParentRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingClasses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShippingClassName = table.Column<string>(maxLength: 200, nullable: true),
                    Slug = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ProductAttributeId = table.Column<long>(nullable: true),
                    Slug = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    Value = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeItems_Attributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CouponProducts",
                columns: table => new
                {
                    CouponId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponProducts", x => new { x.CouponId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CouponProducts_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExcludeCouponProducts",
                columns: table => new
                {
                    CouponId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludeCouponProducts", x => new { x.CouponId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ExcludeCouponProducts_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcludeCouponProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Refund = table.Column<decimal>(nullable: false),
                    RefundDetails = table.Column<string>(nullable: true),
                    ShippingPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    AttributeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => new { x.ProductId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedias",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    MediaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedias", x => new { x.ProductId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_ProductMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMedias_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponProductCategories",
                columns: table => new
                {
                    CouponId = table.Column<long>(nullable: false),
                    ProductCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponProductCategories", x => new { x.CouponId, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_CouponProductCategories_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponProductCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcludeCouponProductCategories",
                columns: table => new
                {
                    CouponId = table.Column<long>(nullable: false),
                    ProductCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludeCouponProductCategories", x => new { x.CouponId, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_ExcludeCouponProductCategories_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcludeCouponProductCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    ProductCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductCategories", x => new { x.ProductId, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductProductCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductTags",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    ProductTagId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductTags", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductTags_ProductTags_ProductTagId",
                        column: x => x.ProductTagId,
                        principalTable: "ProductTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(maxLength: 4000, nullable: true),
                    BillingCityId = table.Column<long>(nullable: true),
                    BillingCompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    BillingCountryId = table.Column<long>(nullable: true),
                    BillingDistrictId = table.Column<long>(nullable: true),
                    BillingFirstName = table.Column<string>(maxLength: 200, nullable: true),
                    BillingLastName = table.Column<string>(maxLength: 200, nullable: true),
                    BillingZipCode = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingAddress = table.Column<string>(maxLength: 4000, nullable: true),
                    ShippingCityId = table.Column<long>(nullable: true),
                    ShippingCompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingCountryId = table.Column<long>(nullable: true),
                    ShippingDistrictId = table.Column<long>(nullable: true),
                    ShippingFirstName = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingLastName = table.Column<string>(maxLength: 200, nullable: true),
                    ShippingZipCode = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_BillingCityId",
                        column: x => x.BillingCityId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_BillingCountryId",
                        column: x => x.BillingCountryId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_BillingDistrictId",
                        column: x => x.BillingDistrictId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_ShippingCityId",
                        column: x => x.ShippingCityId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_ShippingCountryId",
                        column: x => x.ShippingCountryId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_ShippingDistrictId",
                        column: x => x.ShippingDistrictId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CityPlateCode = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    Rate = table.Column<float>(nullable: false),
                    TaxName = table.Column<string>(maxLength: 200, nullable: true),
                    TaxRateCompound = table.Column<bool>(nullable: false),
                    TaxRatePriority = table.Column<int>(nullable: false),
                    TaxRateShipping = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRates_Regions_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    CustomerId = table.Column<long>(nullable: true),
                    CustomerNote = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<long>(nullable: true),
                    Phone = table.Column<string>(maxLength: 200, nullable: true),
                    TransactionId = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderMetaFields",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false),
                    MetaFieldId = table.Column<long>(nullable: false),
                    AppTenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMetaFields", x => new { x.OrderId, x.MetaFieldId });
                    table.ForeignKey(
                        name: "FK_OrderMetaFields_MetaFields_MetaFieldId",
                        column: x => x.MetaFieldId,
                        principalTable: "MetaFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMetaFields_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNotes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppTenantId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ISPrivate = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: false),
                    OrderId = table.Column<long>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderOrderItems",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false),
                    OrderItemId = table.Column<long>(nullable: false),
                    AppTenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderItems", x => new { x.OrderId, x.OrderItemId });
                    table.ForeignKey(
                        name: "FK_OrderOrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItems_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ApiUserId",
                table: "Settings",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BasketPageId",
                table: "Settings",
                column: "BasketPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CurrencyId",
                table: "Settings",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_MainLocationId",
                table: "Settings",
                column: "MainLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_MyAccountPageId",
                table: "Settings",
                column: "MyAccountPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_PaymentPageId",
                table: "Settings",
                column: "PaymentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_StorePageId",
                table: "Settings",
                column: "StorePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_TermsAndConditionsPageId",
                table: "Settings",
                column: "TermsAndConditionsPageId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeItems_ProductAttributeId",
                table: "AttributeItems",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponProducts_ProductId",
                table: "CouponProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponProductCategories_ProductCategoryId",
                table: "CouponProductCategories",
                column: "ProductCategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ExcludeCouponProducts_ProductId",
                table: "ExcludeCouponProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcludeCouponProductCategories_ProductCategoryId",
                table: "ExcludeCouponProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMetaFields_MetaFieldId",
                table: "OrderMetaFields",
                column: "MetaFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNotes_OrderId",
                table: "OrderNotes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItems_OrderItemId",
                table: "OrderOrderItems",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CrossSellId",
                table: "Products",
                column: "CrossSellId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupedProductId",
                table: "Products",
                column: "GroupedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpSellId",
                table: "Products",
                column: "UpSellId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_AttributeId",
                table: "ProductAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_parentCategoryId",
                table: "ProductCategories",
                column: "parentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedias_MediaId",
                table: "ProductMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductCategories_ProductCategoryId",
                table: "ProductProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTags_ProductTagId",
                table: "ProductProductTags",
                column: "ProductTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_DistrictId",
                table: "TaxRates",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                table: "PostPostCategories",
                column: "PostCategoryId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_ApiUserId",
                table: "Settings",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Pages_BasketPageId",
                table: "Settings",
                column: "BasketPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Currencies_CurrencyId",
                table: "Settings",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Regions_MainLocationId",
                table: "Settings",
                column: "MainLocationId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Pages_MyAccountPageId",
                table: "Settings",
                column: "MyAccountPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Pages_PaymentPageId",
                table: "Settings",
                column: "PaymentPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Pages_StorePageId",
                table: "Settings",
                column: "StorePageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Pages_TermsAndConditionsPageId",
                table: "Settings",
                column: "TermsAndConditionsPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                table: "PostPostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_ApiUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Pages_BasketPageId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Currencies_CurrencyId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Regions_MainLocationId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Pages_MyAccountPageId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Pages_PaymentPageId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Pages_StorePageId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Pages_TermsAndConditionsPageId",
                table: "Settings");

            migrationBuilder.DropTable(
                name: "AttributeItems");

            migrationBuilder.DropTable(
                name: "CouponProducts");

            migrationBuilder.DropTable(
                name: "CouponProductCategories");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "ExcludeCouponProducts");

            migrationBuilder.DropTable(
                name: "ExcludeCouponProductCategories");

            migrationBuilder.DropTable(
                name: "OrderMetaFields");

            migrationBuilder.DropTable(
                name: "OrderNotes");

            migrationBuilder.DropTable(
                name: "OrderOrderItems");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductMedias");

            migrationBuilder.DropTable(
                name: "ProductProductCategories");

            migrationBuilder.DropTable(
                name: "ProductProductTags");

            migrationBuilder.DropTable(
                name: "SaleRegions");

            migrationBuilder.DropTable(
                name: "SettingRegions");

            migrationBuilder.DropTable(
                name: "ShippingClasses");

            migrationBuilder.DropTable(
                name: "ShippingRegions");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "MetaFields");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Settings_ApiUserId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_BasketPageId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_CurrencyId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_MainLocationId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_MyAccountPageId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_PaymentPageId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_StorePageId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_TermsAndConditionsPageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddPaymentMethodSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AdditionalTaxClasses",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AllowAccessToDownloadableProductsAfterPaymentIsGranted",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ApiPermission",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AutomaticallyCreateAUsernameFromTheCustomerEmail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BaseColor",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BasketPageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BodyBackgroundColor",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BodyTextColor",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BottomText",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CalculateCouponDiscountInOrder",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CalculateTaxAccordingTo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CatalogOrderBy",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CategoryView",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CreateAutomaticCustomerPassword",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CropImage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CurrencyPosition",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CustomerLocation",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DeletePaymentMethodSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DimensionUnit",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DownloadSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EditAccountSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableCoupons",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableDebugMode",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableGuestPayment",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableLowStockNotifications",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableMemberRegistrationOnTheMyAccountPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableMemberRegistrationOnThePaymentPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableOutOfStockNotifications",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableProductReviews",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableRestApi",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableStarRatingInReviews",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableStockManagement",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableStoreAnnouncement",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableTaxes",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FileDownloadMethod",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ForceHttpAfterPayment",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ForceSecurePayment",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ForgotPasswordSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HideOutOfStockProducts",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ImageHeight",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LoginRequiredForDownloads",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LogoutSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LowStockThreshold",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MainLocationId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MyAccountPageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "NotificationReceivers",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OrderReceivedSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OrderSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PaymentMethodsSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PaymentPageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PaymentSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PriceDisplayFrontPart",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PricesIncludeTax",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "RedirectAfterAddingBasket",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ReviewsCanOnlyBeReleasedByVerifiedUsers",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SetDefaultPaymentMethodSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingCalculation",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingDestination",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingRegion",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShippingTaxClass",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPricesInStore",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPricesOnCartAndPay",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowRememberMeOnPaymentLogin",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowTaxTotal",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowVerifiedUserLabelInCustomerReviews",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StarRatingsAreRequired",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StockDisplayFormat",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StockExhaustThreshold",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StorePageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StorePageView",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TaxRoundAtSubTotal",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsPageId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UpperVisual",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ViewOrderSlug",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WaitStock",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WeightUnit",
                table: "Settings");

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                table: "PostPostCategories",
                column: "PostCategoryId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostPostCategories_Posts_PostId",
                table: "PostPostCategories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
