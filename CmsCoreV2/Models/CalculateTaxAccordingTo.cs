using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum CalculateTaxAccordingTo
    {
        [Display(Name = @"Müşteri gönderim adresi")]
        CustomerSendingAddress = 1,
        [Display(Name = @"Müşteri fatura adresi")]
        CustomerBillingAddress = 2,
        [Display(Name = @"Mağaza adresi")]
        StoreAddress = 3,
    }
}
