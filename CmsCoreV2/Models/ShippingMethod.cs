using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ShippingMethod
    {
        [Display(Name = @"Sabit Oran")]
        FixedRate = 1,
        [Display(Name = @"Ücretsiz Kargo")]
        FreeShipping = 2,
        [Display(Name = "Uluslararası Kargo")]
        InternationalShipping = 3,
        [Display(Name = "Yerel Teslimat")]
        LocalDelivery = 4,
        [Display(Name = @"Mağazadan Teslim")]
        Submission = 5
    }
}
