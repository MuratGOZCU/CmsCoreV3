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
       
        [Required(ErrorMessage = "Sipariş Tarihi boş bırakılamaz.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public OrderStatus OrderStatus { get; set; }
        [Display(Name = "Müşteri")]
        [ForeignKey("CustomerId")]
        public long? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [StringLength(200)]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Sipariş Notları")]
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
        public long TransactionId { get; set; }
        [Display(Name = "Ödeme Yöntemleri")]
        [ForeignKey("PaymentMethodId")]
        public long? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Müşteri Notu")]
        public string CustomerNote { get; set; }
        public virtual ICollection<OrderMetaField> OrderMetaFields { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public string Owner { get; set; }
        public int ProductCount { get { return OrderItems.Sum(ci => ci.Quantity); } }
        public float SubtotalPrice { get { return OrderItems.Sum(ci => ci.TotalPrice); } }
        public float ShippingPrice { get { return OrderItems.Sum(oi=>oi.ShippingPrice); } }
        public float Coupon { get { return 20; } }
        public float DiscountPrice { get { return (SubtotalPrice + ShippingPrice) * (Coupon / 100); } }
        public float TotalPrice { get { return (SubtotalPrice + ShippingPrice) - (SubtotalPrice + ShippingPrice) * (Coupon / 100); } }
    }
}
