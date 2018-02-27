using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Ad"),
         Required(ErrorMessage = "Lütfen bir {0} giriniz."),
         MinLength(3, ErrorMessage = "{0} en az {1} karakter olmalıdır."),
         MaxLength(250, ErrorMessage = "{0} en fazla {1} karakter olmalıdır.")]
        public string Name { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [Display(Name = "Açıklama"),
            MinLength(3, ErrorMessage = "{0} en az {1} karakter olmalıdır."),
         MaxLength(500, ErrorMessage = "{0} en fazla {1} karakter olmalıdır.")]
        public string Description { get; set; }
        [Display(Name = "Dil")]
        public long? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        [Display(Name = "Dil")]
        public Language Language { get; set; }
        [DisplayName("Birim Fiyat"), Required(ErrorMessage = "Lütfen bir {0} değeri giriniz."),
        DataType(DataType.Currency)]
        public float? UnitPrice { get; set; }
        [DisplayName("İndirimli Fiyat"), Required(ErrorMessage = "Lütfen bir {0} değeri giriniz."),
         DataType(DataType.Currency)]
        public float? SalePrice { get; set; }
        [Display(Name = "Vergi Durumu")]
        public TaxStatus TaxStatus { get; set; }
        [Display(Name = "Vergi Sınıfı")]
        public TaxClass TaxClass { get; set; }
        [Display(Name = "Stok Kodu")]
        public string StockCode { get; set; }
        [Display(Name = "Stok Sayısı"),Required]
        public int StockCount { get; set; }
        [Display(Name = "Stok Durumu")]
        public bool StockStatus { get; set; }
        [Display(Name = "Ağırlık")]
        public double Weight { get; set; }
        [Display(Name = "Uzunluk")]
        public double Length { get; set; }
        [Display(Name = "Yükseklik")]
        public double Height { get; set; }
        [Display(Name = "Genişlik")]
        public double Width { get; set; }
        [Display(Name = "Ürün Tipi")]
        public ProductType ProductType { get; set; }
        [Display(Name = "Url")]
        public string ProductUrl { get; set; }
        public long? UpSellId { get; set; }
        [ForeignKey("UpSellId")]
        public virtual Product UpSell { get; set; }
        public ICollection<Product> UpSells { get; set; }
        [Display(Name = "Çapraz Satış")]
        public long? CrossSellId { get; set; }
        [ForeignKey("CrossSellId")]
        public virtual Product CrossSell { get; set; }
        public ICollection<Product> CrossSells { get; set; }
        public long? GroupedProductId { get; set; }
        [ForeignKey("GroupedProductId")]
        public virtual Product GroupedProduct { get; set; }
        public ICollection<Product> GroupedProducts { get; set; }
        [Display(Name = "Ürün Nitelikleri")]
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        [Display(Name = "Satın Alma Notu")]
        public string PurchaseNote { get; set; }
        [Display(Name = "Menu Siparişi")]
        public int MenuOrder { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }
        [Display(Name = "Ürün Etiketi")]
        public ICollection<ProductProductTag> ProductProductTags { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string ProductImage { get; set; }
        [Display(Name = "Alternatif Ürün Resmi")]
        public string AlternateProductImage { get; set; }
        [Display(Name = "Kısa Açıklaması")]
        public string ShortDescription { get; set; }
        [Display(Name = "Ürün Medyası")]
        public ICollection<ProductMedia> ProductMedias { get; set; }
        [Display(Name = "Görüntülenme Sayısı")]
        public int ViewCount { get; set; }
        [Display(Name = "Satış sayısı")]
        public int SaleCount { get; set; }
        [Display(Name = "Katalog Görünümü")]
        public CatalogVisibility CatalogVisibility { get; set; }
        [Display(Name="Öne Çıkan")]
        public bool IsFeatured { get; set; }
        [Display(Name="Yeni")]
        public bool IsNew { get; set; }
        [Display(Name="Yayında")]
        public bool IsPublished { get; set; }

    }
}
