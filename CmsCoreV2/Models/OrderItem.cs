using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class OrderItem:BaseEntity
    {
        public OrderItem()
        {
        
        }
        [Display(Name = "Ürün Adı")]
        [StringLength(200)]
        public string ProductName {get; set;}
       [StringLength(200)]
        [Display(Name = "Bağlantı")]
        public string Slug { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }        
        [Display(Name = "Satış Fiyatı")]
        public float SalePrice { get; set; }
        [Display(Name = "Stok Kodu")]
        public string StockCode { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Toplam Fiyat")]
        public float TotalPrice { get; set; }
        [Display(Name = "Gönderi Ücreti")]
        public float ShippingPrice { get; set; }
        [Display(Name = "İndirim")]
        public float DiscountPrice { get; set; }
        [Display(Name = "Ürün")]
        public long? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Display(Name = "Geri Ödeme")]
        public float Refund { get; set; }
        [Display(Name = "Geri Ödeme Detayları")]
        public string RefundDetails { get; set; }
        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
