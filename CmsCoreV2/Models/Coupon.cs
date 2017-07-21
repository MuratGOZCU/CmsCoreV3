using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Coupon:BaseEntity
    {
        public Coupon()
        {
            CouponProducts = new HashSet<CouponProduct>();
            ExcludeCouponProducts = new HashSet<ExcludeCouponProduct>();
            CouponProductCategories = new HashSet<CouponProductCategory>();
            ExcludeCouponProductCategories = new HashSet<ExcludeCouponProductCategory>();
        }
        [Display(Name = "Kupon Başına Kullanım Sınırı")]
        public int LimitPerCoupon { get; set; }
        [Display(Name = "Kullanımı X Ögeleriyle Sınırla")]
        public int? LimitUse { get; set; }
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
        public bool AllowFreeShipping { get; set; }
        [Display(Name ="Kupon son kullanım tarihi")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Asgari Harcama")]
        public decimal MinimumSpending { get; set; }
        [Display(Name = "Azami Harcama")]
        public decimal MaximumSpending { get; set; }
        [Display(Name = "Sadece Bireysel Kullanım")]
        public bool OnlyIndividualUse { get; set; }
        [Display(Name = "İndirimdeki Ürünler Hariç")]
        public bool ExcludeDiscountProduct { get; set; }
        [Display(Name = "Ürünler")]
        public virtual ICollection<CouponProduct> CouponProducts { get; set; }
        [Display(Name = "Ürünleri Hariç Tut")]
        public virtual ICollection<ExcludeCouponProduct> ExcludeCouponProducts { get; set; }
        [Display(Name = "Ürün Kategorileri")]
        public virtual ICollection<CouponProductCategory> CouponProductCategories { get; set; }
        [Display(Name = "Kategorileri Hariç Tut")]
        public virtual ICollection<ExcludeCouponProductCategory> ExcludeCouponProductCategories { get; set; }
        [Display(Name = "E-posta Kısıtlamaları")]
        public string RestrictedEmails { get; set; }

    }
}
