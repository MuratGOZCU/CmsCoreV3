using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CouponProducts = new HashSet<CouponProduct>();
            ExcludeCouponProducts = new HashSet<ExcludeCouponProduct>();
            ProductAttributes = new HashSet<ProductAttribute>();
        }
        [Display(Name = "Kuponlar")]
        public virtual ICollection<CouponProduct> CouponProducts { get; set; }
        [Display(Name = "Hariç tutulan kuponlar")]
        public virtual ICollection<ExcludeCouponProduct> ExcludeCouponProducts { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public TaxStatus TaxStatus { get; set; }
        public TaxClass TaxClass { get; set; }
        public string StockCode { get; set; }
        public int StockCount { get; set; }
        public bool StockStatus { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductUrl { get; set; }
        public long? UpSellId { get; set; }
        [ForeignKey("UpSellId")]
        public virtual Product UpSell { get; set; }
        public ICollection<Product> UpSells { get; set; }
        public long? CrossSellId { get; set; }
        [ForeignKey("CrossSellId")]
        public virtual Product CrossSell { get; set; }
        public ICollection<Product> CrossSells { get; set; }
        public long? GroupedProductId { get; set; }
        [ForeignKey("GroupedProductId")]
        public virtual Product GroupedProduct { get; set; }
        public ICollection<Product> GroupedProducts { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public string PurchaseNote { get; set; }
        public int MenuOrder { get; set; }
        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }
        public ICollection<ProductProductTag> ProductProductTags { get; set; }
        public string ProductImage { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<ProductMedia> ProductMedias { get; set; }
        public int ViewCount { get; set; }
        public int SaleCount { get; set; }
        public CatalogVisibility CatalogVisibility { get; set; }
        public bool IsFeatured { get; set; }

    }
}
