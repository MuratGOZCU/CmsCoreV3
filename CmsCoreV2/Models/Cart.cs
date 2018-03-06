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
        }
        public string Owner { get; set; }
        public int ProductCount { get { return CartItems.Sum(ci => ci.Quantity); } }
        public float SubtotalPrice { get { return CartItems.Sum(ci => ci.TotalPrice); } }
        public float ShippingPrice { get { return 0; } }
        public float Coupon { get { return -20; } }
        public float TotalPrice { get { return (SubtotalPrice + ShippingPrice)+(SubtotalPrice + ShippingPrice)*(Coupon/100); } }
        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
