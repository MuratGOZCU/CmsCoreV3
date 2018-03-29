namespace CmsCoreV2.Models
{
    public class CartCoupon
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public long CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}