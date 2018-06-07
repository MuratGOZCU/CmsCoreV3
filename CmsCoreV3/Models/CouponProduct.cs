using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class CouponProduct
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}
