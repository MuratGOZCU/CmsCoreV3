using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class OrderItem:BaseEntity
    {
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Gönderi Ücreti")]
        public decimal ShippingPrice { get; set; }
        [Display(Name = "İndirim")]
        public decimal DiscountPrice { get; set; }
        [Display(Name = "Ürün")]
        public long? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Display(Name = "Geri Ödeme")]
        public decimal Refund { get; set; }
        [Display(Name = "Geri Ödeme Detayları")]
        public string RefundDetails { get; set; }
        public virtual ICollection<OrderOrderItem> OrderOrderItems { get; set; }

    }
}
