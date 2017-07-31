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
            OrderOrderItems = new HashSet<OrderOrderItem>();
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
        public virtual ICollection<OrderOrderItem> OrderOrderItems { get; set; }
    }
}
