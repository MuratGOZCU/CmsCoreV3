using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Products = new HashSet<Product>();
            ExcludeProducts = new HashSet<Product>();
        }
        [Display(Name = "Ürünler")]
        public virtual ICollection<Product> Products { get; set; }
        [Display(Name = "Ürünleri Hariç Tut")]
        public virtual ICollection<Product> ExcludeProducts { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public TaxStatus taxStatus { get; set; }
        public TaxClass TaxClass { get; set; }
        public string StockCode { get; set; }
        public int StockCount { get; set; }
        public bool StockStatus { get; set; }
        public double weight { get; set; }
        public double length { get; set; }
        public double height { get; set; }
        public double width { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductUrl { get; set; }
        public ICollection<Product> UpSells { get; set; }
        public ICollection<Product> CrossSells { get; set; }
        public ICollection<Product> GroupedProducts { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public string purchaseNote { get; set; }
        public int MenuOrder { get; set; }
        public ICollection<ProductProductCategory> ProductCategories { get; set; }
        public ICollection<ProductProductTag> ProductTags { get; set; }
        public string ProductImage { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<ProductMedia> ProductMedias { get; set; }
        public int ViewCount { get; set; }
        public int SaleCount { get; set; }
        public CatalogVisibility CatalogVisibility { get; set; }
        public bool IsFeatured { get; set; }

    }
}
