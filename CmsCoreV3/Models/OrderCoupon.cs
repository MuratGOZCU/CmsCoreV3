using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CmsCoreV3.Models
{
    public class OrderCoupon:BaseEntity
    {
        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public long CouponId { get; set; }        
        [Display(Name = "Kupon Başına Kullanım Sınırı")]
        public int LimitPerCoupon { get; set; }
        [Display(Name = "Kullanımı X Öğeyle Sınırla")]
        public int? LimitUse { get; set; }
        [Display(Name = "Kullanıcı Başına Kullanım Sınırı")]
        public int LimitPerUser { get; set; }
        [Display(Name = "İndirim Türü")]
        public DiscountType DiscountType { get; set; }
        [StringLength(200)]
        [Display(Name ="Kupon Kodu")]
        public string CouponCode { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kupon Tutarı")]
        public float CouponAmount { get; set; }
        [Display(Name = "Ücretsiz gönderime izin ver")]
        public bool AllowFreeShipping { get; set; }
        [Display(Name ="Kupon son kullanım tarihi")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Asgari Harcama")]
        public float MinimumSpending { get; set; }
        [Display(Name = "Azami Harcama")]
        public float MaximumSpending { get; set; }
        [Display(Name = "Sadece Bireysel Kullanım")]
        public bool OnlyIndividualUse { get; set; }
        [Display(Name = "İndirimdeki Ürünler Hariç")]
        public bool ExcludeDiscountProduct { get; set; }
    }
}