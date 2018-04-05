using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Cart:BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
            CartCoupons = new HashSet<CartCoupon>();
        }
        public string Owner { get; set; }
        public int ProductCount { get { return CartItems.Sum(ci => ci.Quantity); } }
        public float SubtotalPrice { get { return CartItems.Sum(ci => ci.TotalPrice); } }
        public float ShippingPrice { get { 
            var totalShippingPrice = CartItems?.Where(c=>c.Product.ShippingMethod == ShippingMethod.FixedRate).Sum(ci=>ci.Product?.ShippingPrices?.FirstOrDefault(s=>(s.ShippingZoneId == (s.ShippingZone.ShippingZoneRegions.FirstOrDefault(r=>r.Region.Code == DestinationCityCode)?.ShippingZoneId ?? 0)))?.Price ?? (ci.Product?.ShippingPrices?.FirstOrDefault(p=>ci.Product.ShippingCity?.Code == DestinationCityCode)?.Price ?? 0)) ?? 0;
            return totalShippingPrice; } }
        public float DiscountPrice { get { return (SubtotalPrice + ShippingPrice) * (CartCoupons.Sum(c=>c.Coupon.CouponAmount) / 100); } }
        public float TotalPrice { get { return (SubtotalPrice + ShippingPrice)-(SubtotalPrice + ShippingPrice)*((CartCoupons.Sum(c=>c.Coupon.CouponAmount))/100); } }
        public virtual ICollection<CartItem> CartItems {get; set;}
        public virtual ICollection<CartCoupon> CartCoupons {get; set;}
        public string DestinationCityCode {get; set;}
        public bool IsCheckout {get; set;}
    }
}
