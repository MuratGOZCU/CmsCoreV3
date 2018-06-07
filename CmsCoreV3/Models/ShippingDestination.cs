using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum ShippingDestination
    {
        [Display(Name = @"Müşterinin gönderim adresini varsayılan olarak ayarla")]
        ShippingAddress = 1,
        [Display(Name = @"Müşterinin fatura adresini varsayılan olarak ayarla")]
        BillingAddress = 2,
        [Display(Name = @"Müşterinin fatura adresine gönderimi zorla")]
        RequiredBillingAddress = 3,
    }
}
