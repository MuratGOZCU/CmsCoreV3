using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderMetaFields = new HashSet<OrderMetaField>();
            OrderItems = new HashSet<OrderItem>();
            OrderNotes= new HashSet<OrderNote>();
        }
       
        [Required(ErrorMessage = "Sipariş Tarihi zorunludur.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public OrderStatus OrderStatus { get; set; }
        [Display(Name = "Müşteri")]
        [ForeignKey("CustomerId")]
        public long? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Display(Name = "Sipariş Notları")]
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
        public long TransactionId { get; set; }
        [Display(Name = "Ödeme Yöntemleri")]
        [ForeignKey("PaymentMethodId")]
        public long? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Müşteri Notu")]
        public string CustomerNote { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name ="Ülke")]
        public string BillingCountry { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string BillingFirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string BillingLastName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Kimlik/Vergi No")]
        public string BillingIdentityNumber { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string BillingCompanyName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string BillingAddress { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Cadde/Sokak")]
        public string BillingStreet { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Şehir")]
        public string BillingCity { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "İlçe")]
        public string BillingCounty { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string BillingZipCode { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "E-posta")]
        public string BillingEmail { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string BillingPhone { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ülke")]
        public string DeliveryCountry { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string DeliveryFirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string DeliveryLastName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string DeliveryCompanyName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string DeliveryAddress { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Cadde/Sokak")]
        public string DeliveryStreet { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Şehir")]
        public string DeliveryCity { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "İlçe")]
        public string DeliveryCounty { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string DeliveryZipCode { get; set; }
        public string Owner {get; set;}
        public long CartId {get; set;}
        public virtual ICollection<OrderMetaField> OrderMetaFields { get; set; }
        public int ProductCount { get { return OrderItems.Sum(ci => ci.Quantity); } }
        public float SubtotalPrice { get { return OrderItems.Sum(ci => ci.TotalPrice); } }
        public float ShippingPrice { get { 
            var totalShippingPrice = OrderItems?.Where(c=>c.Product.ShippingMethod == ShippingMethod.FixedRate).Sum(ci=>ci.Product?.ShippingPrices?.FirstOrDefault(s=>(s.ShippingZoneId == (s.ShippingZone.ShippingZoneRegions.FirstOrDefault(r=>r.Region.Code == DestinationCityCode)?.ShippingZoneId ?? 0)))?.Price ?? (ci.Product?.ShippingPrices?.FirstOrDefault(p=>ci.Product.ShippingCity?.Code == DestinationCityCode)?.Price ?? 0)) ?? 0;
            return totalShippingPrice; } }
        public float DiscountPrice { get { return (SubtotalPrice + ShippingPrice) * (OrderCoupons.Sum(c=>c.CouponAmount) / 100); } }
        public float TotalPrice { get { return (SubtotalPrice + ShippingPrice)-(SubtotalPrice + ShippingPrice)*(OrderCoupons.Sum(c=>c.CouponAmount)/100); } }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderCoupon> OrderCoupons {get; set;}
        public string DestinationCityCode {get; set;}
    }
}
