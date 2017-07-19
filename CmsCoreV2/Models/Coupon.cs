using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Coupon
    {
        public Coupon()
        {
            Products = new HashSet<Product>();
            ExcludeProducts = new HashSet<Product>();
            ProductCategories = new HashSet<ProductCategory>();
            ExcludeProductCategories = new HashSet<ProductCategory>();
            RestictedEmail = new HashSet<String>();
        }
        [Display(Name = "Kupon Başına Kullanım Sınırı")]
        public int LimitPerCoupon { get; set; }
        [Display(Name = "Kullanımı X Ögeleriyle Sınırla")]
        public int LimitUse { get; set; }
        [Display(Name = "Kullanıcı Başına Kullanım Sınırı")]
        public int LimitPerUser { get; set; }
        public DiscountType DiscountType { get; set; }
        [StringLength(200)]
        [Display(Name ="Kupon Kodu")]
        public string CouponCode { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kupon Tutarı")]
        public decimal CouponAmount { get; set; }
        [Display(Name = "Ücretsiz gönderime izin ver")]
        public bool AllowFreePosting { get; set; }
        [Display(Name ="Kupon son kullanım tarihi")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Asgari Harcama")]
        public decimal MinimumSpending { get; set; }
        [Display(Name = "Azami Harcama")]
        public decimal MaximumSpending { get; set; }
        [Display(Name = "Sadece Bireysel Kullanım")]
        public bool İndividual { get; set; }
        [Display(Name = "İndirimdeki Ürünler Hariç")]
        public bool WithoutDiscountProduct { get; set; }
        [Display(Name = "Ürünler")]
        public virtual ICollection<Product> Products { get; set; }
        [Display(Name = "Ürünleri Hariç Tut")]
        public virtual ICollection<Product> ExcludeProducts { get; set; }
        [Display(Name = "Ürün Kategorileri")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        [Display(Name = "Kategorileri Hariç Tut")]
        public virtual ICollection<ProductCategory> ExcludeProductCategories { get; set; }
        [Display(Name = "E-posta Kısıtlamaları")]
        public virtual ICollection<String> RestictedEmail { get; set; }

    }
}
