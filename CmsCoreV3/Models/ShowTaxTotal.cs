using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum ShowTaxTotal
    {
        [Display(Name = @"Tek bir toplam olarak")]
        Total = 1,
        [Display(Name = @"Ayrıntılı")]
        Detailed = 2,
    }
}
