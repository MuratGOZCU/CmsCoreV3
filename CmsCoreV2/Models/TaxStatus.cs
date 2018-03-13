using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum TaxStatus
    {
        [Display(Name = "Vergilendirilebilir")]
        Taxable = 1,
        Shipping = 2,
        None = 3
    }
}
