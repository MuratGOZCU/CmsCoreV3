using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ShippingMethod
    {
        [Display(Name = @"Alıcı Öder")]
        FixedRate = 1,
        [Display(Name = @"Satıcı Öder/Ücretsiz Kargo")]
        FreeShipping = 2,
        [Display(Name = @"Kargosuz/Mağazadan Teslim")]
        NoShipping = 3
    }
}
