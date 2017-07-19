using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ShowPricesInStore
    {
        [Display(Name = @"Vergi dahil")]
        TaxIncluded = 1,
        [Display(Name = @"Vergi hariç")]
        TaxExcluded = 2,
    }
}
