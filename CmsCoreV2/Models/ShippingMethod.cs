using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ShippingMethod
    {
        [Display(Name = @"Sabit fiyat")]
        FixedPrice = 1,
        [Display(Name = @"Ücretsiz gönderim")]
        FreeShipping = 2,
        [Display(Name = @"Mağazadan teslim")]
        Submission = 3,
    }
}
