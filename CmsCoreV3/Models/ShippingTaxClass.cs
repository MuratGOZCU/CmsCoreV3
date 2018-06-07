using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum ShippingTaxClass
    {
        [Display(Name = @"Sepet öğelerine dayalı gönderim vergi sınıfı")]
        Basket = 1,
        [Display(Name = @"Standart")]
        Standard = 2,
        [Display(Name = @"Reduced rate")]
        ReducedRate = 3,
        [Display(Name = @"Zero rate")]
        ZeroRate = 4,
    }
}
