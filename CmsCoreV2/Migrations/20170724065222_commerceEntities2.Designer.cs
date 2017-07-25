using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CmsCoreV2.Data;
using CmsCoreV2.Models;

namespace CmsCoreV2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170724065222_commerceEntities2")]
    partial class commerceEntities2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CmsCoreV2.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AppTenantId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Attribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<int>("AttributePosition");

                    b.Property<int>("AttributeType");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("CmsCoreV2.Models.AttributeItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ProductAttributeId");

                    b.Property<string>("Slug")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ProductAttributeId");

                    b.ToTable("AttributeItems");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Coupon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowFreeShipping");

                    b.Property<string>("AppTenantId");

                    b.Property<decimal>("CouponAmount");

                    b.Property<string>("CouponCode")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<int>("DiscountType");

                    b.Property<bool>("ExcludeDiscountProduct");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<int>("LimitPerCoupon");

                    b.Property<int>("LimitPerUser");

                    b.Property<int?>("LimitUse");

                    b.Property<decimal>("MaximumSpending");

                    b.Property<decimal>("MinimumSpending");

                    b.Property<bool>("OnlyIndividualUse");

                    b.Property<string>("RestrictedEmails");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("CmsCoreV2.Models.CouponProduct", b =>
                {
                    b.Property<long>("CouponId");

                    b.Property<long>("ProductId");

                    b.HasKey("CouponId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CouponProducts");
                });

            modelBuilder.Entity("CmsCoreV2.Models.CouponProductCategory", b =>
                {
                    b.Property<long>("CouponId");

                    b.Property<long>("ProductCategoryId");

                    b.HasKey("CouponId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("CouponProductCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(200);

                    b.Property<string>("DecimalScale")
                        .HasMaxLength(200);

                    b.Property<string>("DecimalSeparator")
                        .HasMaxLength(200);

                    b.Property<string>("ThousandsSeparator")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("BillingAddress")
                        .HasMaxLength(4000);

                    b.Property<long?>("BillingCityId");

                    b.Property<string>("BillingCompanyName")
                        .HasMaxLength(200);

                    b.Property<long?>("BillingCountryId");

                    b.Property<long?>("BillingDistrictId");

                    b.Property<string>("BillingFirstName")
                        .HasMaxLength(200);

                    b.Property<string>("BillingLastName")
                        .HasMaxLength(200);

                    b.Property<string>("BillingZipCode")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("ShippingAddress")
                        .HasMaxLength(4000);

                    b.Property<long?>("ShippingCityId");

                    b.Property<string>("ShippingCompanyName")
                        .HasMaxLength(200);

                    b.Property<long?>("ShippingCountryId");

                    b.Property<long?>("ShippingDistrictId");

                    b.Property<string>("ShippingFirstName")
                        .HasMaxLength(200);

                    b.Property<string>("ShippingLastName")
                        .HasMaxLength(200);

                    b.Property<string>("ShippingZipCode")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BillingCityId");

                    b.HasIndex("BillingCountryId");

                    b.HasIndex("BillingDistrictId");

                    b.HasIndex("ShippingCityId");

                    b.HasIndex("ShippingCountryId");

                    b.HasIndex("ShippingDistrictId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Customization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("ComponentTemplates");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("CustomCSS");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<string>("ManyLocations");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaKeywords");

                    b.Property<string>("MetaTitle")
                        .HasMaxLength(200);

                    b.Property<string>("PageTemplates");

                    b.Property<long>("ThemeId");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Customizations");
                });

            modelBuilder.Entity("CmsCoreV2.Models.EmailTemplate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("EmailTitle")
                        .HasMaxLength(200);

                    b.Property<int>("EmailType");

                    b.Property<bool>("EnableThisEmailNotification");

                    b.Property<string>("Recipients");

                    b.Property<string>("Subject")
                        .HasMaxLength(200);

                    b.Property<string>("Template")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ExcludeCouponProduct", b =>
                {
                    b.Property<long>("CouponId");

                    b.Property<long>("ProductId");

                    b.HasKey("CouponId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExcludeCouponProducts");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ExcludeCouponProductCategory", b =>
                {
                    b.Property<long>("CouponId");

                    b.Property<long>("ProductCategoryId");

                    b.HasKey("CouponId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ExcludeCouponProductCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long>("FormId");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("IP")
                        .IsRequired();

                    b.Property<DateTime>("SentDate");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("CmsCoreV2.Models.FeedbackValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("FeedbackId");

                    b.Property<int>("FieldType");

                    b.Property<long>("FormFieldId");

                    b.Property<string>("FormFieldName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Position");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId");

                    b.ToTable("FeedbackValues");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("ClosingDescription");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("EmailBcc")
                        .HasMaxLength(200);

                    b.Property<string>("EmailCc")
                        .HasMaxLength(200);

                    b.Property<string>("EmailTo")
                        .HasMaxLength(200);

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("GoogleAnalyticsCode");

                    b.Property<bool>("IsPublished");

                    b.Property<long?>("LanguageId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Template");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("CmsCoreV2.Models.FormField", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<int>("FieldType");

                    b.Property<long?>("FormId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Position");

                    b.Property<bool>("Required");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormFields");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Gallery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<long?>("GalleryId");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Meta1");

                    b.Property<string>("Photo");

                    b.Property<int>("Position");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Video");

                    b.HasKey("Id");

                    b.HasIndex("GalleryId");

                    b.ToTable("GalleryItems");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItemCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentCategoryId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("GalleryItemCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItemGalleryItemCategory", b =>
                {
                    b.Property<long>("GalleryItemId");

                    b.Property<long>("GalleryItemCategoryId");

                    b.Property<string>("AppTenantId");

                    b.HasKey("GalleryItemId", "GalleryItemCategoryId");

                    b.HasIndex("GalleryItemCategoryId");

                    b.ToTable("GalleryItemGalleryItemCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NativeName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("FileName")
                        .HasMaxLength(200);

                    b.Property<string>("FileType")
                        .HasMaxLength(200);

                    b.Property<string>("FileUrl");

                    b.Property<decimal>("Size");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("LanguageId");

                    b.Property<string>("MenuLocation")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CmsCoreV2.Models.MenuItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsPublished");

                    b.Property<long?>("MenuId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentMenuItemId");

                    b.Property<int>("Position");

                    b.Property<string>("Target")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("ParentMenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("CmsCoreV2.Models.MetaField", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("MetaFields");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("CustomerId");

                    b.Property<string>("CustomerNote");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderStatus");

                    b.Property<long?>("PaymentMethodId");

                    b.Property<string>("Phone")
                        .HasMaxLength(200);

                    b.Property<long>("TransactionId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<decimal>("DiscountPrice");

                    b.Property<long?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Refund");

                    b.Property<string>("RefundDetails");

                    b.Property<decimal>("ShippingPrice");

                    b.Property<decimal>("TotalPrice");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderMetaField", b =>
                {
                    b.Property<long>("OrderId");

                    b.Property<long>("MetaFieldId");

                    b.Property<string>("AppTenantId");

                    b.HasKey("OrderId", "MetaFieldId");

                    b.HasIndex("MetaFieldId");

                    b.ToTable("OrderMetaFields");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderNote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("ISPrivate");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("OrderId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderNotes");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderOrderItem", b =>
                {
                    b.Property<long>("OrderId");

                    b.Property<long>("OrderItemId");

                    b.Property<string>("AppTenantId");

                    b.HasKey("OrderId", "OrderItemId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("OrderOrderItems");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsPublished");

                    b.Property<long?>("LanguageId");

                    b.Property<string>("LayoutTemplate")
                        .HasMaxLength(200);

                    b.Property<string>("Meta1")
                        .HasMaxLength(200);

                    b.Property<string>("Meta2")
                        .HasMaxLength(200);

                    b.Property<long?>("ParentPageId");

                    b.Property<string>("Photo")
                        .HasMaxLength(200);

                    b.Property<int>("Position");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle")
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Template")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentPageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("CmsCoreV2.Models.PaymentMethod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AcceptForVirtualOrders");

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNumber");

                    b.Property<bool>("AddressInvalid");

                    b.Property<string>("ApiPassword");

                    b.Property<string>("ApiSignature");

                    b.Property<string>("ApiUserName");

                    b.Property<string>("AppTenantId");

                    b.Property<string>("BIC");

                    b.Property<string>("BankName");

                    b.Property<string>("BuyerEmail");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("DebugRegister");

                    b.Property<string>("Description");

                    b.Property<bool>("Enable");

                    b.Property<bool>("EnableCheckPayments");

                    b.Property<int>("EnableForShipmentMethods");

                    b.Property<bool>("EnablePayAtTheDoor");

                    b.Property<bool>("EnablePayPalStandart");

                    b.Property<string>("IBAN");

                    b.Property<string>("ImageAddress");

                    b.Property<string>("Instructions");

                    b.Property<string>("InvoiceFront");

                    b.Property<string>("PageFormat");

                    b.Property<string>("PayPalEmail");

                    b.Property<string>("PayPalIdentityKey");

                    b.Property<bool>("PayPalTestMethod");

                    b.Property<int>("PaymentAction");

                    b.Property<bool>("SubmissionInformation");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<bool>("IsPublished");

                    b.Property<long?>("LanguageId");

                    b.Property<string>("Meta1");

                    b.Property<string>("Meta2");

                    b.Property<string>("Photo")
                        .HasMaxLength(200);

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle")
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CmsCoreV2.Models.PostCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<long?>("LanguageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentCategoryId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.PostPostCategory", b =>
                {
                    b.Property<long>("PostId");

                    b.Property<long>("PostCategoryId");

                    b.Property<string>("AppTenantId");

                    b.HasKey("PostId", "PostCategoryId");

                    b.HasIndex("PostCategoryId");

                    b.ToTable("PostPostCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<int>("CatalogVisibility");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("CrossSellId");

                    b.Property<string>("Description");

                    b.Property<long?>("GroupedProductId");

                    b.Property<double>("Height");

                    b.Property<bool>("IsFeatured");

                    b.Property<double>("Length");

                    b.Property<int>("MenuOrder");

                    b.Property<string>("Name");

                    b.Property<string>("ProductImage");

                    b.Property<int>("ProductType");

                    b.Property<string>("ProductUrl");

                    b.Property<string>("PurchaseNote");

                    b.Property<int>("SaleCount");

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Slug");

                    b.Property<string>("StockCode");

                    b.Property<int>("StockCount");

                    b.Property<bool>("StockStatus");

                    b.Property<int>("TaxClass");

                    b.Property<int>("TaxStatus");

                    b.Property<decimal>("UnitPrice");

                    b.Property<long?>("UpSellId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<int>("ViewCount");

                    b.Property<double>("Weight");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CrossSellId");

                    b.HasIndex("GroupedProductId");

                    b.HasIndex("UpSellId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductAttribute", b =>
                {
                    b.Property<long>("ProductId");

                    b.Property<long>("AttributeId");

                    b.HasKey("ProductId", "AttributeId");

                    b.HasIndex("AttributeId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("Color")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Slug");

                    b.Property<string>("SmallImage");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("parentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("parentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductMedia", b =>
                {
                    b.Property<long>("ProductId");

                    b.Property<long>("MediaId");

                    b.HasKey("ProductId", "MediaId");

                    b.HasIndex("MediaId");

                    b.ToTable("ProductMedias");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductProductCategory", b =>
                {
                    b.Property<long>("ProductId");

                    b.Property<long>("ProductCategoryId");

                    b.HasKey("ProductId", "ProductCategoryId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductProductCategories");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductProductTag", b =>
                {
                    b.Property<long>("ProductId");

                    b.Property<long>("ProductTagId");

                    b.HasKey("ProductId", "ProductTagId");

                    b.HasIndex("ProductTagId");

                    b.ToTable("ProductProductTags");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Redirect", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NewUrl")
                        .IsRequired();

                    b.Property<string>("OldUrl")
                        .IsRequired();

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Redirects");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ParentRegionId");

                    b.Property<int>("RegionType");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ParentRegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("LanguageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CmsCoreV2.Models.SaleRegion", b =>
                {
                    b.Property<long>("SettingId");

                    b.Property<long>("RegionId");

                    b.HasKey("SettingId", "RegionId");

                    b.HasIndex("RegionId");

                    b.ToTable("SaleRegions");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Setting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddPaymentMethodSlug")
                        .HasMaxLength(200);

                    b.Property<string>("AdditionalTaxClasses")
                        .HasMaxLength(200);

                    b.Property<string>("AddressSlug")
                        .HasMaxLength(200);

                    b.Property<bool>("AllowAccessToDownloadableProductsAfterPaymentIsGranted");

                    b.Property<int>("ApiPermission");

                    b.Property<string>("ApiUser");

                    b.Property<string>("AppTenantId");

                    b.Property<bool>("AutomaticallyCreateAUsernameFromTheCustomerEmail");

                    b.Property<string>("BackgroundColor")
                        .HasMaxLength(200);

                    b.Property<string>("BaseColor")
                        .HasMaxLength(200);

                    b.Property<long?>("BasketPageId");

                    b.Property<string>("BodyBackgroundColor")
                        .HasMaxLength(200);

                    b.Property<string>("BodyTextColor")
                        .HasMaxLength(200);

                    b.Property<string>("BottomText");

                    b.Property<bool>("CalculateCouponDiscountInOrder");

                    b.Property<int>("CalculateTaxAccordingTo");

                    b.Property<int>("CatalogOrderBy");

                    b.Property<int>("CategoryView");

                    b.Property<bool>("CreateAutomaticCustomerPassword");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("CropImage");

                    b.Property<long?>("CurrencyId");

                    b.Property<int>("CurrencyPosition");

                    b.Property<int>("CustomerLocation");

                    b.Property<string>("DeletePaymentMethodSlug")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<int>("DimensionUnit");

                    b.Property<string>("DownloadSlug")
                        .HasMaxLength(200);

                    b.Property<string>("EditAccountSlug")
                        .HasMaxLength(200);

                    b.Property<bool>("EnableCoupons");

                    b.Property<bool>("EnableDebugMode");

                    b.Property<bool>("EnableGuestPayment");

                    b.Property<bool>("EnableLowStockNotifications");

                    b.Property<bool>("EnableMemberRegistrationOnTheMyAccountPage");

                    b.Property<bool>("EnableMemberRegistrationOnThePaymentPage");

                    b.Property<bool>("EnableOutOfStockNotifications");

                    b.Property<bool>("EnableProductReviews");

                    b.Property<bool>("EnableRestApi");

                    b.Property<bool>("EnableStarRatingInReviews");

                    b.Property<bool>("EnableStockManagement");

                    b.Property<bool>("EnableStoreAnnouncement");

                    b.Property<bool>("EnableTaxes");

                    b.Property<int>("FileDownloadMethod");

                    b.Property<string>("FooterScript");

                    b.Property<bool>("ForceHttpAfterPayment");

                    b.Property<bool>("ForceSecurePayment");

                    b.Property<string>("ForgotPasswordSlug")
                        .HasMaxLength(200);

                    b.Property<string>("GoogleAnalytics");

                    b.Property<string>("HeaderString");

                    b.Property<bool>("HideOutOfStockProducts");

                    b.Property<int>("ImageHeight");

                    b.Property<int>("ImageWidth");

                    b.Property<bool>("LoginRequiredForDownloads");

                    b.Property<string>("LogoutSlug")
                        .HasMaxLength(200);

                    b.Property<int>("LowStockThreshold");

                    b.Property<long?>("MainLocationId");

                    b.Property<string>("MapLat")
                        .HasMaxLength(200);

                    b.Property<string>("MapLon")
                        .HasMaxLength(200);

                    b.Property<string>("MapTitle")
                        .HasMaxLength(200);

                    b.Property<long?>("MyAccountPageId");

                    b.Property<string>("NotificationReceivers");

                    b.Property<string>("OrderReceivedSlug")
                        .HasMaxLength(200);

                    b.Property<string>("OrderSlug")
                        .HasMaxLength(200);

                    b.Property<string>("PaymentMethodsSlug")
                        .HasMaxLength(200);

                    b.Property<long?>("PaymentPageId");

                    b.Property<string>("PaymentSlug")
                        .HasMaxLength(200);

                    b.Property<string>("PriceDisplayFrontPart")
                        .HasMaxLength(200);

                    b.Property<bool>("PricesIncludeTax");

                    b.Property<bool>("RedirectAfterAddingBasket");

                    b.Property<bool>("ReviewsCanOnlyBeReleasedByVerifiedUsers");

                    b.Property<string>("SenderEmail")
                        .HasMaxLength(200);

                    b.Property<string>("SenderName")
                        .HasMaxLength(200);

                    b.Property<string>("SetDefaultPaymentMethodSlug")
                        .HasMaxLength(200);

                    b.Property<int>("ShippingCalculation");

                    b.Property<int>("ShippingDestination");

                    b.Property<int>("ShippingMethod");

                    b.Property<string>("ShippingRegion")
                        .HasMaxLength(200);

                    b.Property<int>("ShippingTaxClass");

                    b.Property<int>("ShowPricesInStore");

                    b.Property<int>("ShowPricesOnCartAndPay");

                    b.Property<bool>("ShowRememberMeOnPaymentLogin");

                    b.Property<int>("ShowTaxTotal");

                    b.Property<bool>("ShowVerifiedUserLabelInCustomerReviews");

                    b.Property<string>("SmtpHost")
                        .HasMaxLength(200);

                    b.Property<string>("SmtpPassword")
                        .HasMaxLength(200);

                    b.Property<string>("SmtpPort")
                        .HasMaxLength(200);

                    b.Property<bool>("SmtpUseSSL");

                    b.Property<string>("SmtpUserName")
                        .HasMaxLength(200);

                    b.Property<bool>("StarRatingsAreRequired");

                    b.Property<int>("StockDisplayFormat");

                    b.Property<int>("StockExhaustThreshold");

                    b.Property<long?>("StorePageId");

                    b.Property<int>("StorePageView");

                    b.Property<bool>("TaxRoundAtSubTotal");

                    b.Property<long?>("TermsAndConditionsPageId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("UpperVisual")
                        .HasMaxLength(200);

                    b.Property<string>("ViewOrderSlug")
                        .HasMaxLength(200);

                    b.Property<int>("WaitStock");

                    b.Property<int>("WeightUnit");

                    b.HasKey("Id");

                    b.HasIndex("BasketPageId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("MainLocationId");

                    b.HasIndex("MyAccountPageId");

                    b.HasIndex("PaymentPageId");

                    b.HasIndex("StorePageId");

                    b.HasIndex("TermsAndConditionsPageId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("CmsCoreV2.Models.SettingRegion", b =>
                {
                    b.Property<long>("SettingId");

                    b.Property<long>("RegionId");

                    b.HasKey("SettingId", "RegionId");

                    b.HasIndex("RegionId");

                    b.ToTable("SettingRegions");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ShippingClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<string>("ShippingClassName")
                        .HasMaxLength(200);

                    b.Property<string>("Slug")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ShippingClasses");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ShippingRegion", b =>
                {
                    b.Property<long>("SettingId");

                    b.Property<long>("RegionId");

                    b.HasKey("SettingId", "RegionId");

                    b.HasIndex("RegionId");

                    b.ToTable("ShippingRegions");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Slide", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<string>("CallToActionText");

                    b.Property<string>("CallToActionUrl");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<bool>("DisplayTexts");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Photo");

                    b.Property<int>("Position");

                    b.Property<long?>("SliderId");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Video");

                    b.HasKey("Id");

                    b.HasIndex("SliderId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Template")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Subscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FullName")
                        .HasMaxLength(200);

                    b.Property<bool>("IsSubscribed");

                    b.Property<DateTime>("SubscriptionDate");

                    b.Property<DateTime>("UnsubscriptionDate");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("CmsCoreV2.Models.TaxRate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<int>("CityPlateCode");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<long?>("DistrictId");

                    b.Property<float>("Rate");

                    b.Property<string>("TaxName")
                        .HasMaxLength(200);

                    b.Property<bool>("TaxRateCompound");

                    b.Property<int>("TaxRatePriority");

                    b.Property<bool>("TaxRateShipping");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("TaxRates");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CmsCoreV2.Models.AttributeItem", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Attribute", "ProductAttribute")
                        .WithMany()
                        .HasForeignKey("ProductAttributeId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.CouponProduct", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Coupon", "Coupon")
                        .WithMany("CouponProducts")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("CouponProducts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.CouponProductCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Coupon", "Coupon")
                        .WithMany("CouponProductCategories")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.ProductCategory", "ProductCategory")
                        .WithMany("CouponProductCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Customer", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "BillingCity")
                        .WithMany()
                        .HasForeignKey("BillingCityId");

                    b.HasOne("CmsCoreV2.Models.Region", "BillingCountry")
                        .WithMany()
                        .HasForeignKey("BillingCountryId");

                    b.HasOne("CmsCoreV2.Models.Region", "BillingDistrict")
                        .WithMany()
                        .HasForeignKey("BillingDistrictId");

                    b.HasOne("CmsCoreV2.Models.Region", "ShippingCity")
                        .WithMany()
                        .HasForeignKey("ShippingCityId");

                    b.HasOne("CmsCoreV2.Models.Region", "ShippingCountry")
                        .WithMany()
                        .HasForeignKey("ShippingCountryId");

                    b.HasOne("CmsCoreV2.Models.Region", "ShippingDistrict")
                        .WithMany()
                        .HasForeignKey("ShippingDistrictId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ExcludeCouponProduct", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Coupon", "Coupon")
                        .WithMany("ExcludeCouponProducts")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("ExcludeCouponProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.ExcludeCouponProductCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Coupon", "Coupon")
                        .WithMany("ExcludeCouponProductCategories")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.ProductCategory", "ProductCategory")
                        .WithMany("ExcludeCouponProductCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.FeedbackValue", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Feedback", "Feedback")
                        .WithMany("FeedbackValues")
                        .HasForeignKey("FeedbackId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Form", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany("Forms")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.FormField", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Form", "Form")
                        .WithMany("FormFields")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItem", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Gallery", "Gallery")
                        .WithMany("GalleryItems")
                        .HasForeignKey("GalleryId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItemCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.GalleryItemCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.GalleryItemGalleryItemCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.GalleryItemCategory", "GalleryItemCategory")
                        .WithMany("GalleryItemGalleryItemCategories")
                        .HasForeignKey("GalleryItemCategoryId");

                    b.HasOne("CmsCoreV2.Models.GalleryItem", "GalleryItem")
                        .WithMany("GalleryItemGalleryItemCategories")
                        .HasForeignKey("GalleryItemId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Menu", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany("Menus")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.MenuItem", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.MenuItem", "ParentMenuItem")
                        .WithMany("ChildMenuItems")
                        .HasForeignKey("ParentMenuItemId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Order", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("CmsCoreV2.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderItem", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderMetaField", b =>
                {
                    b.HasOne("CmsCoreV2.Models.MetaField", "MetaField")
                        .WithMany("OrderMetaFields")
                        .HasForeignKey("MetaFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Order", "Order")
                        .WithMany("OrderMetaFields")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderNote", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Order")
                        .WithMany("OrderNotes")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.OrderOrderItem", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Order", "Order")
                        .WithMany("OrderOrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.OrderItem", "OrderItem")
                        .WithMany("OrderOrderItems")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Page", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany("Pages")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCoreV2.Models.Page", "ParentPage")
                        .WithMany("ChildPages")
                        .HasForeignKey("ParentPageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Post", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany("Posts")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.PostCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany("PostCategories")
                        .HasForeignKey("LanguageId");

                    b.HasOne("CmsCoreV2.Models.PostCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.PostPostCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.PostCategory", "PostCategory")
                        .WithMany("PostPostCategories")
                        .HasForeignKey("PostCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Post", "Post")
                        .WithMany("PostPostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Product", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Product", "CrossSell")
                        .WithMany("CrossSells")
                        .HasForeignKey("CrossSellId");

                    b.HasOne("CmsCoreV2.Models.Product", "GroupedProduct")
                        .WithMany("GroupedProducts")
                        .HasForeignKey("GroupedProductId");

                    b.HasOne("CmsCoreV2.Models.Product", "UpSell")
                        .WithMany("UpSells")
                        .HasForeignKey("UpSellId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductAttribute", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Attribute", "Attribute")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.ProductCategory", "parentCategory")
                        .WithMany()
                        .HasForeignKey("parentCategoryId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductMedia", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Media", "Media")
                        .WithMany("ProductMedias")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("ProductMedias")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductProductCategory", b =>
                {
                    b.HasOne("CmsCoreV2.Models.ProductCategory", "ProductCategory")
                        .WithMany("ProductProductCategories")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("ProductProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.ProductProductTag", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Product", "Product")
                        .WithMany("ProductProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.ProductTag", "ProductTag")
                        .WithMany("ProductProductTags")
                        .HasForeignKey("ProductTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Region", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "ParentRegion")
                        .WithMany("ChildRegions")
                        .HasForeignKey("ParentRegionId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.Resource", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.SaleRegion", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "Region")
                        .WithMany("SalesLocations")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Setting", "Setting")
                        .WithMany("SalesLocations")
                        .HasForeignKey("SettingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Setting", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Page", "BasketPage")
                        .WithMany()
                        .HasForeignKey("BasketPageId");

                    b.HasOne("CmsCoreV2.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("CmsCoreV2.Models.Region", "MainLocation")
                        .WithMany()
                        .HasForeignKey("MainLocationId");

                    b.HasOne("CmsCoreV2.Models.Page", "MyAccountPage")
                        .WithMany()
                        .HasForeignKey("MyAccountPageId");

                    b.HasOne("CmsCoreV2.Models.Page", "PaymentPage")
                        .WithMany()
                        .HasForeignKey("PaymentPageId");

                    b.HasOne("CmsCoreV2.Models.Page", "StorePage")
                        .WithMany()
                        .HasForeignKey("StorePageId");

                    b.HasOne("CmsCoreV2.Models.Page", "TermsAndConditionsPage")
                        .WithMany()
                        .HasForeignKey("TermsAndConditionsPageId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.SettingRegion", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "Region")
                        .WithMany("ShippingRegions")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Setting", "Setting")
                        .WithMany("ShippingRegions")
                        .HasForeignKey("SettingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.ShippingRegion", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "Region")
                        .WithMany("ShippingLocations")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.Setting", "Setting")
                        .WithMany("ShippingLocations")
                        .HasForeignKey("SettingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsCoreV2.Models.Slide", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Slider", "Slider")
                        .WithMany("Slides")
                        .HasForeignKey("SliderId");
                });

            modelBuilder.Entity("CmsCoreV2.Models.TaxRate", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Region", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CmsCoreV2.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CmsCoreV2.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("CmsCoreV2.Models.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsCoreV2.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
