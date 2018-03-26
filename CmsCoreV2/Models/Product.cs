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
            ProductProductCategories = new HashSet<ProductProductCategory>();
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
        [StringLength(200)]
        [Display(Name = "Bağlantı")]
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
        [Display(Name = "Stok Sayısı")]
        public int? StockCount { get; set; }
        [Display(Name = "Stok Durumu")]
        public bool StockStatus { get; set; }
        public ShippingMethod ShippingMethod {get; set;}
        public long? ShippingCityId {get; set;}
        [ForeignKey("ShippingCityId")]
        public Region ShippingCity {get; set;}
        public long? ShippingZoneId {get; set;}
        [ForeignKey("ShippingZoneId")]
        public ShippingZone ShippingZone {get; set;}
        [Display(Name = "Kargo Firması")]
        public long? ShippingClassId {get; set;}
        [ForeignKey("ShippingClassId")]
        [Display(Name = "Kargo Firması")]
        public ShippingClass ShippingClass {get; set;}
        public virtual ICollection<ShippingPrice> ShippingPrices {get; set;}
        /*
        [Display(Name = "Ağırlık")]
        public float Weight { get; set; }
        [Display(Name = "Uzunluk")]
        public float Length { get; set; }
        [Display(Name = "Yükseklik")]
        public float Height { get; set; }
        [Display(Name = "Genişlik")]
        public float Width { get; set; }
        
         */
        [Display(Name = "Ürün Tipi")]
        public ProductType ProductType { get; set; }
        [StringLength(450)]
        [Display(Name = "Url")]
        public string ProductUrl { get; set; }
        /*
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
         */
        [Display(Name = "Ürün Özellikleri")]
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        [Display(Name = "Satın Alma Notu")]
        public string PurchaseNote { get; set; }
        [Display(Name = "Menü Sırası")]
        public int MenuOrder { get; set; }
        [Display(Name = "Kategoriler")]
        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string ProductImage { get; set; }
        [Display(Name = "Kısa Açıklaması")]
        public string ShortDescription { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Ürün Görselleri")]
        public ICollection<ProductMedia> ProductMedias { get; set; }
        [Display(Name = "Görüntülenme Sayısı")]
        public int ViewCount { get; set; }
        [Display(Name = "Satış sayısı")]
        public int SaleCount { get; set; }
        [Display(Name = "Katalog Görünürlüğü")]
        public CatalogVisibility CatalogVisibility { get; set; }
        [Display(Name="Öne Çıkan")]
        public bool IsFeatured { get; set; }
        [Display(Name="Yeni")]
        public bool IsNew { get; set; }
        [Display(Name="Onaylandı mı?")]
        public bool IsApproved { get; set; }
        public virtual ICollection<ProductAttributeItem> ProductAttributeItems {get; set;}
        [Display(Name = "Tedarikçi")]
        public long? SupplierId {get; set;}
        [ForeignKey("SupplierId")]
        [Display(Name = "Tedarikçi")]
        public Supplier Supplier {get;set;}
    }
}
