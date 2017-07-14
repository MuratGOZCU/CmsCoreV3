using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Coupon
    {
        public string CouponCode { get; set; }
        public string Description { get; set; }
        public double DiscountRate { get; set; }
        public decimal CouponBalance { get; set; }
        public decimal MinimumSpending { get; set; }
        public decimal MaximumSpending { get; set; }
        public bool İndividual { get; set; }
        public bool WithoutDiscountProduct { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> WithoutProducts { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<String> RestictedEmail { get; set; }

    }
}
