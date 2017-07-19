using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum DiscountType
    {
        [Display(Name = @"İndirim Yüzdesi")]
        DiscountRate = 1,
        [Display(Name = @"Sabit Sepet İndirimi")]
        Basket = 2,
        [Display(Name = @"Sabit Ürün İndirimi")]
        Product = 3,
    }
}
