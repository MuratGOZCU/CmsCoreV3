using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class CartItem:BaseEntity
    {
        public CartItem()
        {
            CreateDate = DateTime.Now;
            Quantity = 1;
        }
        
        public long CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get { return Product.SalePrice ?? 0 ; } }
        public float TotalPrice { get { return (Product.SalePrice ?? 0) * Quantity; } }
        public float ShippingPrice { get { 
            var shippingPrice = (Product.ShippingMethod == ShippingMethod.FixedRate?Product.ShippingPrices?.FirstOrDefault(s=>(s.ShippingZoneId == (s.ShippingZone.ShippingZoneRegions.FirstOrDefault(r=>r.Region.Code == DestinationCityCode)?.ShippingZoneId ?? 0)))?.Price ?? (Product?.ShippingPrices?.FirstOrDefault(p=>p.Product.ShippingCity?.Code == DestinationCityCode)?.Price) ?? 0:0);
            return shippingPrice; }}
        public string DestinationCityCode {get; set;}
    }
}
