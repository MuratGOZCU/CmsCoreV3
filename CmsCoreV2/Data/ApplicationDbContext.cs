using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CmsCoreV2.Models;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Http;

namespace CmsCoreV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public readonly AppTenant tenant;
        private readonly IHttpContextAccessor _accessor;
        public ApplicationDbContext() { }
        public ApplicationDbContext(AppTenant tenant, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        
            if (tenant != null)
            {
                this.tenant = tenant;
                var tenantId = this.tenant.AppTenantId;
                this.Seed(accessor);
                //QueryFilterManager.Filter<Page>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Language>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Media>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Gallery>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<GalleryItem>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<GalleryItemCategory>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Post>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<PostCategory>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<PostPostCategory>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<ApplicationUser>(q => q.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Role>(q => q.Where(x => x.AppTenantId == tenantId));

                //QueryFilterManager.Filter<Customization>(c => c.Where(x => x.AppTenantId == tenantId));
                //QueryFilterManager.Filter<Setting>(q => q.Where(x => x.AppTenantId == tenantId));


                //QueryFilterManager.InitilizeGlobalFilter(this);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer((tenant != null ? tenant.ConnectionString : "Server=.;Database=TenantDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<CmsCoreV2.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CmsCoreV2.Models.Role> Role { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostPostCategory>PostPostCategories { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackValue> FeedbackValues { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Redirect> Redirects { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<GalleryItemCategory> GalleryItemCategories { get; set; }
        public DbSet<GalleryItemGalleryItemCategory> GalleryItemGalleryItemCategories { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeItem> AttributeItems { get; set; }
        public DbSet<CouponProduct>CouponProducts { get; set; }
        public DbSet<CouponProductCategory> CouponProductCategories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<MetaField> MetaFields { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderMetaField> OrderMetaFields { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
        public DbSet<ProductProductCategory> ProductProductCategories { get; set; }
        public DbSet<ProductProductTag> ProductProductTags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SaleRegion> SaleRegions { get; set; }
        public DbSet<SettingRegion> SettingRegions { get; set; }
        public DbSet<ShippingClass> ShippingClasses { get; set; }
        public DbSet<ShippingRegion> ShippingRegions { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<ExcludeCouponProduct> ExcludeCouponProducts { get; set; }
        public DbSet<ExcludeCouponProductCategory> ExcludeCouponProductCategories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Popup> Popups { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ProductAttributeItem> ProductAttributeItems {get; set;}
        public DbSet<Supplier> Suppliers {get; set;}

        // diğer dbsetler buraya eklenir

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<PostPostCategory>().HasKey(pc => new { pc.PostId, pc.PostCategoryId });
            builder.Entity<PostPostCategory>().HasOne(bc => bc.Post)
                .WithMany(b => b.PostPostCategories)
                .HasForeignKey(bc => bc.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PostPostCategory>().HasOne(bc => bc.PostCategory)
                .WithMany(c => c.PostPostCategories)
                .HasForeignKey(bc => bc.PostCategoryId).OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<GalleryItemGalleryItemCategory>().HasKey(pc => new { pc.GalleryItemId, pc.GalleryItemCategoryId });
            builder.Entity<GalleryItemGalleryItemCategory>().HasOne(bc => bc.GalleryItem)
                .WithMany(b => b.GalleryItemGalleryItemCategories)
                .HasForeignKey(bc => bc.GalleryItemId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GalleryItemGalleryItemCategory>().HasOne(bc => bc.GalleryItemCategory)
                .WithMany(c => c.GalleryItemGalleryItemCategories)
                .HasForeignKey(bc => bc.GalleryItemCategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CouponProduct>().HasKey(pc => new { pc.CouponId, pc.ProductId });
            builder.Entity<CouponProduct>().HasOne(bc => bc.Coupon)
                .WithMany(b => b.CouponProducts)
                .HasForeignKey(bc => bc.CouponId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CouponProduct>().HasOne(bc=>bc.Product)
                .WithMany(c=>c.CouponProducts)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CouponProductCategory>().HasKey(pc => new { pc.CouponId, pc.ProductCategoryId });
            builder.Entity<CouponProductCategory>().HasOne(bc => bc.Coupon)
                .WithMany(b => b.CouponProductCategories)
                .HasForeignKey(bc => bc.CouponId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CouponProductCategory>().HasOne(bc => bc.ProductCategory)
                .WithMany(c => c.CouponProductCategories)
                .HasForeignKey(bc => bc.ProductCategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExcludeCouponProduct>().HasKey(pc => new { pc.CouponId, pc.ProductId });
            builder.Entity<ExcludeCouponProduct>().HasOne(bc => bc.Coupon)
                .WithMany(b => b.ExcludeCouponProducts)
                .HasForeignKey(bc => bc.CouponId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ExcludeCouponProduct>().HasOne(bc => bc.Product)
                .WithMany(c => c.ExcludeCouponProducts)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ExcludeCouponProductCategory>().HasKey(pc => new { pc.CouponId, pc.ProductCategoryId });
            builder.Entity<ExcludeCouponProductCategory>().HasOne(bc => bc.Coupon)
                .WithMany(b => b.ExcludeCouponProductCategories)
                .HasForeignKey(bc => bc.CouponId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ExcludeCouponProductCategory>().HasOne(bc => bc.ProductCategory)
                .WithMany(c => c.ExcludeCouponProductCategories)
                .HasForeignKey(bc => bc.ProductCategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderMetaField>().HasKey(pc => new { pc.OrderId, pc.MetaFieldId });
            builder.Entity<OrderMetaField>().HasOne(bc => bc.Order)
                .WithMany(b => b.OrderMetaFields)
                .HasForeignKey(bc => bc.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<OrderMetaField>().HasOne(bc => bc.MetaField)
                .WithMany(c => c.OrderMetaFields)
                .HasForeignKey(bc => bc.MetaFieldId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductAttribute>().HasKey(pc => new { pc.ProductId, pc.AttributeId });
            builder.Entity<ProductAttribute>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductAttributes)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductAttribute>().HasOne(bc => bc.Attribute)
                .WithMany(c => c.ProductAttributes)
                .HasForeignKey(bc => bc.AttributeId).OnDelete(DeleteBehavior.Cascade);

                builder.Entity<ProductAttributeItem>().HasKey(pc => new { pc.ProductId, pc.AttributeItemId });
            builder.Entity<ProductAttributeItem>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductAttributeItems)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductAttribute>().HasOne(bc => bc.Attribute)
                .WithMany(c => c.ProductAttributes)
                .HasForeignKey(bc => bc.AttributeId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductMedia>().HasKey(pc => new { pc.ProductId, pc.MediaId });
            builder.Entity<ProductMedia>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductMedias)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductMedia>().HasOne(bc => bc.Media)
                .WithMany(c => c.ProductMedias)
                .HasForeignKey(bc => bc.MediaId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductMedia>().HasKey(pc => new { pc.ProductId, pc.MediaId });
            builder.Entity<ProductMedia>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductMedias)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductMedia>().HasOne(bc => bc.Media)
                .WithMany(c => c.ProductMedias)
                .HasForeignKey(bc => bc.MediaId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductProductCategory>().HasKey(pc => new { pc.ProductId, pc.ProductCategoryId });
            builder.Entity<ProductProductCategory>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductProductCategories)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductProductCategory>().HasOne(bc => bc.ProductCategory)
                .WithMany(c => c.ProductProductCategories)
                .HasForeignKey(bc => bc.ProductCategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductProductTag>().HasKey(pc => new { pc.ProductId, pc.ProductTagId });
            builder.Entity<ProductProductTag>().HasOne(bc => bc.Product)
                .WithMany(b => b.ProductProductTags)
                .HasForeignKey(bc => bc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductProductTag>().HasOne(bc => bc.ProductTag)
                .WithMany(c => c.ProductProductTags)
                .HasForeignKey(bc => bc.ProductTagId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SettingRegion>().HasKey(pc => new { pc.SettingId, pc.RegionId });
            builder.Entity<SettingRegion>().HasOne(bc => bc.Setting)
                .WithMany(b => b.ShippingRegions)
                .HasForeignKey(bc => bc.SettingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SettingRegion>().HasOne(bc => bc.Region)
                .WithMany(c => c.ShippingRegions)
                .HasForeignKey(bc => bc.RegionId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SaleRegion>().HasKey(pc => new { pc.SettingId, pc.RegionId });
            builder.Entity<SaleRegion>().HasOne(bc => bc.Setting)
                .WithMany(b => b.SalesLocations)
                .HasForeignKey(bc => bc.SettingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SaleRegion>().HasOne(bc => bc.Region)
                .WithMany(c => c.SalesLocations)
                .HasForeignKey(bc => bc.RegionId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShippingRegion>().HasKey(pc => new { pc.SettingId, pc.RegionId });
            builder.Entity<ShippingRegion>().HasOne(bc => bc.Setting)
                .WithMany(b => b.ShippingLocations)
                .HasForeignKey(bc => bc.SettingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ShippingRegion>().HasOne(bc => bc.Region)
                .WithMany(c => c.ShippingLocations)
                .HasForeignKey(bc => bc.RegionId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
            .HasMany(e => e.UpSells) 
            .WithOne(e => e.UpSell) 
            .HasForeignKey(e => e.UpSellId);

            builder.Entity<Product>()
            .HasMany(e => e.CrossSells)
            .WithOne(e => e.CrossSell)
            .HasForeignKey(e => e.CrossSellId);
            builder.Entity<Product>()
            .HasMany(e => e.GroupedProducts)
            .WithOne(e => e.GroupedProduct)
            .HasForeignKey(e => e.GroupedProductId);
        }
        // diğer dbsetler buraya eklenir

    
        // diğer dbsetler buraya eklenir

     
    

        // diğer dbsetler buraya eklenir



    }
}
